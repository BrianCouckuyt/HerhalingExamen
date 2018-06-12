using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingExamen.Web.Entities
{
    public class ProductInfo
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}
