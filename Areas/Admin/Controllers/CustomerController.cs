// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HotelManagement.Areas.Admin.Models;
using HotelManagement.ExtendMethods;
using HotelManagement.Models;
using HotelManagement.Data;
using HotelManagement.Services;
using HotelManagement.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using X.PagedList;
namespace HotelManagement.Areas.Admin.Controllers {

    [Authorize(Roles = Constants.ROLE_ADMIN)]
    [Area("Admin")]
    [Route("/Home/[action]")]
    public class CustomerController : Controller {
        private readonly ILogger<CustomerController> _logger;
        private readonly ApplicationDbContext _context;
        public CustomerController(
            ILogger<CustomerController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: /Admin/Index
        [HttpGet("/admin/customer")]
        public IActionResult Index(string customer, string room, string status, int? page = null)
        {
            var model = (from cus in _context.Customers
                         select new CustomerViews
                         {
                             CustomerID = cus.CustomerID,
                             CustomerName = cus.FullName,
                             PhoneNumber = cus.Phone,
                             Email = cus.Email
                         }).ToList();
                         var models = model.ToPagedList(page ?? 1, 5);
            return View(models);
        }
    }
}