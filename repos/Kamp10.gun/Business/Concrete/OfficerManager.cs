using Business.Abstract;
using Business.Adapter;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OfficerManager : IPersonService
    {
        IBankService _bankService;
        public OfficerManager(IBankService bankService)
        {
            _bankService = bankService;
        }
        public void Sell(Product product, IPerson person)
        {
            decimal price = product.UnitPrice;
            Console.WriteLine(price + "  OfficerService");
            price = product.UnitPrice * (decimal)0.80;
            Console.WriteLine(price + "  OfficerService");
            price = _bankService.ConvertRate(new CurrencyRateDto { Currency = 1, Price = price });
            Console.WriteLine(price+  "  OfficerService");
            Console.ReadLine();
        }
    }
}
