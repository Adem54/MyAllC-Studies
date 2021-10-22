using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
  public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Northwind;Trusted_Connection=True");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //FLUENT MAPPING

        //Bir veritabani nesnesi, IEntity isaretli bir class nesne olustururken eger veritabaninda eslestirecegimiz
        //tablo da isimlendirme hatalari varsa ve bizde veritabani nesnemiizi ayni hatali isimlendirmelerle
        //olusturmak istemiiyor ve isimlendirmeyi degistirmek istiyorsak iste o zaman MAPPING ile veritabani 
        //nesnemiz ile veritabaninda ona karsilik gelen tabloyu bu sekkilde birbirine baglayabiliriz....

        //public DbSet<Personel> Personels { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Personel>().ToTable("Employees");

            modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeID");
            modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("LastName");
            modelBuilder.Entity<Personel>().Property(p => p.SurName).HasColumnName("FirstName");
        }
    }
}
