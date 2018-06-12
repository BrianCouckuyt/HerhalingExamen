using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HerhalingExamen.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string adminCheck = HttpContext.Session.GetString("IsAdmin");
            if (adminCheck != "True" || adminCheck == null)
            {
                return RedirectToAction("Index", "Login" );
            }
            else
            {
                return View();
            }
        }
    }
}