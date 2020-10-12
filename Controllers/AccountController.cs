using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using IoTHUB_v1._0.Models;
using IoTHUB_v1._0.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MimeKit;


namespace IoTHUB_v1._0.Controllers
{
    public class AccountController : Controller
    {
        private readonly IoTHUBContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AccountController(IoTHUBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }
        // GET: Account
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Mediapath = HttpContext.Session.GetString("Mediapath");
            
            return View(_context.UserTbl.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string usersearch)
        {
            ViewData["GetUserDetails"] = usersearch;

            var userquery = from x in _context.UserTbl select x;
            if (!String.IsNullOrEmpty(usersearch))
            {
                userquery = userquery.Where(x => x.Username.Contains(usersearch) ||  x.Email.Contains(usersearch) || x.Address.Contains(usersearch) || x.PhoneNo.Contains(usersearch) || x.Companyemail.Contains(usersearch) || x.Companyname.Contains(usersearch));
            }
            return View(await userquery.AsNoTracking().ToListAsync());


        }
        public IActionResult ViewClient()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Mediapath = HttpContext.Session.GetString("Mediapath");

            return View(_context.UserTbl.Where(p => p.ParentId == HttpContext.Session.GetInt32("UserId")).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> ViewClient(string usersearch)
        {
            ViewData["GetUserDetails"] = usersearch;

            var userquery = from x in _context.UserTbl select x;
            if (!String.IsNullOrEmpty(usersearch))
            {
                userquery = userquery.Where(x => x.Username.Contains(usersearch) || x.Email.Contains(usersearch) || x.Address.Contains(usersearch) || x.PhoneNo.Contains(usersearch) || x.Companyemail.Contains(usersearch) || x.Companyname.Contains(usersearch));
            }
            return View(await userquery.AsNoTracking().ToListAsync());


        }
        public IActionResult Login()
        {
            //ViewBag.LTLD = Request.Cookies["LastLoggedInTime"];
            return View();
        }


        //Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserTbl model)
        {

            UserTbl LogedInUser = _context.UserTbl.Where(x => x.Username == model.Username && x.Password == EncryptPassword.textToEncrypt(model.Password)).FirstOrDefault();

            if (LogedInUser == null)
            {
                ViewBag.Message = "Invalid Username and Password";
                return View();
            }
            HttpContext.Session.SetString("Username", LogedInUser.Username);
            HttpContext.Session.SetInt32("UserId", LogedInUser.UserId);
            HttpContext.Session.SetString("Companyname", LogedInUser.Companyname);
            HttpContext.Session.SetString("Address", LogedInUser.Address);
            HttpContext.Session.SetString("PhoneNo", LogedInUser.PhoneNo);
            HttpContext.Session.SetString("Email", LogedInUser.Email);
            HttpContext.Session.SetString("Companyemail", LogedInUser.Companyemail);
            Response.Cookies.Append("LastLoggedInTime", DateTime.Now.ToString());
            HttpContext.Session.SetString("Mediapath", LogedInUser.Mediapath);

            if (LogedInUser != null && LogedInUser.Isactive == true)
            {

                if (LogedInUser.RoleId == 15)
                {
                    return RedirectToAction("Index", "MasterAdmin");
                }
                else if (LogedInUser.RoleId == 13)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (LogedInUser.RoleId == 14)
                {
                    return RedirectToAction("Index", "Emp");
                }

                else
                {

                    return RedirectToAction("Index");
                }
            }
            else
            {

                return RedirectToAction("Login");
            }
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.RoleTbl, "RoleId", "Rolename");
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename");
            return View();
        }
        
