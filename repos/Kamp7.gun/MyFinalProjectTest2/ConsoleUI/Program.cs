using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFrameworkProductDal;
using DataAccess.Concrete.InMemoryProductDal;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal();
            //  ProductManager productManager = new ProductManager(inMemoryProductDal);
            // ProductTest();

            // CategoryTest();

            ProductManager productManager1 = new ProductManager(new EfProductDal());

            var result = productManager1.GetAll();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName);
                }

                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            Console.ReadLine();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }

            Console.WriteLine("----------------------CategoryDetail----------------------------------");

            var categorName = categoryManager.GetById(2).CategoryName;

            Console.WriteLine(categorName);
        }

        private static void ProductTest()
        {
            EfProductDal efProductDal = new EfProductDal();


            ProductManager productManager = new ProductManager(efProductDal);

            foreach (var product in productManager.GetAllByUnitPrice(40, 100).Data)
            {
                Console.WriteLine(product.ProductName + " | " + product.UnitPrice);
            }

            Console.WriteLine("------------------------------------");

            Console.WriteLine(productManager.Get(2).Data.ProductId);
            Console.WriteLine(productManager.Get(2).Data.ProductName);
            Console.WriteLine(productManager.Get(2).Data.UnitPrice);
            Console.WriteLine(productManager.Get(2).Data.UnitsInStock);
        }
    }
}
