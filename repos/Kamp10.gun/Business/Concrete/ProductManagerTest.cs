using Business.Abstract;
using Business.Adapter;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManagerTest : IProductServiceTest
    {
        IBankService _bankService;
        public ProductManagerTest(IBankService bankService)
        {
            _bankService = bankService;
        }
        public void Sell(Product product, CustomerTest customerTest)
        {
            decimal price = product.UnitPrice;
            if (customerTest.CustomerTypeId==1)//
            {
                price = product.UnitPrice * (decimal)0.90;
            }
            else if (customerTest.CustomerTypeId==2)
            {
                price = product.UnitPrice * (decimal)0.80;

            }
            else if (customerTest.CustomerTypeId==3)
            {
                price = product.UnitPrice * (decimal)0.70;

            }
            //Dependency Injection ile bagimli olmadan bu degiskeni aldik!!!!
            price = _bankService.ConvertRate(new CurrencyRateDto { Currency = 1, Price = price });
            //Bu price i da gormek istersek indirim yapilmis halinin doviz karisilig
            Console.WriteLine(price);
            Console.ReadLine();

        }
    }
}
