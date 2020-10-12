using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IoTHUB_v1._0.Models;
using Microsoft.AspNetCore.Http;

namespace IoTHUB_v1._0.Controllers
{
    public class RequestserviceController : Controller
    {
        private readonly IoTHUBContext _context;
        

        public RequestserviceController(IoTHUBContext context)
        {
            _context = context;
           
        }

        // GET: Requestservice
        public async Task<IActionResult> Index()
        {
            var ioTHUBContext = _context.RequestserviceTbl.Include(r => r.Service).Include(r => r.User);
            return View(await ioTHUBContext.ToListAsync());
           
        }
        
        // GET: Requestservice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestserviceTbl = await _context.RequestserviceTbl
                .Include(r => r.Service)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (requestserviceTbl == null)
            {
                return NotFound();
            }

            return View(requestserviceTbl);
        }

        // GET: Requestservice/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename");
            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId,Username");
            return View();
        }

        // POST: Requestservice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequestserviceTbl requestserviceTbl)
        {
             
            if (ModelState.IsValid)
            {
                RequestserviceTbl Req = new RequestserviceTbl
                {
                    //UserId = HttpContext.Session.GetInt32("UserId"),
                    ServiceId = requestserviceTbl.ServiceId,
                    Createddate = requestserviceTbl.Createddate,
                    Requestdescription = requestserviceTbl.Requestdescription,
                };
                 _context.Add(Req);
                   await _context.SaveChangesAsync();
            }
        
            else
        {
            return View("Create");
        }

           ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename", requestserviceTbl.ServiceId);
            ViewData["UserId"] = HttpContext.Session.GetInt32("UserId,Username");
            return RedirectToAction("Create", "Requestservice");
        }

        // GET: Requestservice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestserviceTbl = await _context.RequestserviceTbl.FindAsync(id);
            if (requestserviceTbl == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename", requestserviceTbl.ServiceId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", requestserviceTbl.UserId);
            return View(requestserviceTbl);
        }

        // POST: Requestservice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestId,UserId,ServiceId,Createddate,Requestdescription")] RequestserviceTbl requestserviceTbl)
        {
            if (id != requestserviceTbl.RequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestserviceTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestserviceTblExists(requestserviceTbl.RequestId))
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
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename", requestserviceTbl.ServiceId);
            ViewData["UserId"] = new SelectList(_context.UserTbl, "UserId", "Username", requestserviceTbl.UserId);
            return View(requestserviceTbl);
        }

        // GET: Requestservice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestserviceTbl = await _context.RequestserviceTbl
                .Include(r => r.Service)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RequestId == id);
            if (requestserviceTbl == null)
            {
                return NotFound();
            }

            return View(requestserviceTbl);
        }

        // POST: Requestservice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestserviceTbl = await _context.RequestserviceTbl.FindAsync(id);
            _context.RequestserviceTbl.Remove(requestserviceTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestserviceTblExists(int id)
        {
            return _context.RequestserviceTbl.Any(e => e.RequestId == id);
        }
    }
}
