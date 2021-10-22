using Business.Abstract;
using Business.Adapter;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class StudentManager : IPersonService
    {
        IBankService _bankService;
        public StudentManager(IBankService bankService)
        {
            _bankService = bankService;
        }
        public void Sell(Product product, IPerson person)
        {
            decimal price = product.UnitPrice;
            price = product.UnitPrice * (decimal)0.90;
            price = _bankService.ConvertRate(new CurrencyRateDto { Currency = 1, Price = price });
            Console.WriteLine(price);
            Console.ReadLine();
        }
    }
}
