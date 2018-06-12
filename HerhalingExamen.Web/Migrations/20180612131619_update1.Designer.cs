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
    [Migration("20180612131619_update1")]
    partial class update1
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
                });

            modelBuilder.Entity("HerhalingExamen.Web.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
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
