using CleanCodeObjectOrientedDemoUygulamasi.Entities;
using CleanCodeObjectOrientedDemoUygulamasi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeObjectOrientedDemoUygulamasi.Managers
{
  public  class UsualClientManager:SaleManagerBase
    {
        IBankService _bankService;
        public UsualClientManager(IBankService bankService)
        {
            _bankService = bankService;
        }
        public override void SaleTL(Customer customer, Product product)
        {
            base.SaleTL(customer, product);
        }

        public override void SaleWithOtherCurrency(Customer customer, Product product, CurrencyRateDto currencyRateDto)
        {
            currencyRateDto.Price = product.UnitPrice;
            decimal price = _bankService.ConvertRate(currencyRateDto);
            if (currencyRateDto.Currency == 1)
            {
                Console.WriteLine($"{customer.FirstName} musterisi  {product.ProductName } urunu icin" +
               $" {price} EURO odedi");
            }
            else
            {
                Console.WriteLine($"{customer.FirstName} musterisi  {product.ProductName } urunu icin" +
               $" {price} DOLAR odedi");
            }
            
        }
    }
}
