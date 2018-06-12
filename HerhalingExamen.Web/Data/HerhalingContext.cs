using HerhalingExamen.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerhalingExamen.Web.Data
{
    public class HerhalingContext : DbContext
    {
        public HerhalingContext(DbContextOptions<HerhalingContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductInfo> ProductInfo { get; set; }

        //protected override void onModelCreating(ModelBuilder modelBuilder)
        //{

        //}

    }
}
