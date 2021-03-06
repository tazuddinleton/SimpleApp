﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleApp.Persistence;

namespace SimpleApp.Persistence.Migrations
{
    [DbContext(typeof(SimpleAppDbContext))]
    [Migration("20200528171832_AddEntity_Product")]
    partial class AddEntity_Product
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleApp.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,8)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "Product Description 1",
                            ProductName = "Product 1",
                            UnitPrice = 145.55m
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Product Description 2",
                            ProductName = "Product 2",
                            UnitPrice = 145.55m
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Product Description 3",
                            ProductName = "Product 3",
                            UnitPrice = 145.55m
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Product Description 4",
                            ProductName = "Product 4",
                            UnitPrice = 145.55m
                        },
                        new
                        {
                            ProductId = 5,
                            Description = "Product Description 5",
                            ProductName = "Product 5",
                            UnitPrice = 145.55m
                        },
                        new
                        {
                            ProductId = 6,
                            Description = "Product Description 6",
                            ProductName = "Product 6",
                            UnitPrice = 145.55m
                        },
                        new
                        {
                            ProductId = 7,
                            Description = "Product Description 7",
                            ProductName = "Product 7",
                            UnitPrice = 145.55m
                        },
                        new
                        {
                            ProductId = 8,
                            Description = "Product Description 8",
                            ProductName = "Product 8",
                            UnitPrice = 145.55m
                        },
                        new
                        {
                            ProductId = 9,
                            Description = "Product Description 9",
                            ProductName = "Product 9",
                            UnitPrice = 145.55m
                        },
                        new
                        {
                            ProductId = 10,
                            Description = "Product Description 10",
                            ProductName = "Product 10",
                            UnitPrice = 145.55m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
