using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AuthenticationUser.CrossCutting.Identity.Models;
using AuthenticationUser.Domain.Models.Generic;
using AuthenticationUser.Domain.Models.Request.Login;
using AuthenticationUser.Domain.Models.Response;
using AuthenticationUser.WebApi.Controllers.Base;
using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AuthenticationUser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly string _grantTypeRefreshToken = "refresh_token";
        private readonly string _grantTypePasswordToken = "password";
        private IDistributedCache _cache;
        private IConfigurationRoot _configuration;


        /// <summary>
        /// AuthController
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        /// <param name="tokenConfigurations"></param>        
        /// <param name="cache"></param>
        /// <param name="iConfiguration"></param>        
        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            TokenConfigurations tokenConfigurations,
            IDistributedCache cache,
            IConfigurationRoot iConfiguration)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _tokenConfigurations = tokenConfigurations;
            _cache = cache;
            _configuration = iConfiguration;
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody]LoginModelRequest loginModel)
        {

            ResultResponseObject<TokenResponse> resultService = new ResultResponseObject<TokenResponse>();
            ApplicationUser appUser = null;

            if (loginModel.GrantType == _grantTypePasswordToken)
            {
                appUser = await HandleUserAuthentication(loginModel, resultService);
            }
            else if (loginModel.GrantType == _grantTypeRefreshToken)
            {
                appUser = await HandleRefreshToken(loginModel, resultService);
            }

            if (appUser == null)
            {
                if (resultService.ErrorMessages == null)
                {
                    resultService.ErrorMessages = new List<KeyValuePair<string, string>>();
                }
            }

            if (resultService.Success)
            {
                TokenResponse tokenResponse = await GenerateJwtToken(appUser);

                resultService.Value = tokenResponse;
            }

            return Response(resultService);
        }

        [AllowAnonymous]
        [HttpPost("initiliaze")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]        
        public async Task<IActionResult> InitializerUsers()
        {
            ResultResponse result = new ResultResponse();

            await CreateUser(
                     new ApplicationUser()
                     {
                         UserName = "user",
                         Email = "user@user.com",
                         EmailConfirmed = true,
                     }, "1234", "Administrator");

            await CreateUser(
                 new ApplicationUser()
                 {
                     UserName = "Admin",
                     Email = "admin@admin.com",
                     EmailConfirmed = true
                 }, "1234", "User");

            return Response(result);
        }

        #region [ Private Methods ]

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


        private async Task<ApplicationUser> HandleUserAuthentication(LoginModelRequest loginModel, ResultResponseObject<TokenResponse> resultResponseModel)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = new Microsoft.AspNetCore.Identity.SignInResult();
            ApplicationUser appUser = _userManager.Users.SingleOrDefault(r => r.UserName == loginModel.Login);

            if (appUser != null)
            {
                result = await _signInManager.PasswordSignInAsync(loginModel.Login, loginModel.Password, false, false);

                if (!result.Succeeded)
                {
                    resultResponseModel.AddError("Login", "Usuário ou senha inválida");
                    appUser = null;
                }
            }
            else
            {
                resultResponseModel.AddError("Login", "Usuário não encontrado");
            }

            return appUser;
        }

        private async Task<ApplicationUser> HandleRefreshToken(LoginModelRequest loginModel, ResultResponseObject<TokenResponse> resultResponseModel)
        {
            bool credenciaisValidas = false;

            if (String.IsNullOrEmpty(loginModel.RefreshToken))
            {
                RefreshTokenData refreshTokenBase = null;

                string strTokenArmazenado = _cache.GetString(loginModel.RefreshToken);
                if (!String.IsNullOrWhiteSpace(strTokenArmazenado))
                {
                    refreshTokenBase = JsonConvert
                        .DeserializeObject<RefreshTokenData>(strTokenArmazenado);
                }

                credenciaisValidas = (refreshTokenBase != null &&
                    loginModel.RefreshToken == refreshTokenBase.RefreshToken);

                // Elimina o token de refresh já que um novo será gerado
                if (credenciaisValidas)
                    _cache.Remove(loginModel.RefreshToken);
            }

            JwtSecurityToken token = null;
            if (!string.IsNullOrWhiteSpace(loginModel.RefreshToken))
            {
                token = new JwtSecurityTokenHandler().ReadJwtToken(loginModel.RefreshToken);
            }

            if (token == null)
            {
                resultResponseModel.AddError("Refresh Token", "Não foi possível ler o refresh token");
            }
            else if (token.ValidTo < DateTime.Now)
            {
                resultResponseModel.AddError("Refresh Token", "Refresh token inválido");
            }
            else
            {
                string userId = token.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.UniqueName).Value;

                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                return user;
            }

            return null;
        }


        private async Task<TokenResponse> GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

            IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
            IList<string> roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);

            var createdDate = DateTime.Now;
            var expiresTokenDate = createdDate.AddHours(Convert.ToDouble(_tokenConfigurations.HoursToExpireToken));
            var expiresRefreshTokenDate = createdDate.AddHours(Convert.ToDouble(_tokenConfigurations.HoursToExpireRefreshToken));

            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Id, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Id)
                    }
                );

            var symetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfigurations.Key));
            var creds = new SigningCredentials(symetricKey, SecurityAlgorithms.HmacSha256);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = creds,
                Expires = expiresTokenDate,
                NotBefore = createdDate,
                IssuedAt = createdDate,
                Subject = identity
            });

            var securityRefreshToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = creds,
                Expires = expiresRefreshTokenDate,
                NotBefore = createdDate,
                IssuedAt = createdDate,
                Subject = identity
            });

            var token = handler.WriteToken(securityToken);
            var refreshToken = handler.WriteToken(securityRefreshToken);

            return new TokenResponse
            {
                Username = user.UserName,
                Token = token,
                RefreshToken = refreshToken,
                Roles = roles,
                Claims = claims,
                Expires = expiresTokenDate
            };
        }

        #endregion
    }
}