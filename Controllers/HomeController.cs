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
        return View();
    }
    [HttpGet]
    public IActionResult DisplayAvailableRooms(DateTime startTime, DateTime endTime)
    {
        var startTimeInt = startTime.Ticks;
        var endTimeInt = endTime.Ticks;
        TempData["timeStart"] = startTime;
        TempData["timeEnd"] = endTime;
        var availableRooms = _context.Room
            .Where(room =>
                (room.State == Constants.TRANG_THAI_PHONG_TRONG &&
                !_context.RoomBooking.Any(rb =>
                    rb.RoomID == room.RoomID &&
                    (rb.Status == Constants.TRANG_THAI_DAT_PHONG_CHO_DUYET ||
                    rb.Status == Constants.TRANG_THAI_DAT_PHONG_DA_DUYET ||
                    rb.Status == Constants.TRANG_THAI_DAT_PHONG_DANG_SU_DUNG) &&
                    startTimeInt < rb.TimeEnd && endTimeInt > rb.TimeStart)))
             .Select(room => new
             {
                 Room = room,
                 RoomType = _context.RoomType.FirstOrDefault(rt => rt.RoomTypeID == room.RoomTypeID)
             })
        .ToList<object>();
        return View("ToBook", availableRooms);
    }
    public IActionResult BookingDetail(int roomId)
    {
        var model = (from roomCus in _context.RoomType
                     select new BookingDetailViews
                     {
                         RoomTypeID = roomCus.RoomTypeID,
                         RoomType = roomCus.TypeName,
                         Price = roomCus.Price,
                         Quantity = 1
                     }).FirstOrDefault();

        return View(model);
    }

    public IActionResult Confirm(BookingDetailViews model)
    {
        // create customer

        // create booking

        return View();
    }
}
