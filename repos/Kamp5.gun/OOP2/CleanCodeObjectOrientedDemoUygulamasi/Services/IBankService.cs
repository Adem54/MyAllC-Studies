using CleanCodeObjectOrientedDemoUygulamasi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeObjectOrientedDemoUygulamasi.Services
{
  public  interface IBankService
    {
        decimal ConvertRate(CurrencyRateDto currencyRateDto);
    }
}
