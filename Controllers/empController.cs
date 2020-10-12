using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IoTHUB_v1._0.library;
using IoTHUB_v1._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IoTHUB_v1._0.Controllers
{

    public class EmpController : Controller
    {
        private readonly ILogger<EmpController> _logger;
        private SerialPortConnector _serialPortConnector;

        public EmpController(ILogger<EmpController> logger)
        {
            _logger = logger;
            _serialPortConnector = new SerialPortConnector();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Send(string command, string roomNumber)
        {
            try
            {
                _serialPortConnector.Send(command + roomNumber);
                return Ok("sent");
            }
            catch (Exception)
            {
                return BadRequest("failed");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}