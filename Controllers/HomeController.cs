using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data;


namespace HotelManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult ToBook()
    {
        // Lấy danh sách phòng từ ViewBag
        var availableRooms = ViewBag.AvailableRooms as List<Room>;

        // Truyền danh sách phòng vào View
        return View(availableRooms);
    }
    public IActionResult DisplayAvailableRooms(DateTime startTime, DateTime endTime)
    {
        var startTimeInt = startTime.Ticks; // Chuyển đổi thành số nguyên
        var endTimeInt = endTime.Ticks; // Chuyển đổi thành số nguyên
        var availableRooms = _context.Room
            .Where(room =>
                room.State == 1 &&
                !_context.RoomBooking.Any(rb =>
                    rb.RoomID == room.RoomID &&
                    rb.Status == 5 &&
                    startTimeInt < rb.TimeEnd && endTimeInt > rb.TimeStart))
            .ToList();

       

        // Chuyển hướng đến action "ToBook" trong controller "Home"
        return View(availableRooms);
    }

}
