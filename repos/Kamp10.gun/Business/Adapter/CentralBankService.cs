using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapter
{//Burayi gercek bir servis olarak kabul edelim ve bunu sistemimize nasil dahil ederiz ona bakalim
    //Dikkat edelim method ismi de degisik return ile yapilan islem de de dolar fiyati degisik
    //Bunlari gercek bir servis gibi dusunelim diye  degisik yaptik ozellikle
   public class CentralBankService
    {
        public decimal ConvertCurrency(CurrencyRateDto currencyRate)
        {
            return currencyRate.Price / (decimal)5.28;
        }
    }
}
