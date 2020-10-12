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
    public class RegistereddevicesController : Controller
    {
        private readonly IoTHUBContext _context;

        public RegistereddevicesController(IoTHUBContext context)
        {
            _context = context;
        }

        // GET: Registereddevices
        public async Task<IActionResult> Index()
        {
            var ioTHUBContext = _context.RegistereddevicesTbl.Include(r => r.Device).Include(r => r.User);
            return View(await ioTHUBContext.ToListAsync());
        }

        // GET: Registereddevices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registereddevicesTbl = await _context.RegistereddevicesTbl
                .Include(r => r.Device)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RegdevId == id);
            if (registereddevicesTbl == null)
            {
                return NotFound();
            }

            return View(registereddevicesTbl);
        }

        // GET: Registereddevices/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceTbl, "DeviceId", "Devicename");
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username");
            return View();
        }

        // POST: Registereddevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegdevId,UserId,DeviceId,Createddate,Updateddate")] RegistereddevicesTbl registereddevicesTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registereddevicesTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceTbl, "DeviceId", "Devicename", registereddevicesTbl.DeviceId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", registereddevicesTbl.UserId);
            return View(registereddevicesTbl);
        }

        // GET: Registereddevices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registereddevicesTbl = await _context.RegistereddevicesTbl.FindAsync(id);
            if (registereddevicesTbl == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceTbl, "DeviceId", "Devicename", registereddevicesTbl.DeviceId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", registereddevicesTbl.UserId);
            return View(registereddevicesTbl);
        }

        // POST: Registereddevices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegdevId,UserId,DeviceId,Createddate,Updateddate")] RegistereddevicesTbl registereddevicesTbl)
        {
            if (id != registereddevicesTbl.RegdevId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registereddevicesTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistereddevicesTblExists(registereddevicesTbl.RegdevId))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceTbl, "DeviceId", "Devicename", registereddevicesTbl.DeviceId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", registereddevicesTbl.UserId);
            return View(registereddevicesTbl);
        }

        // GET: Registereddevices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registereddevicesTbl = await _context.RegistereddevicesTbl
                .Include(r => r.Device)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RegdevId == id);
            if (registereddevicesTbl == null)
            {
                return NotFound();
            }

            return View(registereddevicesTbl);
        }

        // POST: Registereddevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registereddevicesTbl = await _context.RegistereddevicesTbl.FindAsync(id);
            _context.RegistereddevicesTbl.Remove(registereddevicesTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistereddevicesTblExists(int id)
        {
            return _context.RegistereddevicesTbl.Any(e => e.RegdevId == id);
        }
    }
}
