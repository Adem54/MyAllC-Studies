using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal();
            //ProductManager productManager = new ProductManager(inMemoryProductDal);
            //ProductTest();

            //  CategoryTest();

            ProductManager productManager1 = new ProductManager(new EfProductDal());
            var result = productManager1.GetAll();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

            Console.ReadLine();

            IDataResult<Product> dataResult;
            DataResult<Product> dataResult2 = new DataResult<Product>(true);
            SuccessDataResult<Product> successDataResult = new SuccessDataResult<Product>();
            ErrorDataResult<Product> errorDataResult = new ErrorDataResult<Product>();
            //IDataResult u DataResult implement ettigi icin IDataResult DataResult un referansini tutabiliyor
            //DataResult SuccessDataResult ve ErrorDataResult un base class i old icinde DataResult hem SuccessDataResult un hem de
            //ErrorDataResult un referansini tutabilir ve bu da demektir ki IDataResult tumunun referansini tutabilir
            //Ondan dolayi biz zaten IDataResult tipinde veri donecegiz diye belirtiriz ve sonun da return ederken
            //ister DataResult, ister SuccessDataResult istersek ErrorDataResul donebiliyoruz!!!!!!!!
            //dataResult = dataResult2;
            //dataResult = successDataResult;
            //dataResult = errorDataResult;
           

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetCategories())
            {
                Console.WriteLine(category.CategoryName);
            }

            Console.WriteLine("------------------CategoryDetail------------");

            var categoryName = categoryManager.GetById(2);
            Console.WriteLine(categoryName.CategoryName);
        }

        private static void ProductTest()
        {
            EfProductDal efProductDal = new EfProductDal();


            ProductManager productManager = new ProductManager(efProductDal);

            foreach (var product in productManager.GetAllByUnitPrice(40, 100).Data)
            {
                Console.WriteLine(product.ProductName + " | " + product.UnitPrice);
            }
        }
    }
}
