using AllUp.Models;
using AllUp.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllUp.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<AccountController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        #region Roles
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "User" });

        //    return Content("Success!");
        //}
        #endregion
        #region SuperAdmin
        //public async Task<IActionResult> CreateSuperAdmin()
        //{
        //    AppUser appuser = new AppUser
        //    {
        //        Name = "Super",
        //        SurName = "Admin",
        //        UserName = "SuperAdmin",
        //        Email = "SuperAdmin@gmail.com"

        //    };
        //    await _userManager.CreateAsync(appuser, "JJadmin-2000");
        //    await _userManager.AddToRoleAsync(appuser, "SuperAdmin");
        //    return Content("Super Admin: Success!");
        //}
        #endregion
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                SurName = registerVM.SurName,
                UserName = registerVM.UserName,
                Email = registerVM.Email
            };
            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            result = await _userManager.AddToRoleAsync(appUser, "User");
            return RedirectToAction("index", "home", new { area = "" });
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
            AppUser appuser = await _userManager.FindByEmailAsync(login.Email);
            if (appuser == null)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(login);
            }
            if (appuser.IsAdmin)
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(login);

            }
            if (!await _userManager.CheckPasswordAsync(appuser, login.Password))
            {
                ModelState.AddModelError("", "Email or password is incorrect");
                return View(login);
            }
            await _signInManager.SignInAsync(appuser, login.RememberMe);
            return RedirectToAction("index", "home");

        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);
                if (user != null )
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var passwordResetLink = Url.Action("ResetPassword", "Account",
                    new { email = forgotPasswordVM.Email, token = token }, Request.Scheme);
                    _logger.Log(LogLevel.Warning, passwordResetLink);
                    return Redirect(passwordResetLink);
                }
                else
                {
                    ModelState.AddModelError("", "Email is incorrect");
                    return View();
                }
            }
            
            return View(forgotPasswordVM);
        }
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid reset password token");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
                if (appUser != null)
                {
                    IdentityResult result = await _userManager.ResetPasswordAsync(appUser, resetPasswordVM.Token, resetPasswordVM.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordSuccessfully");
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View();
                    }
                    
                }
            }
            return View();
        }

    }
}
