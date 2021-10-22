using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqMethods
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

            //LINQ METHODLARI

            //1-WHERE=> Bir liste icerisinde filtreleme yapmak istedgimiz zaman birden fazla sart sunarak
            //gelmesini istedigimiz verileri tek satirda bulur ve onlari bir listeye atarak bize donderir
            //Buldugu elemanlari bize liste olarak doner ve tam liste olarak donmesi icin sonuna ToList() ekleriz

            TestWhereMethod(products);

            //2)ANY=>Bir listenin icinde eleman var mi yok mu onu arariz ve ANY donus olarak true yada false doner

            TestAnyMethod(products);

            //3)FIND=>Liste icinde aradigimiz bir elemani bize tamamen getirir yani biz bunu bir urunun 
            //detayina gitmek istersek orda kullaniriz, yani bize bir urunu tum bilgileri ile getiriyor yani urunun
            //kendisini getiriyor veya bankacilik sisteminde 3 tane krediniz var ve birinin detayina gitmek isterseniz
            // iste bu sekilde once id si uzerinden urunu bulur sonra onu senin icin tum detayini getirir
            //Icinde olmayan bir urunId si verirsen onu bellekte bulamayacagi icin onun referansini bulamayacagi icin
            //o bize null olarak doner karsiligi yok demektir
            //Eger biz CategoryId gibi birden fazla olma ihtimali olan bir Id aratirsak o zamanda ilk bulgunu id yi
            //alir
            /////////////////////////////////
            //SingleOrDefult-FirstOrDefault-First methodlari da islev bakimindan Find ile benzerlik gosterir
            ////////////////////////////////////

            TestFindMethod(products);


            //4)Liste icerisinde aradigimiz id birden fazla varsa CategoryId gibi o zaman onlarin bir listeye atarak
            //bize bir liste doner sonunda ToList() yapmamiza gerek yok bunda
            TestFindAll(products);

            //5)WHERE ile aradigimiz bir hece yi ARTAN veya AZALAN fiyatlarina gore siralayarak getirme
            //Normalde dogrudan biz bir hece veya birkac harf ararsak onlari bize listedeki sirasina gore getirir

            TestWhereAscDesc(products);


            Console.WriteLine(" Birden fazla satirda query yapmak!!!!");
            //YUKARDAN BURAYA KADAR YAPTIKLARIMIZA SINGLE LINE QUERY ADI VERILIR

            WhereOrderByTestWithNewMethod(products);


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
        }

        private static void WhereOrderByTestWithNewMethod(List<Product> products)
        {
            var result = from p in products
                         select p;

            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("---------------------------");

            var result3 = from p in products
                          where p.UnitPrice > 4000 && p.CategoryId == 1
                          select p;//Gelen listeyi liste deki sirasina gore getirir

            Console.WriteLine("Where ile filtrelenmis birden fazla satirda query yapmak");
            foreach (var product in result3)
            {
                Console.WriteLine(product.ProductName + " | " + product.UnitPrice);
            }

            Console.WriteLine(" Simdi de 4000 den buyuk ve kategorisi 1 olan urunleri urun fiyati azdan coka dogru veya" +
                " cokdan aza dogru sirala");
            var result4 = from p in products
                          where p.UnitPrice > 4000 && p.CategoryId == 1
                          orderby p.UnitPrice descending//descending yerine ya ascending yazariz ya da hicbirsey yazmassak da 
                          //default olarak o orderby i yazinca ascending calisir
                          select p;

            foreach (var product in result4)
            {
                Console.WriteLine(product.ProductName + " | " + product.UnitPrice);
            }

            var result5 = from p in products
                          where p.UnitPrice > 4000 && p.CategoryId == 1
                          orderby p.UnitPrice descending, p.ProductName ascending//once fiyati buyukten kucuge getir sonra da 
                          //isme gore alfabe sirasina A dan Z ye siralayarak getir demektir
                          select p;

            Console.WriteLine("Where deki filtrelemeden sonra Fiyata gore buyukten kucuge sonra da isme gore alfabe sirasi A dan Z ye sirala");
            foreach (var product in result5)
            {
                Console.WriteLine(product.ProductName + " | " + product.UnitPrice);
            }
        }


        //5)WHERE ile aradigimiz bir hece yi ARTAN veya AZALAN fiyatlarina gore siralayarak getirme
        //Normalde dogrudan biz bir hece veya birkac harf ararsak onlari bize listedeki sirasina gore getirir
        private static void TestWhereAscDesc(List<Product> products)
        {
            var result1 = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice);
            foreach (var product in result1)
            {
                Console.WriteLine("Aradigimiz bir heceyi fiyat siralamsina gore getirmek " + product.ProductName + " Fiyat: " + product.UnitPrice);
            }
            var result2 = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice);


            Console.WriteLine("--Aradigimiz bir hecenin--Azalan siraya gore fiyat siralamasi----");
            foreach (var product in result2)
            {
                Console.WriteLine(product.ProductName + product.UnitPrice);
            }

            //6)WHERE ILE ARADIGIMIZ HARFLERIN FIYAT SIRALAMASI YAPARKEN FIYATI AYNI OLANLARI DA ALFABE SIRASINA GORE GETIREBILIRZ
            Console.WriteLine("Fiyati ayni olanlari A dan Z ye gore alfabeye gore siralayarak getirme ");
            List<Product> products2 = products.Where(p => p.ProductName.Contains("top")).OrderByDescending
                (p => p.UnitPrice).ThenBy(p => p.ProductName).ToList();

            foreach (var product in products2)
            {
                Console.WriteLine(product.ProductName + " | " + product.UnitPrice);
            }


            

        }



        //4)Liste icerisinde aradigimiz id birden fazla varsa CategoryId gibi o zaman onlarin bir listeye atarak
        //bize bir liste doner sonunda ToList() yapmamiza gerek yok bunda
        private static void TestFindAll(List<Product> products)
        {
            List<Product> products1 = products.FindAll(p => p.CategoryId == 1);
            foreach (var product in products1)
            {
                Console.WriteLine("findAllMethod  " + product.ProductName);
            }

            Console.WriteLine("FindAll Contains");
            List<Product> products2 = products.FindAll(p => p.QuantityPerUnit.Contains("Ram"));

            foreach (var product in products2)
            {
                Console.WriteLine(product.ProductName + "   |  " + product.QuantityPerUnit);
            }
        }


        //3)FIND=>Liste icinde aradigimiz bir elemani bize tamamen getirir yani biz bunu bir urunun 
        //detayina gitmek istersek orda kullaniriz, yani bize bir urunu tum bilgileri ile getiriyor yani urunun
        //kendisini getiriyor veya bankacilik sisteminde 3 tane krediniz var ve birinin detayina gitmek isterseniz
        // iste bu sekilde once id si uzerinden urunu bulur sonra onu senin icin tum detayini getirir
        //Icinde olmayan bir urunId si verirsen onu bellekte bulamayacagi icin onun referansini bulamayacagi icin
        //o bize null olarak doner karsiligi yok demektir
        //Eger biz CategoryId gibi birden fazla olma ihtimali olan bir Id aratirsak o zamanda ilk bulgunu id yi
        //alir
        private static void TestFindMethod(List<Product> products)
        {
            var result1 = products.Find(p => p.ProductId == 4);

            Console.WriteLine("UrunDetayi: " + result1.ProductName + " |  " + result1.UnitPrice);
        }

        private static void TestWhereMethod(List<Product> products)
        {
            List<Product> filteredProducts = products.Where(p => p.UnitPrice > 3000 && p.UnitInStock > 10).ToList();

            //Where ile Contains i kullanarak liste icerisindeki propertylerden herhangi bir metinden
            //bir bolum aratabiliriz
            //Eger degiskeni liste olarak verirsek ToList kullanmaliyiz ama var ile bir degisken olusturusak
            //kendisi bir liste olarak donecek bize o zaman ToList() kullanmasak da olur
            List<Product> products3 = products.Where(p => p.QuantityPerUnit.Contains("Ram")).ToList();
            var result = products.Where(p => p.ProductName.Contains("top"));
        }


        //2)ANY=>Bir listenin icinde eleman var mi yok mu onu arariz ve ANY donus olarak true yada false doner
        private static void TestAnyMethod(List<Product> products)
        {
            var isProductNameIn = products.Any(p => p.ProductName == "Asus");

            if (isProductNameIn)
            {
                Console.WriteLine("Aradidigin ProductName listede mevcuttur");
            }
            else
            {
                Console.WriteLine("Aradidign productName listede mevcut degildir");
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
