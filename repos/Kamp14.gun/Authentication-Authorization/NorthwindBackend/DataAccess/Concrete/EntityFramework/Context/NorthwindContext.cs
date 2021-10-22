using Core.Entities.Concrete;
using Core.Utilities.Security.jwt;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Context
{
    //Veritabani baglantisi ve IEntity nesnelerimizle veritabani tablolarimiz arasindaki baglantiyi kurar
    //DataAccess e entityframework ekleriz
    //Ismini NorthwindContext vermemiz ile Context olmuyor yukledigimiz Entityframework den bir
    //DbContext gelecektir DbContext te n inherit edilmesi gerekiyor
    public   class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\Projectsv13;Database=Northwind;
Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserTest> UsersTest { get; set; }
        public DbSet<OperationClaimTest> OperationClaimsTest { get; set; }
        public DbSet<UserOperationClaimTest> UserOperationClaimsTest { get; set; }
    }

   
}
