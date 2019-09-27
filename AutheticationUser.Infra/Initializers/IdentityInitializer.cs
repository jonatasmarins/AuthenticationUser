using AuthenticationUser.CrossCutting.Identity.Models;
using AuthenticationUser.Infra.Contexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AuthenticationUser.Infra.Initializers
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public IdentityInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            //if (_context.Database.ensure())
            //{
            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new IdentityRole("Administrator")).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role Administrator.");
                }
            }

            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                var resultado = _roleManager.CreateAsync(
                    new IdentityRole("User")).Result;
                if (!resultado.Succeeded)
                {
                    throw new Exception(
                        $"Erro durante a criação da role User.");
                }
            }

            await CreateUser(
                 new ApplicationUser()
                 {
                     UserName = "user",
                     Email = "user@user.com",
                     EmailConfirmed = true,
                 }, "1234", "Administrador");

            await CreateUser(
                 new ApplicationUser()
                 {
                     UserName = "Admin",
                     Email = "admin@admin.com",
                     EmailConfirmed = true
                 }, "1234", "User");

        }
        //}

        private async Task CreateRole(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var resultado = await _roleManager.CreateAsync(new IdentityRole(role));

                if (!resultado.Succeeded)
                {
                    throw new Exception($"Erro durante a criação da role {role}.");
                }
            }
        }

        private async Task CreateUser(
            ApplicationUser user,
            string password,
            string initialRole = null)
        {
            if (await _userManager.FindByNameAsync(user.UserName) == null)
            {
                var resultado = await _userManager.CreateAsync(user, password);

                if (resultado.Succeeded && !String.IsNullOrWhiteSpace(initialRole))
                {
                    await _userManager.AddToRoleAsync(user, initialRole);
                }
            }
        }
    }
}
