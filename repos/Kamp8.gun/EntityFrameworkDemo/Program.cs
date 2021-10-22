using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
           // GetAll();

            Console.WriteLine("Categoriye gore verileri cekelim");
            GetAllByCategory(2);

            Console.ReadLine();
        }

        private static void GetAll()
        {
            //ENTITYFRAMEWORK ILE
            //VERITABANINDAKI PRODUCT TABLOSUNA VE TUM PRODUCT LISTESINE ERISEBILIUYORUZ!!!!
            NorthwindContext context = new NorthwindContext();

            foreach (var product in context.Products)
            {
                Console.WriteLine(product.ProductName);
            }
        }

        private static void GetAllByCategory(int id)
        {
            //Kategoriye gore veriyi alalim simdide
            NorthwindContext context = new NorthwindContext();
            var result = context.Products.Where(p => p.CategoryId == id);
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
