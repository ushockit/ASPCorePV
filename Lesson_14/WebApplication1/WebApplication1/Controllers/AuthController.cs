using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using WebApplication1.Models;
using WebApplication1.Models.Response;
using WebApplication1.Models.ViewModels;
using WebApplication1.Utils;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        static List<Account> accounts = new List<Account>
        {
            new Account { Password = "123456", Username = "vasya", Role = "ADMIN" },
            new Account { Password = "admin", Username = "admin", Role = "USER" },
        };
        public AuthController(SignInManager<object> signInManager)
        {
            ;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            var srcAcc = accounts.FirstOrDefault(acc => acc.Username.Equals(model.Username));

            if (srcAcc is null || !srcAcc.Password.Equals(model.Password))
            {
                return Unauthorized();      // Status code 401
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, srcAcc.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, srcAcc.Role),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            var jwtRules = new JwtSecurityToken(
                issuer: JwtAuthOptions.ISSUER,
                audience: JwtAuthOptions.AUDIENCE,
                notBefore: DateTime.UtcNow,
                claims: claimsIdentity.Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromSeconds(JwtAuthOptions.LIFETIME_SEC)),
                signingCredentials: new SigningCredentials(
                    JwtAuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256
                    )
                );
            var response = new JwtResponseModel
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtRules),
                Username = srcAcc.Username
            };
            return new JsonResult(response);
        }
    }
}
