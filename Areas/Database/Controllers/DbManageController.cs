using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public string StatusMessage { get; set;}

        public DbManageController(ApplicationDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SeedDataAsync()
        {
            // Create Roles
            var rolenames = new List<string>(new string[] { "admin", "user"});
            foreach (var rolename in rolenames)
            {
                    await _roleManager.CreateAsync(new IdentityRole(rolename));
            }

            // admin, pass=admin123, admin@example.com
            var useradmin = await _userManager.FindByEmailAsync("admin2504@gmail.com");
            if (useradmin == null)
            {
                useradmin = new User()
                {
                    FullName = "",
                    Address = "",
                    UserName = "admin",
                    Email = "admin2504@gmail.com",
                    EmailConfirmed = true,
                };

                await _userManager.CreateAsync(useradmin, "admin2504");
                await _userManager.AddToRoleAsync(useradmin, Constants.ROLE_ADMIN);
                await _signInManager.SignInAsync(useradmin, false);

                return RedirectToAction("Index");
                
            }
            else 
            {
                var user = await _userManager.GetUserAsync(this.User);
                if (user == null) return this.Forbid();
                var roles = await _userManager.GetRolesAsync(user);

                if (!roles.Any(r => r == Constants.ROLE_ADMIN))
                {
                    return this.Forbid();
                }

            }

            StatusMessage = "Tạo Admin Account thành công!!";
            return RedirectToAction("Index");
        }
    }
}