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
using Microsoft.AspNetCore.Http;

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
            var UserName = HttpContext.Session.GetString("Name");
            if (UserName != null)
            {
                var user = _herhalingContext.Users.FirstOrDefault(u => u.Name == UserName);
                if (user.UserProducts == null)
                {
                    user.UserProducts = new List<Product> { };
                    _herhalingContext.SaveChanges();
                }
                vm.User = user;
            }

            return View(vm);
        }


        public IActionResult AddToCart(Guid ProductId)
        {
            var UserName = HttpContext.Session.GetString("Name");
            Product product = _herhalingContext.Products.First(p => p.Id == ProductId);
            if (UserName != null)
            {
                var user = _herhalingContext.Users.FirstOrDefault(u => u.Name == UserName);
                if (user.UserProducts == null)
                {
                    user.UserProducts = new List<Product> { };
                }
                user.UserProducts.Add(product);
                _herhalingContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Login");
        }


        public IActionResult RemoveFromCart(Guid ProductId)
        {
            var UserName = HttpContext.Session.GetString("Name");
            var users = _herhalingContext.Users;
            Product product = _herhalingContext.Products.First(p => p.Id == ProductId);
            if (UserName != null)
            {
                foreach (var user in users)
                {
                    if (user.Name == UserName)
                    {
                        user.UserProducts.Remove(product);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
