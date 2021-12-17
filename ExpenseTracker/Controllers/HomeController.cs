using ExpenseTracker.Data;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            TempData["msg"] = "";           
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] ApplicationUser ad)
        {
            try
            {
                var user = db.ApplicationUser.SingleOrDefault(c => c.UserName == ad.UserName && c.Password == ad.Password);
                if (!string.IsNullOrEmpty(user.UserName))
                {
                    HttpContext.Session.SetString("name", user.UserName);
                    HttpContext.Session.SetString("id", user.UserId.ToString());
                    TempData["msg"] = "You are welcome to Admin Section";
                    return Redirect("/Expenses/Index");
                }
                else
                {
                    TempData["msg"] = "User id or Password is wrong.!";
                    return Redirect("/Home/Index");
                }
            }
            catch (Exception)
            {

                throw;
            }       
            
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("name", "");
            ViewBag.data = HttpContext.Session.GetString("name");

            return Redirect("/Home/Index");
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
