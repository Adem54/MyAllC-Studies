using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    class Program
    {
      

        static void Main(string[] args)
        {
            List<Category> categories = new List<Category> {
            new Category {
             CategoryId=1,
             CategoryName="Bilgisayar"
            },
              new Category {
             CategoryId=2,
             CategoryName="Telefon"
            },
            };

            List<Product> products = new List<Product>
            {new Product{ ProductId=1, CategoryId=1, ProductName="Acer Laptop", QuantityPerUnit="32 Gb",
                UnitPrice=10000, UnitsInStock=12 },
                new Product{ ProductId=2, CategoryId=1, ProductName="Asus Laptop", QuantityPerUnit="16 Gb",
                UnitPrice=10000, UnitsInStock=16 },
                new Product{ ProductId=3, CategoryId=1, ProductName="Lenovo Laptop", QuantityPerUnit="12 Gb",
                UnitPrice=6000, UnitsInStock=8 },
                new Product{ ProductId=4, CategoryId=2, ProductName="Samsung Galaxy 20e", QuantityPerUnit="32 Gb",
                UnitPrice=4000, UnitsInStock=7 },
                new Product{ ProductId=5, CategoryId=2, ProductName="Huawei ", QuantityPerUnit="16 Gb",
                UnitPrice=3000, UnitsInStock=22 },

            };


            //Any sonuc true or false doner....Sarta uuyan 1 tane bile eleman olsa true doner
            bool is_Item = products.Any(p => p.ProductId == 3);
            Console.WriteLine("Eleman var mi?:  "+ is_Item );
            //Iste referans tip farki burda ortaya cikiyor...Sonuc true or false doner
            var test = products.Contains(new Product
            {
                ProductId = 1,
                CategoryId = 1,
                ProductName = "Acer Laptop",
                QuantityPerUnit = "32 Gb",
                UnitPrice = 10000,
                UnitsInStock = 12
            });

            Console.WriteLine("test:  "+ test);

            //Bir product a ait detaylara ulasmakk istersek 3 farkli sekilde de yapabiliriz
            //Liste icinde ki elemanin kendisini bize verir yani urunu yani product i veriyor
            //Peki bulamazsa ne donderir  o zamanda null donderecektir eger product bulamazsa
            
            var product1 = products.SingleOrDefault(p => p.ProductId == 4);
            Console.WriteLine("product1:"+ product1.ProductName);
            var product2 = products.Single(p => p.ProductId == 3);
            Console.WriteLine("product2:" + product2.ProductName);
            var product3 = products.Find(p => p.ProductId == 1);
            Console.WriteLine("product3:" + product3.ProductName);


            //Tum liste elemanlari her birisine ayri ayri uyuyorsa sart o zaman true gelir...
            //Yani any nin tersi.Sarta uymayan bir tane bile eleman olsa false doner....
            var test1 = products.All(p => p.UnitPrice > 1000);
            Console.WriteLine("test1: "+test1);


            //fiyati 5000 altinda olanlari getir-Linq sayesinde tek satirda bu islemleri yapabildik
            //products listesinin methodlarini Linq sayesinde kullanabiliyoruz ve dikkat edelim biz FinAll icerisine
            //Predicate yazmaliyiz predicate bir Func dir yani ok isaretinden once product, yani parametreye product
            //return olarak bool donen anonim bir delegedir aslindas yani method veya fonksiyonu tutucudur...
            List<Product> filteredByUnitPrice = products.FindAll(p => p.UnitPrice < 5000 && p.UnitsInStock<15);
            foreach (var product in filteredByUnitPrice)
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("ProductName icinde top olanlari getir");
            //
            var productsBySearch = products.FindAll(p => p.ProductName.Contains("top"));
            foreach (var item in productsBySearch)
            {
                Console.WriteLine(item.ProductName);
            }

            Console.WriteLine("Simdi de ayni seyi where ile yapalimm....");
            //Where ile yaptigimizda Orderby ile siralama da yapabiliriz...
            //Fiyata gore sirala buyukten kucuge dogru eger fiyatlari ayni ise o zamanda onlari isme gore sirala
            var productsByWhere = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p=>p.UnitPrice)
                .ThenByDescending(p=>p.ProductName);
            foreach (var item in productsByWhere)
            {
                Console.WriteLine(item.ProductName);
            }


            Console.WriteLine("Stokta 15 adet ve ustu olan lari getir");
            //Stokta 15 adet ve ustu olan lari getir
            //where ile yaptigimiz sorgular array tabanli old icin sonunda ToList ile listeye cevirmemiz gerekiyor...
            //ya da direk var ile degisken olusturmamiz gerekiyor en bastan!!
            List<Product> filteredByUnitsInStock = products.Where(p => p.UnitsInStock > 15).ToList();
            foreach (var product in filteredByUnitsInStock)
            {
                Console.WriteLine(product.ProductName);
            }

            List<int> sayilar = new List<int> { 2, 4, 6, 7, 8, 9 };
            Console.WriteLine("BinarySearch ile arama ile liste icinde elemanin ismini yazariz bize indexini getirir");
            Console.WriteLine(sayilar.BinarySearch(6));

            var  result = from p in products
                                          join c in categories
                                          on p.CategoryId equals c.CategoryId
                                          orderby p.UnitPrice descending,
                                          p.ProductName //birsey yazmassak default olarak ascending dir zaten
                                          where p.UnitPrice > 2000
                                          select new ProductDto
                                          {
                                              ProductId = p.ProductId,
                                              ProductName = p.ProductName,
                                              CategoryName = c.CategoryName,
                                              QuantityPerUnit = p.QuantityPerUnit,
                                              UnitPrice = p.UnitPrice,
                                              UnitsInStock = p.UnitsInStock
                                          };

            List<ProductDto> productDtos = result.ToList();

            Console.WriteLine("ProductDto.....");
            foreach (var item in productDtos)
            {
                Console.WriteLine("{0}-----{1}",item.ProductName,  item.CategoryName);
            }

           
        }
        

    }

    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string  QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }


    public class ProductDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
