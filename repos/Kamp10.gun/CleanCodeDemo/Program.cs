using Business.Abstract;
using Business.Adapter;
using Business.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            //FAKE SERVISTEN KUR DONUSUMU YAPILIRSA
            //IProductService productService = new ProductManager(new FakeBankService());
            //productService.Sell(new Product { ProductId = 1, ProductName = "Laptop", UnitPrice = 1000 },
            //    new Customer { CustomerId = 1, FirstName = "Engin", IsStudent = true, IsOfficer = true });

            //GERCEK SERVISTEN KUR DONUSUMU YAPILIRSA
            //IProductService productService = new ProductManager(new CentralBankServiceAdapter());
            //productService.Sell(new Product { ProductId = 1, ProductName = "Laptop", UnitPrice = 1000 },
            //    new Customer { CustomerId = 1, FirstName = "Engin", IsStudent = true, IsOfficer = true });


            //IPersonService studentService = new StudentManager(new FakeBankService());
            //studentService.Sell(new Product { ProductId = 1, ProductName = "Laptop", UnitPrice = 1000 },
            //    new Student { Id = 1, FirstName = "Engin" });

            //IPersonService officerService = new OfficerManager(new FakeBankService());
            //officerService.Sell(new Product { ProductId = 1, ProductName = "Laptop", UnitPrice = 1000 },
            //    new Officer { Id = 1, FirstName = "Engin" });

            IProductServiceTest productServiceTest = new ProductManagerTest(new FakeBankService());
            productServiceTest.Sell(new Product { ProductId = 1, ProductName = "Laptop", UnitPrice = 1000 },
                new CustomerTest { CustomerId=1, FirstName="Engin", CustomerTypeId=3 });

        }
    }


  
  
}
