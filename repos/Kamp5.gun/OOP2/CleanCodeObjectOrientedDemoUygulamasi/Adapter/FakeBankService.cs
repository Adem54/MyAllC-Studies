using CleanCodeObjectOrientedDemoUygulamasi.Entities;
using CleanCodeObjectOrientedDemoUygulamasi.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeObjectOrientedDemoUygulamasi.Adapter
{
    public class FakeBankService : IBankService
    {
        public decimal ConvertRate(CurrencyRateDto currencyRateDto)
        {
            if (currencyRateDto.Currency == 1)
            {
                return currencyRateDto.Price / 10;
            }
            else { return currencyRateDto.Price / 7; }



        }
    }
}
