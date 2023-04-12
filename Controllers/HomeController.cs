using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NgoProjectNew1.Models;
using NgoProjectNew1.Models.ViewModel;


namespace NgoProjectNew1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly NgoDbContext _context;

        public HomeController(NgoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var isValid = _context.NgoRegMembers.Any(user => user.Username == Username && user.Password == Password);

            if (!isValid)
            {
                ModelState.AddModelError("","something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("User authenticated successfully");
        }
        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new NgoRegMember()
                { 
                    Username = model.Username,
                    ContactNo = model.ContactNo,
                    Address = model.Address,
                    Name = model.Name,
                    Password=model.Password
                };
                _context.NgoRegMembers.Add(data);
                _context.SaveChanges();
                TempData["successMessage"] = "Registartion done successfully";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["errorMessage"] = "Empty form can't be submitted!";
                return View(model);
            }
        }

       
  
     }
 }

