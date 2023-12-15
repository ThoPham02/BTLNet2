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
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly ApplicationDbContext _context;
        public BookingController(
            ILogger<BookingController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: /Admin/Index
        [HttpGet("/admin/booking")]
        public IActionResult Index(string customer, string room, int status)
        {
            var bookings = (from booking in _context.Booking
                            join cus in _context.Customers on booking.CustomerID equals cus.CustomerID
                            // join bookingDetail in _context.BookingDetail on booking.BookingID equals bookingDetail.BookingID into details
                            select new BookingViews
                            {
                                BookingID = booking.BookingID,
                                Name = cus.FullName,
                                PhoneNumber = cus.Phone,
                                TimeStart = booking.TimeStart,
                                TimeEnd = booking.TimeEnd,
                            }).ToList();

            return View(bookings);
        }
    }
}