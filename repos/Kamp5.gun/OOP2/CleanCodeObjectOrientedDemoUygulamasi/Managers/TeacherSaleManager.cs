using CleanCodeObjectOrientedDemoUygulamasi.Entities;
using CleanCodeObjectOrientedDemoUygulamasi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeObjectOrientedDemoUygulamasi.Managers
{
 public   class TeacherSaleManager:SaleManagerBase
    {
        IBankService _bankService;
        public TeacherSaleManager(IBankService bankService)
        {
            _bankService = bankService;
        }
        public override void SaleTL(Customer customer, Product product)
        {
            decimal price = product.UnitPrice * (decimal)0.95;
            Console.WriteLine($"{customer.FirstName} musterisi  {product.ProductName } urunu icin" +
               $" {price} TL odedi");

        }

        public override void SaleWithOtherCurrency(Customer customer, Product product, CurrencyRateDto currencyRateDto)
        {
            decimal price = _bankService.ConvertRate(currencyRateDto) * (decimal)0.95;

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
