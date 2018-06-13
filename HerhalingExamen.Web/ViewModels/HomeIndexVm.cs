using HerhalingExamen.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingExamen.Web.ViewModels
{
    public class HomeIndexVm
    {
        public IEnumerable<Product> Products { get; set; }
        public User User { get; set; }
    }
}
