﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Products.Models;

namespace Products.Migrations
{
    [DbContext(typeof(BrandContext))]
    [Migration("20190325111402_inital")]
    partial class inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Products.BrandEntry", b =>
                {
                    b.Property<string>("BrandName")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Value");

                    b.HasKey("BrandName");

                    b.ToTable("BrandEntry");
                });

            modelBuilder.Entity("Products.ProductEntry", b =>
                {
                    b.Property<string>("Number")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrandNameFK");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.HasKey("Number");

                    b.HasIndex("BrandNameFK");

                    b.ToTable("ProductEntry");
                });

            modelBuilder.Entity("Products.ProductEntry", b =>
                {
                    b.HasOne("Products.BrandEntry", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandNameFK");
                });
#pragma warning restore 612, 618
        }
    }
}
