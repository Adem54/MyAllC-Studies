using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLinqProject
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
 new Product {ProductId=1, CategoryId=1, ProductName="Asus", QuantityPerUnit="4Gb Ram", UnitPrice=4000, UnitInStock=12},
 new Product {ProductId=2, CategoryId=1, ProductName="Toshiba", QuantityPerUnit="8Gb Ram", UnitPrice=5000, UnitInStock=15},
 new Product {ProductId=3, CategoryId=1, ProductName="Apple", QuantityPerUnit="12Gb Ram", UnitPrice=8000, UnitInStock=21},
 new Product {ProductId=4, CategoryId=2, ProductName="Samsung", QuantityPerUnit="16Gb Ram", UnitPrice=2500, UnitInStock=32},
 new Product {ProductId=5, CategoryId=2, ProductName="Xaomi", QuantityPerUnit="32Gb Ram", UnitPrice=3000, UnitInStock=40},

            };
            //Liste olusturdugumuz veriler bize gercek sistemlerde bir verikaynagindan bir veirtabanindan gelecektir


            //Simdi veritabani islemlerini burda yapalim listeleme,filtreleme vs gibi

            //Urunlerimizi listeleyelim mesela
            //Urunlerimizi filtreleyeim fiyati 3000 den buyuk ve stockta 10 taneden fazla olan urunleri filtreleyelim
            //Veritabani filtrelemesidir bunlar
            //Birde biz kategori ismini de product bilgileri ile yazdirmak istersem o zaman iyice uzayacak yazacagimiz kodlar

            Test(products);

            Console.WriteLine("Linq------------------------------------------");

            //Linq ile
            //Where Linq icinde verilere  kosul koyarak listeleyecegimiz bir methodudur
            //p her bir product tir genelde urunlerin basharfleri ile yazilir 2 kelime ise 2 kelimenin basharfi yazilir
            //Where methodunun sonucunda gelen veri array tabanli onu listeye cevirmek icin ToList() kullaniriz
            //Where methodu arkada bir dongu olusturuyor sartlara gore yazdigimiz sarta uyan her bir product
            //nesnesini yeni bir liste olusturup o listeye atiyor ve bize inumerable,iterable olarak donuyor biz sadece ona
            //ToList() dememiz gerekiyor...
            //Elimizdeki verileri sartlarimiza gore filtrelerken Linq ile cok daha pratik bir sekilde uygulayabilir..
            var results = products.Where(p => p.UnitPrice > 3000 && p.UnitInStock > 10).ToList();

            foreach (var product in results)
            {
                Console.WriteLine(product.ProductName);
            }


            //Linq KULLANMADAN YAZACAGIMIZ KODLAR BUNLAR FILTRELEME ICIN
            static List<Product> GetAllProduct(List<Product> products)
            {
                List<Product> filteredProduct = new List<Product>();

                foreach (var product in products)
                {
                    if (product.UnitPrice > 3000 && product.UnitInStock > 10)
                    {
                        filteredProduct.Add(product);

                    }

                }

                return filteredProduct;
            }

            var myFilteredProducts = GetAllProduct(products);

            foreach (var product in myFilteredProducts)
            {
                Console.WriteLine("Filtrelendi" + product.ProductName);
            }


        }

        private static void Test(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.UnitPrice > 3000 && product.UnitInStock > 10)
                {
                    Console.WriteLine(product.ProductName);
                }

            }
        }
    }


    public class Product {
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
