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
    
    [HttpGet]
    public IActionResult DisplayAvailableRooms(DateTime startTime, DateTime endTime)
    {
        var startTimeInt = startTime.Ticks;
        var endTimeInt = endTime.Ticks;
        Console.WriteLine($"StartTime: {startTime}, EndTime: {endTime}");
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
        
        return View(availableRooms);
    }
    public IActionResult Booking()
    {
        return View();
    }

    public IActionResult BookingDetail(int roomId)
    {
        // Lấy thông tin chi tiết phòng từ cơ sở dữ liệu
        var roomDetail = _context.Room
            .Where(room => room.RoomID == roomId)
            .Select(room => new
            {
                Room = room,
                RoomType = _context.RoomType.FirstOrDefault(rt => rt.RoomTypeID == room.RoomTypeID)
            })
            .FirstOrDefault();

        if (roomDetail == null)
        {
            // Xử lý khi không tìm thấy phòng
            return View("BookingDetail", null);
        }

        return View(roomDetail);
    }
}
