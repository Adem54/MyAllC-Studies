using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapter
{
    //Bosta class imiz kalmamali mutlaka bir interface i olmali, bu onemli!!!!!!
    //public class CentralBankService : IBankService
    //{
    //    public decimal ConvertRate(CurrencyRateDto currencyRate)
    //    {
    //        //Buraya ifler yazip if dolar ise currencyRate.Price i dolar fiyati ile carp yok euro ise seklinde
    //        //yazariz...
    //        return currencyRate.Price / (decimal)5.30;//Dogrudan colara cevirdik surf simule etmek icin

    //    }
    //}

    public class FakeBankService:IBankService {
            public decimal ConvertRate(CurrencyRateDto currencyRate)
        {
            return currencyRate.Price / (decimal)5.30;
        }  }
  


   

   
}