        public async Task<IActionResult> Details()
        {
            var user = await _context.UserTbl.ToListAsync();
            ViewData["RoleId"] = new SelectList(_context.RoleTbl, "RoleId", "Rolename");
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename");
            return View(user);
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                UserTbl user = new UserTbl
                {
                    Username = model.Username,
                    Email = model.Email,
                    Address = model.Address,
                    Password = EncryptPassword.textToEncrypt(model.Password),
                    //ConfirmPassword = EncryptPassword.textToEncrypt(model.ConfirmPassword),
                    PhoneNo = model.PhoneNo,
                    Companyname = model.Companyname,
                    Companyemail = model.Companyemail,
                    RoleId = model.RoleId,
                    ServiceId = model.ServiceId,
                    Isparent = model.Isparent,
                    ParentId = HttpContext.Session.GetInt32("UserId"),
                    Isactive = model.Isactive,
                    Createddate = DateTime.UtcNow,
                    Mediapath = uniqueFileName,
                };
                _context.Add(user);
                await _context.SaveChangesAsync();
                var mailhtml = "<html><head><title></title><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><meta name='viewport' content='width=device-width, initial-scale=1'><meta http-equiv='X-UA-Compatible' content='IE=edge'/><style type='text/css'>/* FONTS */ @media screen{@font-face{font-family: 'Lato'; font-style: normal; font-weight: 400; src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');}@font-face{font-family: 'Lato'; font-style: normal; font-weight: 700; src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');}@font-face{font-family: 'Lato'; font-style: italic; font-weight: 400; src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');}@font-face{font-family: 'Lato'; font-style: italic; font-weight: 700; src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');}}/* CLIENT-SPECIFIC STYLES */ body, table, td, a{-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;}table, td{mso-table-lspace: 0pt; mso-table-rspace: 0pt;}img{-ms-interpolation-mode: bicubic;}/* RESET STYLES */ img{border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;}table{border-collapse: collapse !important;}body{height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important;}/* iOS BLUE LINKS */ a[x-apple-data-detectors]{color: inherit !important; text-decoration: none !impomportant;}/* ANDROID CENTER FIX */ div[style*='margin: 16px 0;']{margin: 0 !important;}</style></head><body style='background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;'><div style='display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;'></div><table border='0' cellpadding='0' cellspacing='0' width='100%'> <tr> <td bgcolor='#7c72dc' align='center'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td align='center' valign='top' style='padding: 40px 10px 40px 10px;'> <a href='#' target='_blank'> <img alt='Logo' src='https://i.ibb.co/mGk9ndL/lg1.jpg' width='150' height='150' style='display: block; font-family: 'Lato', Helvetica, Arial, sans-serif; color: #ffffff; font-size: 18px;' border='0'> </a> </td></tr></table> </td></tr><tr> <td bgcolor='#7c72dc' align='center' style='padding: 0px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#ffffff' align='center' valign='top' style='padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;'> <h1 style='font-size: 32px; font-weight: 400; margin: 0;'>Welcome to IoTHUB</h1> </td></tr></table> </td></tr><tr> <td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;' > <p style='margin: 0;padding-left: 30px'>Your Username :-" + user.Email + " </p><p style='margin: 0;padding-left: 30px'>Your current Password :- It@123 </p><p style='margin: 0;padding-left: 30px'>(This is your temporary password) </p><p style='margin: 0;padding-left: 30px'>Kindly change your password, We are not responsible for your account </p></td></tr><tr> <td bgcolor='#ffffff' align='left'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td bgcolor='#ffffff' align='center' style='padding: 20px 30px 60px 30px;'> <table border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' style='border-radius: 3px;' bgcolor='#7c72dc'><a href='#' target='_blank' style='font-size: 20px; font-family: Helvetica, Arial, sans-serif; color: #ffffff; text-decoration: none; color: #ffffff; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid #7c72dc; display: inline-block;'>Change Password</a></td></tr></table> </td></tr></table> </td></tr></table> </td></tr><tr> <td bgcolor='#f4f4f4' align='center' style='padding: 30px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#C6C2ED' align='center' style='padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;' > <h2 style='font-size: 20px; font-weight: 400; color: #111111; margin: 0;'>Need more help?</h2> <p style='margin: 0;'><a href='' target='_blank' style='color: #7c72dc;'>We&rsquo;re here, ready to talk</a></p></td></tr></table> </td></tr><tr> <td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;' > <p style='margin: 0;'>You received this email because you had registered by your Admin. If you did not, please contact us.</a></p></td></tr><tr> <td bgcolor='#f4f4f4' align='CENTER' style='padding: 0px 30px 30px 30px; color: #000000; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;' > <p style='margin: 0;'>IoTHUB</p></td></tr></table> </td></tr></table></body></html>";

                Send(user.Email, "Successfully Registered to IoTHUB", mailhtml);


            }
            else
            {
                return View("Create");
            }
            ViewData["RoleId"] = new SelectList(_context.RoleTbl, "RoleId", "Rolename", model.RoleId);
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename", model.ServiceId);
            return RedirectToAction("Create", "Account");

        }
        private string UploadedFile(UserViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public ActionResult AddEmployee()
        {
            ViewData["RoleId"] = new SelectList(_context.RoleTbl, "RoleId", "Rolename");
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddEmployee(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                UserTbl user = new UserTbl
                {
                    Username = model.Username,
                    Email = model.Email,
                    Address = model.Address,
                    Password = EncryptPassword.textToEncrypt(model.Password),
                    //ConfirmPassword = EncryptPassword.textToEncrypt(model.ConfirmPassword),
                    PhoneNo = model.PhoneNo,
                    Companyname = HttpContext.Session.GetString("Companyname"),
                    Companyemail = HttpContext.Session.GetString("Companyemail"),
                    RoleId = model.RoleId,
                    ServiceId = model.ServiceId,
                    //Isparent = model.Isparent,
                    ParentId = HttpContext.Session.GetInt32("UserId"),
                    Isactive = model.Isactive,
                    Createddate = model.Createddate,
                    Mediapath = uniqueFileName,
                };
                _context.Add(user);
                await _context.SaveChangesAsync();
                var mailhtml = "<html><head><title></title><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><meta name='viewport' content='width=device-width, initial-scale=1'><meta http-equiv='X-UA-Compatible' content='IE=edge'/><style type='text/css'>/* FONTS */ @media screen{@font-face{font-family: 'Lato'; font-style: normal; font-weight: 400; src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');}@font-face{font-family: 'Lato'; font-style: normal; font-weight: 700; src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');}@font-face{font-family: 'Lato'; font-style: italic; font-weight: 400; src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');}@font-face{font-family: 'Lato'; font-style: italic; font-weight: 700; src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');}}/* CLIENT-SPECIFIC STYLES */ body, table, td, a{-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;}table, td{mso-table-lspace: 0pt; mso-table-rspace: 0pt;}img{-ms-interpolation-mode: bicubic;}/* RESET STYLES */ img{border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;}table{border-collapse: collapse !important;}body{height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important;}/* iOS BLUE LINKS */ a[x-apple-data-detectors]{color: inherit !important; text-decoration: none !impomportant;}/* ANDROID CENTER FIX */ div[style*='margin: 16px 0;']{margin: 0 !important;}</style></head><body style='background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;'><div style='display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;'></div><table border='0' cellpadding='0' cellspacing='0' width='100%'> <tr> <td bgcolor='#7c72dc' align='center'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td align='center' valign='top' style='padding: 40px 10px 40px 10px;'> <a href='#' target='_blank'> <img alt='Logo' src='https://i.ibb.co/mGk9ndL/lg1.jpg' width='150' height='150' style='display: block; font-family: 'Lato', Helvetica, Arial, sans-serif; color: #ffffff; font-size: 18px;' border='0'> </a> </td></tr></table> </td></tr><tr> <td bgcolor='#7c72dc' align='center' style='padding: 0px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#ffffff' align='center' valign='top' style='padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;'> <h1 style='font-size: 32px; font-weight: 400; margin: 0;'>Welcome to IoTHUB</h1> </td></tr></table> </td></tr><tr> <td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;' > <p style='margin: 0;padding-left: 30px'>Your Username :-" + user.Email + " </p><p style='margin: 0;padding-left: 30px'>Your current Password :- It@123 </p><p style='margin: 0;padding-left: 30px'>(This is your temporary password) </p><p style='margin: 0;padding-left: 30px'>Kindly change your password, We are not responsible for your account </p></td></tr><tr> <td bgcolor='#ffffff' align='left'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td bgcolor='#ffffff' align='center' style='padding: 20px 30px 60px 30px;'> <table border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' style='border-radius: 3px;' bgcolor='#7c72dc'><a href='#' target='_blank' style='font-size: 20px; font-family: Helvetica, Arial, sans-serif; color: #ffffff; text-decoration: none; color: #ffffff; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid #7c72dc; display: inline-block;'>Change Password</a></td></tr></table> </td></tr></table> </td></tr></table> </td></tr><tr> <td bgcolor='#f4f4f4' align='center' style='padding: 30px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#C6C2ED' align='center' style='padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;' > <h2 style='font-size: 20px; font-weight: 400; color: #111111; margin: 0;'>Need more help?</h2> <p style='margin: 0;'><a href='' target='_blank' style='color: #7c72dc;'>We&rsquo;re here, ready to talk</a></p></td></tr></table> </td></tr><tr> <td bgcolor='#f4f4f4' align='center' style='padding: 0px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;' > <p style='margin: 0;'>You received this email because you had registered by your Admin. If you did not, please contact us.</a></p></td></tr><tr> <td bgcolor='#f4f4f4' align='CENTER' style='padding: 0px 30px 30px 30px; color: #000000; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;' > <p style='margin: 0;'>IoTHUB</p></td></tr></table> </td></tr></table></body></html>";
              
                Send(user.Email, "Successfully Registered to IoTHUB", mailhtml);

            }
            else
            {
                return View("AddEmployee");
            }
            ViewData["RoleId"] = new SelectList(_context.RoleTbl, "RoleId", "Rolename", model.RoleId);
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename", model.ServiceId);
            return RedirectToAction("AddEmployee", "Account");

        }
        public async Task<IActionResult> EmpDetails()
        {
            var user = await _context.UserTbl.ToListAsync();
            ViewData["RoleId"] = new SelectList(_context.RoleTbl, "RoleId", "Rolename");
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename");
            return View(user);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        
        //public async Task<IActionResult> ChangePassword(UserTbl user, string newpassword)
        //{

        //    return View();
        //}

        
        public void Send(string emailid,string subject,string mailbody)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Admin", "ahirtushar946@gmail.com");
            message.From.Add(from);
            MailboxAddress to = new MailboxAddress(emailid);
            message.To.Add(to);
            message.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = mailbody;
            message.Body = bodyBuilder.ToMessageBody();
            MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("ahirtushar946@gmail.com", "Ahir@2020");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }

        public ViewResult Viewuser()
        {
            var Userid = HttpContext.Session.GetInt32("UserId");
            UserTbl uid = _context.UserTbl.Find(Userid);

            ViewData["RoleId"] = new SelectList(_context.RoleTbl, "RoleId", "Rolename");
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename");
            return View(uid);
        }
       
        public ViewResult Viewemp()
        {
            var Userid = HttpContext.Session.GetInt32("UserId");
            UserTbl uid = _context.UserTbl.Find(Userid);

            ViewData["RoleId"] = new SelectList(_context.RoleTbl, "RoleId", "Rolename");
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename");
            return View(uid);
        }
        public ViewResult Viewadmin()
        {
            var Userid = HttpContext.Session.GetInt32("UserId");
            UserTbl uid = _context.UserTbl.Find(Userid);

            ViewData["RoleId"] = new SelectList(_context.RoleTbl, "RoleId", "Rolename");
            ViewData["ServiceId"] = new SelectList(_context.ServiceTbl, "ServiceId", "Servicename");
            return View(uid);
        }
       



    }
}