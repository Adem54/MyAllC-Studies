using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkDemo
{
 public  class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;DataBase=Northwind;
Trusted_Connection=True");
                //(localdb)\ProjectsV13 BURASI SUNUCU ADRESIDIR
        }

        public DbSet<Product> Products { get; set; } //Bu kod sayesinde biz veritabanindaki tum Product listesine
        //artik erisebiliriz...
    }
}
