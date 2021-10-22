using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductClass
{
    class Program
    {
        static void Main(string[] args)
        {

            Product product1 = new Product();
            product1.ProductName = "Samsung20";
            product1.ProductPrice = 2000;
            product1.ProductColor = "black";
            product1.ProductSize = 6.5;

            Product product2 = new Product() { ProductName = "Huawei", ProductPrice = 1300, ProductColor = "white", ProductSize = 5.2 };
            Product product3 = new Product();
            product3.ProductName = "Iphone7";
            product3.ProductPrice = 5000;
            product3.ProductColor = "brown";
            product3.ProductSize = 4.5;

            Product product4 = new Product() { ProductName = "Xiaomi", ProductPrice = 3400, ProductColor = "pink", ProductSize = 4.3 };

            //Burda biz oluşturduğumuz ürünlerin her birini bir değişken olarak düşünüp bunları
            //dizi de döndürerek herbirinin özelliklerine de ulaşabiliriz
            //Product class tipimizin array ini oluşuralım şimdide
            Product[] products = new Product[] { product1, product2, product3,product4 };

            /* foreach (var product in products)
              {
                  Console.WriteLine(product.ProductName);
                  Console.WriteLine(product.ProductPrice);
                  Console.WriteLine(product.ProductColor);
                  Console.WriteLine(product.ProductSize);
                  Console.WriteLine("--------------------------------");
              }  */

            /*  for (int i = 0; i < products.Length; i++)
              {
                  Console.WriteLine(products[i].ProductName);
                  Console.WriteLine(products[i].ProductPrice);
                  Console.WriteLine(products[i].ProductColor);
                  Console.WriteLine(products[i].ProductSize);

                  Console.WriteLine("-----------------------------------");
              }  */

            /*
               int i = 0;
               while (i<products.Length)
               {
                   Console.WriteLine(products[i].ProductName);
                   Console.WriteLine(products[i].ProductPrice);
                   Console.WriteLine(products[i].ProductColor);
                   Console.WriteLine(products[i].ProductSize);
                   Console.WriteLine("---------------------------");
                   i++;
               }  */



            int j = 0;
            do
                
            {
                
                Console.WriteLine(products[j].ProductName);
                Console.WriteLine(products[j].ProductPrice);
                Console.WriteLine(products[j].ProductColor);
                Console.WriteLine(products[j].ProductSize);
                Console.WriteLine("---------------------------");
                j++;
                

            } while (j<products.Length);


            Console.ReadLine();
        }
    }

    class Product
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductColor { get; set; }
        public double ProductSize { get; set; }
    }
}
