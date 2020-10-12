using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IoTHUB_v1._0.Models;

namespace IoTHUB_v1._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Contact : ControllerBase
    {
        private readonly IoTHUBContext _context;

        public Contact(IoTHUBContext context)
        {
            _context = context;
        }

        //GET: api/Contact/5

        [HttpPost]
        [Route("GetInquiry")]
        public dynamic Inquiry([FromForm]ContactformTbl contactformTbl)
        {
            try
            {
                contactformTbl.Createddate = DateTime.UtcNow;
                _context.Add(contactformTbl);
                _context.SaveChanges();
                return "Your Inquiry is Successfull, IoTHUB will revert back you soon.";
            }
            catch
            {
                return "Something went wrong. Please try again";
            }
        }
       
    }

}
