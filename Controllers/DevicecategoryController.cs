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
    public class DevicecategoryController : Controller
    {
        private readonly IoTHUBContext _context;

        public DevicecategoryController(IoTHUBContext context)
        {
            _context = context;
        }

        // GET: Devicecategory
        public async Task<IActionResult> Index(string DeviceCatsearch)
        {

            ViewData["GetDeviceCatDetails"] = DeviceCatsearch;

            var devicecatquery = from x in _context.DevicecategoryTbl select x;
            if (!String.IsNullOrEmpty(DeviceCatsearch))
            {
                devicecatquery = devicecatquery.Where(x => x.Devicecatname.Contains(DeviceCatsearch));
            }
            return View(await devicecatquery.AsNoTracking().ToListAsync());

        }

        // GET: Devicecategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicecategoryTbl = await _context.DevicecategoryTbl
                .FirstOrDefaultAsync(m => m.DevicecatId == id);
            if (devicecategoryTbl == null)
            {
                return NotFound();
            }

            return View(devicecategoryTbl);
        }

        // GET: Devicecategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devicecategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DevicecatId,Devicecatname,Createddate")] DevicecategoryTbl devicecategoryTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devicecategoryTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(devicecategoryTbl);
        }

        // GET: Devicecategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicecategoryTbl = await _context.DevicecategoryTbl.FindAsync(id);
            if (devicecategoryTbl == null)
            {
                return NotFound();
            }
            return View(devicecategoryTbl);
        }

        // POST: Devicecategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevicecatId,Devicecatname,Createddate")] DevicecategoryTbl devicecategoryTbl)
        {
            if (id != devicecategoryTbl.DevicecatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devicecategoryTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevicecategoryTblExists(devicecategoryTbl.DevicecatId))
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
            return View(devicecategoryTbl);
        }

        // GET: Devicecategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicecategoryTbl = await _context.DevicecategoryTbl
                .FirstOrDefaultAsync(m => m.DevicecatId == id);
            if (devicecategoryTbl == null)
            {
                return NotFound();
            }

            return View(devicecategoryTbl);
        }

        // POST: Devicecategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devicecategoryTbl = await _context.DevicecategoryTbl.FindAsync(id);
            _context.DevicecategoryTbl.Remove(devicecategoryTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevicecategoryTblExists(int id)
        {
            return _context.DevicecategoryTbl.Any(e => e.DevicecatId == id);
        }
    }
}
