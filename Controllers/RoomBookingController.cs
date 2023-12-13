// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using System.Diagnostics;
// using HotelManagement.Data;
// using HotelManagement.Models;

// using HotelManagement.Models;

// namespace HotelManagement.Controllers;

// public class RoomBookingController : Controller
// {
//     private readonly ILogger<RoomBookingController> _logger;
//     private readonly ApplicationDbContext _context;
//     public RoomBookingController(ILogger<RoomBookingController> logger, ApplicationDbContext context)
//     {
//         _logger = logger;
//         _context = context;

//     }
//     public IActionResult Index()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }

//     // Action cho trang A - Xử lý tìm kiếm và chuyển hướng đến trang B
//     [HttpPost]
//     public IActionResult SearchRooms(DateTime startTime, DateTime endTime)
//     {
//         return RedirectToAction("Tobook", "Home");
//     }

//     // Action cho trang B - Hiển thị danh sách phòng còn trống
//     public IActionResult DisplayAvailableRooms(DateTime startTime, DateTime endTime)
//     {
//         var startTimeInt = startTime.Ticks; // Chuyển đổi thành số nguyên
//         var endTimeInt = endTime.Ticks; // Chuyển đổi thành số nguyên
//         var availableRooms = _context.Room
//             .Where(room =>
//                 room.State == 1 &&
//                 !_context.RoomBooking.Any(rb =>
//                     rb.RoomID == room.RoomID &&
//                     rb.Status == 5 &&
//                     startTimeInt < rb.TimeEnd && endTimeInt > rb.TimeStart))
//             .ToList();

//         // Lưu danh sách phòng vào ViewBag
//         ViewBag.AvailableRooms = availableRooms;

//         // Chuyển hướng đến action "ToBook" trong controller "Home"
//         return RedirectToAction("ToBook", "Home");
//     }


//     // GET: RoomBooking/Create
//     public IActionResult Create()
//     {
//         return View();
//     }

//     // POST: RoomBooking/Create
//     // To protect from overposting attacks, enable the specific properties you want to bind to.
//     // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//     [HttpPost]
//     [ValidateAntiForgeryToken]
//     public async Task<IActionResult> Create([Bind("RoomBookingID,RoomID,TimeStart,TimeEnd,Status")] RoomBooking roomBooking)
//     {
//         if (ModelState.IsValid)
//         {
//             _context.Add(roomBooking);
//             await _context.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }
//         return View(roomBooking);
//     }
// }
