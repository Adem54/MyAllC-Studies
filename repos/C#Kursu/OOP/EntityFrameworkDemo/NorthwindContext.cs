using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkDemo
{
 public   class NorthwindContext:DbContext
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
        
    }
}
