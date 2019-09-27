using AuthenticationUser.CrossCutting.Identity.Models;
using AuthenticationUser.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AuthenticationUser.Infra.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category("Porções") { Id = 1 },
                new Category("Pizzas") { Id = 2 },
                new Category("Hamburguers") { Id = 3 },
                new Category("Bebidas") { Id = 4 }
            );
        }

        //public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public class ContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext()
            {
                return CreateDbContext(null);
            }

            public ApplicationDbContext CreateDbContext(string[] args)
            {
                var builderConfiguration = new ConfigurationBuilder();
                //.SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.Development.json");
                var configuration = builderConfiguration.Build();

                //var connectionString = configuration.GetConnectionString("DefaultConnection");
                var connectionString = "Server=den1.mssql7.gear.host;Database=captadev;User Id=captadev;Password=Nu7njS0U~L?L";

                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                builder.UseSqlServer(connectionString);

                return new ApplicationDbContext(builder.Options);
            }
        }
    }
}
