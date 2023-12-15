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

namespace HotelManagement.Areas.Admin.Controllers {

    [Authorize(Roles = Constants.ROLE_ADMIN)]
    [Area("Admin")]
    [Route("/Home/[action]")]
    public class BookingController : Controller {
         private readonly ILogger<BookingController> _logger;
        private readonly ICombinedService _combinedService;
        public BookingController(
            ILogger<BookingController> logger)
        {
            _logger = logger;
        }

        // GET: /Admin/Index
        [HttpGet("/admin/booking")]
        public IActionResult Index(string customer, string room, string status)
        {
            // var model = _combinedService.GetData(customer, room, status);
            var model = new List<RoomBookingViews>();

            return View(model);
        }
    }
}