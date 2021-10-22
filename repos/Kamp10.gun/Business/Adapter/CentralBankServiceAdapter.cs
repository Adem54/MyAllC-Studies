using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapter
{//Bu adapter class ini biz gerceek bir servisi sistemimize dahil etmek icin yazdik ondan dolayi
    //bu adapter zaten gercek sistemi sistemimize dahil edecegi icin bunun icerisinde biz
    //gercek sistemin class ini new leyebiliriz....
    //Biz bu adapterimizi kurdugumuz sitemde Fake servisimizin interface i olan IBankServici interface
    //olarak veririz...ve biz sistemimize iste bu adapter class i uzerinden ayni dependency injection
    //olaynda hicbbirseye dokunmadan sisteme dahil edebiliuyoruzzz!!!!
    public class CentralBankServiceAdapter : IBankService
    {
        public decimal ConvertRate(CurrencyRateDto currencyRate)
        {
            CentralBankService centralBankService = new CentralBankService();
            return centralBankService.ConvertCurrency(currencyRate);
        }
    }
}
