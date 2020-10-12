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
    public class ServiceController : Controller
    {
        private readonly IoTHUBContext _context;

        public ServiceController(IoTHUBContext context)
        {
            _context = context;
        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceTbl.ToListAsync());
        }

        // GET: Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTbl = await _context.ServiceTbl
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (serviceTbl == null)
            {
                return NotFound();
            }

            return View(serviceTbl);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,Servicename,Createddate")] ServiceTbl serviceTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceTbl);
        }

        // GET: Service/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTbl = await _context.ServiceTbl.FindAsync(id);
            if (serviceTbl == null)
            {
                return NotFound();
            }
            return View(serviceTbl);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,Servicename,Createddate")] ServiceTbl serviceTbl)
        {
            if (id != serviceTbl.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceTblExists(serviceTbl.ServiceId))
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
            return View(serviceTbl);
        }

        // GET: Service/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceTbl = await _context.ServiceTbl
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (serviceTbl == null)
            {
                return NotFound();
            }

            return View(serviceTbl);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceTbl = await _context.ServiceTbl.FindAsync(id);
            _context.ServiceTbl.Remove(serviceTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceTblExists(int id)
        {
            return _context.ServiceTbl.Any(e => e.ServiceId == id);
        }
    }
}
