using CleanCodeObjectOrientedDemoUygulamasi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeObjectOrientedDemoUygulamasi.Services
{
 public   interface ISaleService
    {
        void SaleTL(Customer customer,Product product);
        void SaleWithOtherCurrency(Customer customer, Product product, CurrencyRateDto currencyRateDto);
    }
}
