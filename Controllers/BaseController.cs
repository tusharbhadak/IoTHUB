using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTHUB_v1._0.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Mediapath = HttpContext.Session.GetString("Mediapath");
            return View();
        }
    }
}
