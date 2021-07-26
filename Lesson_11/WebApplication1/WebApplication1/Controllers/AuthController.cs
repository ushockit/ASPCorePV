using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Models.Auth;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        static List<UserViewModel> users = new List<UserViewModel>
        {
            new UserViewModel { Id = 1, Email = "vasya@gmail.com", Password = "123456" }
        };


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Service check
                var user = users.FirstOrDefault(u => u.Email.Equals(model.Email) && u.Password.Equals(model.Password));

                // User was found
                if (user != null)
                {
                    // TODO: Authentication
                    await Authentication(user.Email);
                    return RedirectToAction("Index", "Home");
                }

                // User not found
                ModelState.AddModelError("", "User not found");
            }
            return View(model);
        }

        private async Task Authentication(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
