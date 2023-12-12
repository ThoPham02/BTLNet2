using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

using HotelManagement.Models;

namespace HotelManagement.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // private readonly ApplicationDbContext _context;

    // Chỉ giữ lại constructor này
    public HomeController(ILogger<HomeController> logger/*, ApplicationDbContext context*/)
    {
        _logger = logger;
        // _context = context;
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

    // GET: Room
    public async Task<IActionResult> ToBook()
    {
        return View(/*await _context.Room.ToListAsync()*/);
    }
}
