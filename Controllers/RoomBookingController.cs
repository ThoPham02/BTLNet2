using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{

    public class RoomBookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomBookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RoomBooking
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoomBooking.ToListAsync());
        }

        // GET: RoomBooking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBooking = await _context.RoomBooking
                .FirstOrDefaultAsync(m => m.RoomBookingID == id);
            if (roomBooking == null)
            {
                return NotFound();
            }

            return View(roomBooking);
        }

        // GET: RoomBooking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoomBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomBookingID,RoomID,BookingID,TimeStart,TimeEnd")] RoomBooking roomBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomBooking);
        }

        // GET: RoomBooking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBooking = await _context.RoomBooking.FindAsync(id);
            if (roomBooking == null)
            {
                return NotFound();
            }
            return View(roomBooking);
        }

        // POST: RoomBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomBookingID,RoomID,BookingID,TimeStart,TimeEnd")] RoomBooking roomBooking)
        {
            if (id != roomBooking.RoomBookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomBookingExists(roomBooking.RoomBookingID))
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
            return View(roomBooking);
        }

        // GET: RoomBooking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomBooking = await _context.RoomBooking
                .FirstOrDefaultAsync(m => m.RoomBookingID == id);
            if (roomBooking == null)
            {
                return NotFound();
            }

            return View(roomBooking);
        }

        // POST: RoomBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomBooking = await _context.RoomBooking.FindAsync(id);
            if (roomBooking != null)
            {
                _context.RoomBooking.Remove(roomBooking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomBookingExists(int id)
        {
            return _context.RoomBooking.Any(e => e.RoomBookingID == id);
        }
    }
}
