using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models.Account;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        readonly ApplicationDbContext db;
        public AccountController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Login()
        {
            //db.Users.Add(new Data.Entity.User { Email = "vasya1@gmail.com", Password = "123456" });
            //db.Users.Add(new Data.Entity.User { Email = "vasya2@gmail.com", Password = "123456" });
            //db.Users.Add(new Data.Entity.User { Email = "vasya3@gmail.com", Password = "123456" });
            //db.SaveChanges();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Password = "";
                return View(model);
            }

            var user = db.Users.FirstOrDefault(u => u.Email.Equals(model.Email) && u.Password.Equals(model.Password));

            if (user is null)
            {
                return BadRequest();
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Email)
            };

            ClaimsIdentity id = new ClaimsIdentity(
                claims, 
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
