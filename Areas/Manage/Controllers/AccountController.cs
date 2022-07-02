using AllUp.Areas.Manage.ViewModels.AccountViewModels;
using AllUp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appuser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == login.Email.Trim().ToUpperInvariant() && u.IsAdmin == true);
            if (appuser == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(login);
            }
            if (login.Password != null)
            {
                Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appuser, login.Password, login.RememberMe, true);
                if (signInResult.IsLockedOut)
                {
                    ModelState.AddModelError("", $"You have been banned for 10 minutes. Time till unban: {((appuser.LockoutEnd.Value - DateTime.UtcNow).TotalMinutes).ToString("0")} minute(s)");
                    return View(login);
                }
                if (!signInResult.Succeeded)
                {
                    ModelState.AddModelError("", "Email or password is incorrect");
                    return View(login);
                }
            }
            else
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(login);
            }
            //if (!await _userManager.CheckPasswordAsync(appuser, login.Password))
            //{
            //    ModelState.AddModelError("", "Email or password is incorrect");
            //    return View();
            //}
            
            await _signInManager.SignInAsync(appuser, login.RememberMe);
            return RedirectToAction("index", "home", new {area = "manage" });

        }
    }
}
