using System;
using System.Collections.Generic;
using System.Text;

namespace NortwindEfCodeFirst.Entities
{//Tablo karsiligimizin nesneleri veritabani nesneleridir
 //Bestpractis olmasi acisindan aslinda CustomerID yerine Id yazmak ayrica da City ve Community yide ayri 
 //tablolarda tutup onlarin id lerini bu class ta tutmak veritabani normalization kurallarinin geregidir//
 //Ama biz su anda veritabaninda Northwind veritabaninda hali hazirda varolan duzeni takip ediyoruz,,
    public class Customer
    {
        public Customer()
        {//Customer nesnemiz den her bir instance olusturuldugunda siparisi ile beraber icinde bos hic siparis
            //olmayacak sekilde oolusur daha sonra siparislerimizi icine atariz...
            Orders = new List<Order>();
        }
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Order> Orders { get; set; }//Musteri tekil ve onun siparisleri...
    }
}
