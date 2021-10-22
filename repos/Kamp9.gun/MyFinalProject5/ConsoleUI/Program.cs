using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();

            // CategoryTest();

            ProductManager productManager1 = new ProductManager(new EfProductDal());

            var result = productManager1.GetProducts();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName);
                }
                Console.WriteLine(result.Message);
            }else
            {
                Console.WriteLine(result.Message);
            }

            Console.ReadLine();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAllCategories())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(40, 100).Data)
            {
                Console.WriteLine(product.ProductName);
            }

            var productDetail = productManager.GetById(2);

            Console.WriteLine("---------------------------");
            Console.WriteLine(productDetail.Data.ProductName + " | " + productDetail.Data.UnitPrice + " | " +
                productDetail.Data.UnitsInStock);
        }
    }
}
