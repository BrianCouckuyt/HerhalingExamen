using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HerhalingExamen.Web.Models;
using HerhalingExamen.Web.Data;
using HerhalingExamen.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace HerhalingExamen.Web.Controllers
{
    public class HomeController : Controller
    {
        private HerhalingContext _herhalingContext;
        public HomeController(HerhalingContext context)
        {
            _herhalingContext = context;
            _herhalingContext.Set<User>()
                             .Include(u => u.UserProducts);
        }

        public IActionResult Index()
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
