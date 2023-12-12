using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

using HotelManagement.Models;

namespace HotelManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;

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
}
