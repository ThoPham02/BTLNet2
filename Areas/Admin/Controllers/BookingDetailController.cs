using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data;
using HotelManagement.Models;
using Microsoft.AspNetCore.Authorization;


namespace HotelManagement.Areas.Admin.Controllers
{
    // [Authorize(Roles = Constants.ROLE_ADMIN)]
    [Area("Admin")]
    [Route("/BookingDetail/[action]")]
    public class BookingDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/BookingDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookingDetail.ToListAsync());
        }

        // GET: Admin/BookingDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingDetail = await _context.BookingDetail
                .FirstOrDefaultAsync(m => m.BookingDetailID == id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            return View(bookingDetail);
        }

        // GET: Admin/BookingDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BookingDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingDetailID,BookingID,RoomTypeID,Quantity,Price")] BookingDetail bookingDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingDetail);
        }

        // GET: Admin/BookingDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingDetail = await _context.BookingDetail.FindAsync(id);
            if (bookingDetail == null)
            {
                return NotFound();
            }
            return View(bookingDetail);
        }

        // POST: Admin/BookingDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingDetailID,BookingID,RoomTypeID,Quantity,Price")] BookingDetail bookingDetail)
        {
            if (id != bookingDetail.BookingDetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingDetailExists(bookingDetail.BookingDetailID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bookingDetail);
        }

        // GET: Admin/BookingDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingDetail = await _context.BookingDetail
                .FirstOrDefaultAsync(m => m.BookingDetailID == id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            return View(bookingDetail);
        }

        // POST: Admin/BookingDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingDetail = await _context.BookingDetail.FindAsync(id);
            if (bookingDetail != null)
            {
                _context.BookingDetail.Remove(bookingDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingDetailExists(int id)
        {
            return _context.BookingDetail.Any(e => e.BookingDetailID == id);
        }
    }
}
