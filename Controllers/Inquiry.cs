using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTHUB_v1._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTHUB_v1._0.Controllers
{
    public class Inquiry : Controller
    {
        private readonly IoTHUBContext _context;
        public Inquiry(IoTHUBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ContactformTbl.ToList());
        }
    }
}
