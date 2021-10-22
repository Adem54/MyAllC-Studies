using Business.Abstract;
using Business.Adapter;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Herhangi disardan bir servise bagimli olmamasi icin kendi servisimizi yazariz ve onu da yine
        //Dependency injection yolu ile baska bir class ta kullanarak bagimliligi ortadan kaldiririz
        IBankService _bankService;
        public ProductManager(IBankService bankService)
        {
            _bankService = bankService;
        }
        
   
       
        public void Sell(Product product, Customer customer)
        {
            decimal price = product.UnitPrice;
            if (customer.IsStudent)
            {
                price = product.UnitPrice * (decimal)0.90;
            }
            if (customer.IsOfficer)
            {
                price = product.UnitPrice * (decimal)0.90;
            }
            //Dependency Injection ile bagimli olmadan bu degiskeni aldik!!!!
           price= _bankService.ConvertRate(new CurrencyRateDto { Currency = 1, Price = price });
            //Bu price i da gormek istersek indirim yapilmis halinin doviz karisilig
            Console.WriteLine(price);
            Console.ReadLine();


                }
    }

  
}
