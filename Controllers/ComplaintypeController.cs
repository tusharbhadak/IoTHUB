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
    public class ComplaintypeController : Controller
    {
        private readonly IoTHUBContext _context;

        public ComplaintypeController(IoTHUBContext context)
        {
            _context = context;
        }

        // GET: Complaintype
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComplaintypeTbl.ToListAsync());
        }

        // GET: Complaintype/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaintypeTbl = await _context.ComplaintypeTbl
                .FirstOrDefaultAsync(m => m.ComptypeId == id);
            if (complaintypeTbl == null)
            {
                return NotFound();
            }

            return View(complaintypeTbl);
        }

        // GET: Complaintype/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Complaintype/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComptypeId,CompType,Createddate")] ComplaintypeTbl complaintypeTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(complaintypeTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complaintypeTbl);
        }

        // GET: Complaintype/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaintypeTbl = await _context.ComplaintypeTbl.FindAsync(id);
            if (complaintypeTbl == null)
            {
                return NotFound();
            }
            return View(complaintypeTbl);
        }

        // POST: Complaintype/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComptypeId,CompType,Createddate")] ComplaintypeTbl complaintypeTbl)
        {
            if (id != complaintypeTbl.ComptypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complaintypeTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplaintypeTblExists(complaintypeTbl.ComptypeId))
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
            return View(complaintypeTbl);
        }

        // GET: Complaintype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaintypeTbl = await _context.ComplaintypeTbl
                .FirstOrDefaultAsync(m => m.ComptypeId == id);
            if (complaintypeTbl == null)
            {
                return NotFound();
            }

            return View(complaintypeTbl);
        }

        // POST: Complaintype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complaintypeTbl = await _context.ComplaintypeTbl.FindAsync(id);
            _context.ComplaintypeTbl.Remove(complaintypeTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplaintypeTblExists(int id)
        {
            return _context.ComplaintypeTbl.Any(e => e.ComptypeId == id);
        }
    }
}
