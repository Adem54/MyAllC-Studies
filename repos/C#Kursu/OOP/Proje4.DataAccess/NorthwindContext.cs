using Microsoft.EntityFrameworkCore;
using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje4.DataAccess
{
    public class NorthwindContext : DbContext
    //DbContext Microsoft.EntityframeworkCore dan gelir
    //NorthwindContext bizim veritabaninia baglanti yapacagimiz ve ayni zamanda
    //bizim veritabani property IEntity nesnelerimizle verutabanindaki tablolari
    //match etmemizi eslestirmemizi saglar....
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //UseSqlServer ise  Microsoft.EntityframeworkCore.SqlServer dan gelir.
            //Burda veritabanimizin adini veririz..Server adi olmus oluyor..
            //Gercek bilgisayarlarda veritabani baska bilgisayarda olacagi icin yani server
            //ile proje farkli bilgisyarda olacagi icin veritabani baglantisi yaprken
            //gercek projelerde server ip adresi yazilir...
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;
        Trusted_Connection=true;");
        }
        //Veritabanlarina kullanici adi ve sifre ile baglanmak dogru degildir.Ozel durumnlar haric...
        //Mesela bir hosting siz e kullanici adi sifre vermistir ok.Ama lokal bir ortamda kullanici adi sifre
        //ile veritabanina baglanmak orda veritabani ve domain sistemlerinin eksik oldugunu gosterir...

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        //MAPPING
        public DbSet<Personel> Personels { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personel>().ToTable("Employees");
            modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeID");
            modelBuilder.Entity<Personel>().Property(p => p.Surname).HasColumnName("LastName");
            modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName");

        }




    }
}


//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{//Veritabani tablosundan farkli isme ve farkli proeprty isimlerine sahip olan Personal
// //isimli veritabani nesnesini Employees veri tabani tablosuna bu sekilde bagliyoruz...

//    //Bu noktada default semamizi da.Sadece adminlerin tablolari gibi
//    //Veya musteriyyi ilgilendiren kisimlar,yonetimi ilgilendiren kisimlari

//    //    modelBuilder.HasDefaultSchema("admin");//seklinde verebiliriz
//    modelBuilder.Entity<Personel>().ToTable("Employees");
//    //Normalde ToTable iki parametrelidir
//    //Ikinci parametre sema bilgisidir ve Sql table kuruldugunda varsasyilan olarak
//    //sema bilgisi "dbo" dur ama sema bilggisi farkli ise
//    modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeID");

//    modelBuilder.Entity<Personel>().Property(p => p.Surname).HasColumnName("LastName");
//    modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName");


//}