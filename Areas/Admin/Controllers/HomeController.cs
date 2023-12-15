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

namespace HotelManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = Constants.ROLE_ADMIN)]
    [Area("Admin")]
    [Route("/Home/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(
            ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: /Admin/Index
        [HttpGet("/admin")]
        public IActionResult Index(string customer, string room, string status)
        {
            var bookings = (from roomBooking in _context.RoomBooking
                            join roomCus in _context.Room on roomBooking.RoomID equals roomCus.RoomID
                            join booking in _context.Booking on roomBooking.BookingID equals booking.BookingID
                            join cus in _context.Customers on booking.CustomerID equals cus.CustomerID
                            select new RoomBookingViews
                            {
                                RoomBookingID = roomBooking.RoomBookingID,
                                RoomName = roomCus.Name,
                                TimeStart = booking.TimeStart,
                                TimeEnd = booking.TimeEnd,
                                Customer = cus.FullName,
                                PhoneNumber = cus.Phone,
                                BookingStatus = roomBooking.Status,
                            }).ToList();

            return View(bookings);
        }

        [HttpGet("/admin/create")]
        public IActionResult Create()
        {
            var model = new List<RoomBookingViews>();

            return View(model);
        }
    }
}