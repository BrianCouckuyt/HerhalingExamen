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
using HerhalingExamen.Web.ViewModels;

namespace HerhalingExamen.Web.Controllers
{
    public class HomeController : Controller
    {
        private HerhalingContext _herhalingContext;
        public HomeController(HerhalingContext context)
        {
            _herhalingContext = context;
            _herhalingContext.Set<User>()
                             .Include(u => u.UserProducts)
                             .ThenInclude(up => up.ProductInfo);
        }


        public IActionResult Index()
        {
            var vm = new HomeIndexVm();
            vm.Products = _herhalingContext.Products.Include(p => p.ProductInfo);
            return View(vm);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
