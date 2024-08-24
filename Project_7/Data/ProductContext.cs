﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Project_7.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
               new()
               {
                   Id = 1,
                   Name = "Computer",
                   Price = 3500,
                   CreatedDate = DateTime.Now,
                   Stock = 100,
               },
               new()
               {
               Id = 2,
               Name = "Phone",
               Price = 500,
               CreatedDate = DateTime.Now,
               Stock = 10,
               }
               ,
               new()
               {
                   Id = 3,
                   Name = "Mouse",
                   Price = 150,
                   CreatedDate = DateTime.Now,
                   Stock = 3,
               },
               new()
               {
                   Id = 4,
                   Name = "Keyboard",
                   Price = 350,
                   CreatedDate = DateTime.Now,
                   Stock = 30,
               }
            });
            
        }

        public DbSet<Product> Products { get; set; }
    }
}