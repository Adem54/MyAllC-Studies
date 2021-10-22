using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Bilgisayar"},
                new Category{CategoryId=2, CategoryName="Telefon"},
            };

            List<Product> products = new List<Product>
            {
 new Product {ProductId=1, CategoryId=1, ProductName="Asus Laptop", QuantityPerUnit="4Gb Ram", UnitPrice=6000, UnitInStock=12},
 new Product {ProductId=2, CategoryId=1, ProductName="Toshiba Laptop", QuantityPerUnit="8Gb Ram", UnitPrice=5000, UnitInStock=15},
 new Product {ProductId=3, CategoryId=1, ProductName="Apple Laptop", QuantityPerUnit="12Gb Ram", UnitPrice=8000, UnitInStock=21},
 new Product {ProductId=4, CategoryId=2, ProductName="Samsung", QuantityPerUnit="16Gb Ram", UnitPrice=2500, UnitInStock=32},
 new Product {ProductId=5, CategoryId=2, ProductName="Xaomi", QuantityPerUnit="32Gb Ram", UnitPrice=3000, UnitInStock=40},
 new Product {ProductId=6, CategoryId=1, ProductName="Lenovo Laptop", QuantityPerUnit="32Gb Ram", UnitPrice=5000, UnitInStock=40},
 new Product {ProductId=7, CategoryId=1, ProductName="Hp Laptop", QuantityPerUnit="32Gb Ram", UnitPrice=5000, UnitInStock=40},

            };

            Console.WriteLine("Hello World!");

            Console.WriteLine("------------------------------------------------------------");
            var result6 = from p in products
                          where p.UnitPrice > 4000 && p.CategoryId == 1
                          orderby p.UnitPrice descending, p.ProductName ascending
                          select p.ProductName;//ProductName leri bir listeye atar ve bize donderir

            foreach (var product in result6)
            {
                Console.WriteLine("ProductName " + product);
            }
            //Burda biz mesela sadece bizee lazim olan alanlari cekmek istedigimiz zaman ne yapariz?
            //Gideriz 1 tane class olustururuz class ProductDto(Data transformation Object)
            //Onun icerisine hangi alanlari gostermek istiyorsak onun
            //propertieslerini  yazariz mesela ProductId,ProductName,UnitPrice

            var result7 = from p in products
                          where p.UnitPrice > 4000 && p.ProductId == 1
                          orderby p.UnitPrice descending, p.ProductName ascending
                          select new ProductDto
                          {
                              ProductId = p.ProductId,
                              ProductName = p.ProductName,
                              UnitPrice = p.UnitPrice
                          };
            //result7 bize bir ProductDato classindan olusan  nesne listesi olarak donecektir
            //Ama biz burada ProductDto class i icerisine CategoryName de ekleyip CategoryName de dondurmek istiyoruz ama
            //CategoryName propertiy si Product class inin icerisinde sadece ProductId var ProductName  yok normalde 
            //Biz once CategoryName i gidip ProductDto ya ekleriz...
            //Ve iste tam boyle durumlarda join kullaniriz..
            //Category tablosu ile Product tablosunu birlestirme islemi gibi dusunelim...

            Console.WriteLine("-----------------------------------ProductDto-----------------------------");

            foreach (var productDto in result7)
            {
                Console.WriteLine("ProductDto:  " + productDto.ProductId + " |  " + productDto.ProductName + " | "
                    + productDto.UnitPrice);
            }

            //Elimizdeki products listesi ile categories listesini join edecegiz...
            //Biz olusturdugumuz ProductDto class inda ProductId, ProductName, UnitPrice products listesinden gelecekken
            //CategoryName ise categories listesinden gelecektir. Her iki listede neler ortak CategoryId ler her iki listede
            //de ortak old icin biz CategoryId ler uzerinden bu listeleri birlestirir istedigimiz kolonlari cagiririz
            //Buna iliskisel tasarim deniyor-RDBM-Iliskisel veritabani yonetimi gunumuz otomasyon sistemlerinin 99% unda bu sekildedir
            //products listesinin icerisinde sanki bir tane de alan ekleyip kategory numarasi ne ise onun adini bir alan olarak
            //ekliyoruz gibi dusunecegiz....
            //Burda dikkat etmemiz gereken bu iliskilendirme kategoryId ler uzerinden yapilacaktir

            Console.WriteLine("Join Islemi");
            var result1 = from p in products//products listesindeki her bir p(product) ile
                          join c in categories//categories listesindeki her bir c(category) yi join(birlestir) et
                          on p.CategoryId equals c.CategoryId // Burda == yazilmaz cok dikkat equals yazilir, categoryId ye gore
                          select new ProductDto//Burda da hangi kolonlari getireceksek ona gore bir class olustururuz
                          {
                              ProductId = p.ProductId,
                              CategoryName = c.CategoryName,
                              ProductName = p.ProductName,
                              UnitPrice = p.UnitPrice
                          };

            foreach (var productDto in result1)
            {
                //"{0}----{1}" , bu bir yazim sekli sablonudur her bir productDato elemanlari geldiginde aralarinda boyle bir
                //isaret koy demis oluyoruz ----
                Console.WriteLine("{0}----{1}" , productDto.ProductName , productDto.CategoryName);//Ve burda join ile CategoryName ve
                //ProductName i beraberce getirmis oluyoruz...
            }

            //Mantik olarak diyoruz ki burda once products tan her bir p yi yaz deriz ve o gelir tek tek propertiesleri
            // yani kolonlari yazar sonra dsa categoryId lere gore sonlarina kategoriden her bir kategori yi ekle demis oluyoruz

            Console.WriteLine("Hem join hem de where ile filtreleyelim... UnitPrice i 6000 ustu");

            var result2 = from p in products
                          join c in categories
                          on p.CategoryId equals c.CategoryId
                          where p.UnitPrice > 4000
                          orderby p.UnitPrice descending//yuksekten asagi dogru fiyat siralamasi gelir
                          select new ProductDto
                          {
                              ProductId=p.ProductId,
                              CategoryName=c.CategoryName,
                              ProductName=p.ProductName,
                              UnitPrice=p.UnitPrice
                          };

            foreach (var productDto in result2)
            {
                Console.WriteLine("{0} || {1} fiyati {2}", productDto.ProductName, productDto.CategoryName, productDto.UnitPrice);
            }


        }
    }

    public class ProductDto//Product class indan mesela sadece bu kolonlari veya bu propertiesleri Linq ile cekmek istersek
    {//Once CategoryName i buraya ekleriz...
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }




    public class Product
    {
        //Kategory nin de Id sini tutariz  cunku biz iliskilse olarak calisiyoruz ve ayni zamanda dogrudan isim
        //yerine numara ile iliskisel calisma sebebimiz de veri kacaklarini onlemektir.String olarak yazarsak 
        //mutlaka yanlis yazimlar vs den dolayi veri kacaklari olacaktir..
        //Ayni zamanda ismi ile yazarsak yarin oburgun bir degisiklikte gidip onu heryerden degistirmek zorunda
        //kaliriz..onun yerine id ile diger tum bilgilerini baglariz ve tek biryerden id degisince heryerde
        //verileri degisir...
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }

    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
