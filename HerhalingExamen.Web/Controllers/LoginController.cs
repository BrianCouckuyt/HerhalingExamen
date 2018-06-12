using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerhalingExamen.Web.Data;
using HerhalingExamen.Web.Entities;
using HerhalingExamen.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HerhalingExamen.Web.Controllers
{
    public class LoginController : Controller
    {

        private HerhalingContext _herhalingContext;
        public LoginController(HerhalingContext context)
        {
            _herhalingContext = context;
        }


        public IActionResult Index()
        {
            var user = new User();
            var loginVm = new LoginVm();

            return View(loginVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginVm loginVm)
        {
            var allUsers = _herhalingContext.Users.ToList();

            if (ModelState.IsValid)
            {
                foreach (var user in allUsers)
                {
                    if (user.Name == loginVm.Name && user.Password == loginVm.Password)
                    {
                        var admin = user.IsAdmin.ToString();
                        HttpContext.Session.SetString("IsAdmin", admin);
                        HttpContext.Session.SetString("Name", user.Name);
                        var adminCheck = HttpContext.Session.GetString("IsAdmin");
                        if (adminCheck == "True")
                        {
                           return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Your credentials are invalid, please try again");
                return View(loginVm);
            }

            return View(loginVm);
        }
    }
}