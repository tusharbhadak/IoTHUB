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
    public class FeedbackController : Controller
    {
        private readonly IoTHUBContext _context;

        public FeedbackController(IoTHUBContext context)
        {
            _context = context;
        }

        // GET: Feedback
        public async Task<IActionResult> Index()
        {
            var ioTHUBContext = _context.FeedbackTbl.Include(f => f.User);
            return View(await ioTHUBContext.ToListAsync());
        }

        // GET: Feedback/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackTbl = await _context.FeedbackTbl
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedbackTbl == null)
            {
                return NotFound();
            }

            return View(feedbackTbl);
        }

        // GET: Feedback/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username");
            return View();
        }

        // POST: Feedback/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Feedback,Createddate")] FeedbackTbl feedbackTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedbackTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", feedbackTbl.UserId);
            return View(feedbackTbl);
        }

        // GET: Feedback/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackTbl = await _context.FeedbackTbl.FindAsync(id);
            if (feedbackTbl == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", feedbackTbl.UserId);
            return View(feedbackTbl);
        }

        // POST: Feedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Feedback,Createddate")] FeedbackTbl feedbackTbl)
        {
            if (id != feedbackTbl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedbackTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackTblExists(feedbackTbl.Id))
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
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", feedbackTbl.UserId);
            return View(feedbackTbl);
        }

        // GET: Feedback/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackTbl = await _context.FeedbackTbl
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedbackTbl == null)
            {
                return NotFound();
            }

            return View(feedbackTbl);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedbackTbl = await _context.FeedbackTbl.FindAsync(id);
            _context.FeedbackTbl.Remove(feedbackTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackTblExists(int id)
        {
            return _context.FeedbackTbl.Any(e => e.Id == id);
        }
    }
}
