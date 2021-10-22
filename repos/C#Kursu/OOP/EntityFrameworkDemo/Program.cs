using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindContext northwindContext = new NorthwindContext();
            var products = northwindContext.Products;

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            Console.WriteLine("-------------------");

            GetProductsByCategory(9);


        
        }

        static void GetProductsByCategory(int categoryId)
        {
            NorthwindContext northwindContext = new NorthwindContext();
            var products = northwindContext.Products;
            Console.WriteLine(products.Where(p=>p.CategoryId==categoryId));

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }

        }
    }
}
