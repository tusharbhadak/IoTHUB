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
    public class HelpSupportController : Controller
    {
        private readonly IoTHUBContext _context;

        public HelpSupportController(IoTHUBContext context)
        {
            _context = context;
        }

        // GET: HelpSupport
        public async Task<IActionResult> Index()
        {
            var ioTHUBContext = _context.HelpSupportTbl.Include(h => h.Comptype).Include(h => h.User);
            return View(await ioTHUBContext.ToListAsync());
        }

        // GET: HelpSupport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpSupportTbl = await _context.HelpSupportTbl
                .Include(h => h.Comptype)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.HelpId == id);
            if (helpSupportTbl == null)
            {
                return NotFound();
            }

            return View(helpSupportTbl);
        }

        // GET: HelpSupport/Create
        public IActionResult Create()
        {
            ViewData["ComptypeId"] = new SelectList(_context.ComplaintypeTbl, "ComptypeId", "CompType");
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username");
            return View();
        }

        // POST: HelpSupport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HelpId,UserId,ComptypeId,Createddate")] HelpSupportTbl helpSupportTbl)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(helpSupportTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComptypeId"] = new SelectList(_context.ComplaintypeTbl, "ComptypeId", "CompType", helpSupportTbl.ComptypeId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", helpSupportTbl.UserId);
            return View(helpSupportTbl);
        }

        // GET: HelpSupport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpSupportTbl = await _context.HelpSupportTbl.FindAsync(id);
            if (helpSupportTbl == null)
            {
                return NotFound();
            }
            ViewData["ComptypeId"] = new SelectList(_context.ComplaintypeTbl, "ComptypeId", "CompType", helpSupportTbl.ComptypeId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", helpSupportTbl.UserId);
            return View(helpSupportTbl);
        }

        // POST: HelpSupport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HelpId,UserId,ComptypeId,Createddate")] HelpSupportTbl helpSupportTbl)
        {
            if (id != helpSupportTbl.HelpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helpSupportTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelpSupportTblExists(helpSupportTbl.HelpId))
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
            ViewData["ComptypeId"] = new SelectList(_context.ComplaintypeTbl, "ComptypeId", "CompType", helpSupportTbl.ComptypeId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", helpSupportTbl.UserId);
            return View(helpSupportTbl);
        }

        // GET: HelpSupport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helpSupportTbl = await _context.HelpSupportTbl
                .Include(h => h.Comptype)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.HelpId == id);
            if (helpSupportTbl == null)
            {
                return NotFound();
            }

            return View(helpSupportTbl);
        }

        // POST: HelpSupport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helpSupportTbl = await _context.HelpSupportTbl.FindAsync(id);
            _context.HelpSupportTbl.Remove(helpSupportTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelpSupportTblExists(int id)
        {
            return _context.HelpSupportTbl.Any(e => e.HelpId == id);
        }
    }
}
