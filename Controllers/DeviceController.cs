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
    public class DeviceController : Controller
    {
        private readonly IoTHUBContext _context;

        public DeviceController(IoTHUBContext context)
        {
            _context = context;
        }

        

        // GET: Device
        public async Task<IActionResult> Index(string Devicesearch)
        {
            ViewData["GetDeviceDetails"] = Devicesearch;
            
            var devicequery = from x in _context.DeviceTbl select x;
            if(!String.IsNullOrEmpty(Devicesearch))
            {
                devicequery = devicequery.Where(x => x.Devicename.Contains(Devicesearch));
            }
            return View(await devicequery.AsNoTracking().ToListAsync());
                
           
        }

       

        // GET: Device/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceTbl = await _context.DeviceTbl
                .Include(d => d.Devicecat)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            if (deviceTbl == null)
            {
                return NotFound();
            }

            return View(deviceTbl);
        }

        // GET: Device/Create
        public IActionResult Create()
        {
            ViewData["DevicecatId"] = new SelectList(_context.DevicecategoryTbl, "DevicecatId", "Devicecatname");
            return View();
        }

        // POST: Device/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DevicecatId,Devicename,Description,Createddate,Updateddate")] DeviceTbl deviceTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deviceTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DevicecatId"] = new SelectList(_context.DevicecategoryTbl, "DevicecatId", "Devicecatname", deviceTbl.DevicecatId);
            return View(deviceTbl);
        }

        // GET: Device/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceTbl = await _context.DeviceTbl.FindAsync(id);
            if (deviceTbl == null)
            {
                return NotFound();
            }
            ViewData["DevicecatId"] = new SelectList(_context.DevicecategoryTbl, "DevicecatId", "Devicecatname", deviceTbl.DevicecatId);
            return View(deviceTbl);
        }

        // POST: Device/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeviceId,DevicecatId,Devicename,Description,Createddate,Updateddate")] DeviceTbl deviceTbl)
        {
            if (id != deviceTbl.DeviceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deviceTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceTblExists(deviceTbl.DeviceId))
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
            ViewData["DevicecatId"] = new SelectList(_context.DevicecategoryTbl, "DevicecatId", "Devicecatname", deviceTbl.DevicecatId);
            return View(deviceTbl);
        }

        // GET: Device/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deviceTbl = await _context.DeviceTbl
                .Include(d => d.Devicecat)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            if (deviceTbl == null)
            {
                return NotFound();
            }

            return View(deviceTbl);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deviceTbl = await _context.DeviceTbl.FindAsync(id);
            _context.DeviceTbl.Remove(deviceTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceTblExists(int id)
        {
            return _context.DeviceTbl.Any(e => e.DeviceId == id);
        }
    }
}
