using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data;
using Newtonsoft.Json;
using X.PagedList;
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
    public IActionResult DisplayAvailableRooms(DateTime startTime, DateTime endTime, int page = 1, int pageSize = 3)
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
        var pagedList = availableRooms.ToPagedList(page, pageSize);
        return View(pagedList);
    }
    public IActionResult Booking()
    {
        return View();
    }
    public IActionResult BookingDetail()
    {
        var bookingDetailsJson = TempData["BookingDetails"] as string;
        if (bookingDetailsJson != null)
        {
            var bookingDetails = JsonConvert.DeserializeObject<List<BookingDetail>>(bookingDetailsJson);
            return View(bookingDetails);
        }
        else
        {
            return View();
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddRoom(int idRoom)
    {
        RoomType roomType = await _context.RoomType.FindAsync(idRoom);

        // Lấy danh sách chi tiết đặt phòng từ cơ sở dữ liệu
        List<BookingDetail> bookingDetails = await _context.BookingDetail
            .Where(b => b.RoomTypeID == idRoom)
            .ToListAsync();

        BookingDetail bkDetail = bookingDetails.FirstOrDefault();
        Console.WriteLine($"tttttt: {bkDetail}");
        if (bkDetail == null)
        {
            // Nếu không có chi tiết đặt phòng, thêm một chi tiết mới
            var newBookingDetail = new BookingDetail
            {
                RoomTypeID = idRoom,
                Quantity = 1,
            };

            _context.BookingDetail.Add(newBookingDetail);
        }
        else
        {
            // Nếu chi tiết đặt phòng đã tồn tại, tăng số lượng lên 1
            bkDetail.Quantity += 1;
        }

        await _context.SaveChangesAsync();

        // Chuyển hướng đến action BookingDetail để hiển thị thông tin
        return RedirectToAction("BookingDetail", "Home");
    }
}
