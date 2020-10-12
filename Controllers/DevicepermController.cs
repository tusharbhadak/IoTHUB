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
    public class DevicepermController : Controller
    {
        private readonly IoTHUBContext _context;

        public DevicepermController(IoTHUBContext context)
        {
            _context = context;
        }

        // GET: Deviceperm
        public async Task<IActionResult> Index()
        {
            var ioTHUBContext = _context.DevicepermId.Include(d => d.Device).Include(d => d.User);
            return View(await ioTHUBContext.ToListAsync());
        }

        // GET: Deviceperm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicepermId = await _context.DevicepermId
                .Include(d => d.Device)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DevicepermId1 == id);
            if (devicepermId == null)
            {
                return NotFound();
            }

            return View(devicepermId);
        }

        // GET: Deviceperm/Create
        public IActionResult Create()
        {
            ViewData["DeviceId"] = new SelectList(_context.DeviceTbl, "DeviceId", "Devicename");
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username");
            return View();
        }

        // POST: Deviceperm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DevicepermId1,UserId,DeviceId,Createddate,Updateddate")] DevicepermId devicepermId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devicepermId);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceTbl, "DeviceId", "Devicename", devicepermId.DeviceId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", devicepermId.UserId);
            return View(devicepermId);
        }

        // GET: Deviceperm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicepermId = await _context.DevicepermId.FindAsync(id);
            if (devicepermId == null)
            {
                return NotFound();
            }
            ViewData["DeviceId"] = new SelectList(_context.DeviceTbl, "DeviceId", "Devicename", devicepermId.DeviceId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", devicepermId.UserId);
            return View(devicepermId);
        }

        // POST: Deviceperm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevicepermId1,UserId,DeviceId,Createddate,Updateddate")] DevicepermId devicepermId)
        {
            if (id != devicepermId.DevicepermId1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devicepermId);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevicepermIdExists(devicepermId.DevicepermId1))
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
            ViewData["DeviceId"] = new SelectList(_context.DeviceTbl, "DeviceId", "Devicename", devicepermId.DeviceId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", devicepermId.UserId);
            return View(devicepermId);
        }

        // GET: Deviceperm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicepermId = await _context.DevicepermId
                .Include(d => d.Device)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DevicepermId1 == id);
            if (devicepermId == null)
            {
                return NotFound();
            }

            return View(devicepermId);
        }

        // POST: Deviceperm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devicepermId = await _context.DevicepermId.FindAsync(id);
            _context.DevicepermId.Remove(devicepermId);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevicepermIdExists(int id)
        {
            return _context.DevicepermId.Any(e => e.DevicepermId1 == id);
        }
    }
}
