using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IoTHUB_v1._0.Models;

namespace IoTHUB_v1._0.Controllers
{
    public class RfidController : Controller
    {
        private readonly IoTHUBContext _context;

        public RfidController(IoTHUBContext context)
        {
            _context = context;
        }

        // GET: Rfid
        public async Task<IActionResult> Index()
        {
            var ioTHUBContext = _context.RfidTbl.Include(r => r.User);
            return View(await ioTHUBContext.ToListAsync());
        }

        // GET: Rfid/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rfidTbl = await _context.RfidTbl
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RfidId == id);
            if (rfidTbl == null)
            {
                return NotFound();
            }

            return View(rfidTbl);
        }

        // GET: Rfid/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username");
            return View();
        }

        // POST: Rfid/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RfidId,UserId,Rfid,Createddate,Isactive")] RfidTbl rfidTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rfidTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", rfidTbl.UserId);
            return View(rfidTbl);
        }

        // GET: Rfid/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rfidTbl = await _context.RfidTbl.FindAsync(id);
            if (rfidTbl == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", rfidTbl.UserId);
            return View(rfidTbl);
        }

        // POST: Rfid/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RfidId,UserId,Rfid,Createddate,Isactive")] RfidTbl rfidTbl)
        {
            if (id != rfidTbl.RfidId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rfidTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RfidTblExists(rfidTbl.RfidId))
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
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", rfidTbl.UserId);
            return View(rfidTbl);
        }

        // GET: Rfid/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rfidTbl = await _context.RfidTbl
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RfidId == id);
            if (rfidTbl == null)
            {
                return NotFound();
            }

            return View(rfidTbl);
        }

        // POST: Rfid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rfidTbl = await _context.RfidTbl.FindAsync(id);
            _context.RfidTbl.Remove(rfidTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RfidTblExists(int id)
        {
            return _context.RfidTbl.Any(e => e.RfidId == id);
        }
    }
}
