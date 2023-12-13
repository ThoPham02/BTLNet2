// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HotelManagement.Areas.Identity.Models.AccountViewModels;
using HotelManagement.ExtendMethods;
using HotelManagement.Models;
using HotelManagement.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace HotelManagement.Areas.Identity.Controllers
{
    [Authorize]
    [Area("Identity")]
    [Route("Account/[action]")]
    public class AccountController : Controller
    {
        // ... (existing code)

        [HttpGet("Login")]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserNameOrEmail, model.Password, model.RememberMe, lockoutOnFailure: true);

                if ((!result.Succeeded) && HotelManagementUtilities.IsValidEmail(model.UserNameOrEmail))
                {
                    var user = await _userManager.FindByEmailAsync(model.UserNameOrEmail);
                    if (user != null)
                    {
                        result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: true);
                    }
                }

                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Không đăng nhập được.");
                }
            }

            return View(model);
        }

        [HttpPost("LogOff")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User đăng xuất");
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpGet("Register")]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            // returnUrl ??= Url.Content("~/");
            // ViewData["ReturnUrl"] = returnUrl;

            // if (ModelState.IsValid)
            // {
            //     var user = await _userManager.FindByEmailAsync(model.Email);

            //     if (user == null)
            //     {
            //         user = new User
            //         {
            //             FullName = "",
            //             Address = "",
            //             UserName = model.UserName,
            //             Email = model.Email,
            //             EmailConfirmed = true,
            //         };

            //         await _userManager.CreateAsync(user, model.Password);
            //         await _userManager.AddToRoleAsync(user, Constants.ROLE_USER);
            //         await _signInManager.SignInAsync(user, false);

            //         return RedirectToAction("Index");
            //     }
            // }

            // return View(model);
        }
    }
}