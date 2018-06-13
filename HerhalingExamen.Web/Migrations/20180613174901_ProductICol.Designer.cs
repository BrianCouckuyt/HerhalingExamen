﻿// <auto-generated />
using System;
using HerhalingExamen.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HerhalingExamen.Web.Migrations
{
    [DbContext(typeof(HerhalingContext))]
    [Migration("20180613174901_ProductICol")]
    partial class ProductICol
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HerhalingExamen.Web.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = new Guid("15600c2e-112d-47d9-aaf8-c05bf0990391"), Image = "Foto van het eerste product", Name = "Eerste Product" },
                        new { Id = new Guid("93f9c35a-3cf4-45c4-a3f8-66a44150010a"), Image = "Foto van het tweede product", Name = "Tweede Product" },
                        new { Id = new Guid("426cfdad-2ebf-48e8-9e16-134ab54b465e"), Image = "Foto van het derde product", Name = "Derde Product" }
                    );
                });

            modelBuilder.Entity("HerhalingExamen.Web.Entities.ProductInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductInfo");

                    b.HasData(
                        new { Id = new Guid("e2186f7c-4944-4dcb-a373-589d41fb9dc4"), Description = "de description van het eerste product", ProductId = new Guid("15600c2e-112d-47d9-aaf8-c05bf0990391") },
                        new { Id = new Guid("c068d22a-6b23-426b-817a-e1b1c1465936"), Description = "de description van het tweede product", ProductId = new Guid("93f9c35a-3cf4-45c4-a3f8-66a44150010a") },
                        new { Id = new Guid("e91ae6fa-fe00-4fcd-a744-9d51e95da77d"), Description = "de description van het derde product", ProductId = new Guid("426cfdad-2ebf-48e8-9e16-134ab54b465e") }
                    );
                });

            modelBuilder.Entity("HerhalingExamen.Web.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = new Guid("2608f8ad-79e6-419d-a98c-fab17875a7ca"), IsAdmin = false, Name = "Brian", Password = "password" },
                        new { Id = new Guid("f252f827-8284-4a4c-8343-9caf41e39916"), IsAdmin = true, Name = "Administrator", Password = "password" }
                    );
                });

            modelBuilder.Entity("HerhalingExamen.Web.Entities.Product", b =>
                {
                    b.HasOne("HerhalingExamen.Web.Entities.User")
                        .WithMany("UserProducts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HerhalingExamen.Web.Entities.ProductInfo", b =>
                {
                    b.HasOne("HerhalingExamen.Web.Entities.Product", "Product")
                        .WithOne("ProductInfo")
                        .HasForeignKey("HerhalingExamen.Web.Entities.ProductInfo", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}