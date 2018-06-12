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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var GuidProduct1 = new Guid("15600C2E-112D-47D9-AAF8-C05BF0990391");
            var GuidProduct2 = new Guid("93F9C35A-3CF4-45C4-A3F8-66A44150010A");
            var GuidProduct3 = new Guid("426CFDAD-2EBF-48E8-9E16-134AB54B465E");

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = GuidProduct1,
                    Name = "Eerste Product",
                    Image = "Foto van het eerste product"
                },
                new Product
                {
                Id = GuidProduct2,
                    Name = "Tweede Product",
                    Image = "Foto van het tweede product"
                },
                new Product
                {
                    Id = GuidProduct3,
                    Name = "Derde Product",
                    Image = "Foto van het derde product"
                }       
            );

            modelBuilder.Entity<ProductInfo>().HasData(
                new ProductInfo
                {
                    Id = new Guid("E2186F7C-4944-4DCB-A373-589D41FB9DC4"),
                    Description = "de description van het eerste product",
                    ProductId = GuidProduct1
                },
                new ProductInfo
                {
                    Id = new Guid("C068D22A-6B23-426B-817A-E1B1C1465936"),
                    Description = "de description van het tweede product",
                    ProductId = GuidProduct2
                },
                new ProductInfo
                {
                    Id = new Guid("E91AE6FA-FE00-4FCD-A744-9D51E95DA77D"),
                    Description = "de description van het derde product",
                    ProductId = GuidProduct3
                }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("2608F8AD-79E6-419D-A98C-FAB17875A7CA"),
                    Password = "password",
                    Name = "Brian",
                    IsAdmin = false
                },
                new User
                {
                    Id = new Guid("F252F827-8284-4A4C-8343-9CAF41E39916"),
                    Password = "password",
                    Name = "Administrator",
                    IsAdmin = true
                }
                );
        }

    }
}
