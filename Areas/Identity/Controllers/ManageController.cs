// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Areas.Identity.Models.IndexViewModel;
using HotelManagement.ExtendMethods;
using HotelManagement.Models;
using HotelManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelManagement.Areas.Identity.Controllers
{

    [Authorize]
    [Area("Identity")]
    [Route("/Manage/[action]")]
    public class ManageController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<ManageController> _logger;

        public ManageController(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ILogger<ManageController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        //
        // GET: /Manage/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var model = new IndexViewModel()
            {
                FullName = user.FullName,
                Address = user.Address,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            return View(model);
        }
        private Task<User> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(IndexViewModel model)
        {
            var user = await GetCurrentUserAsync();
            _logger.LogInformation("Cập nhật thông tin");

            user.Address = model.Address;
            user.FullName = model.FullName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            _logger.LogInformation("Cập nhật thông tin 1");

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("Cập nhật thông tin 2");

            return View(model);
        }
    }
}
