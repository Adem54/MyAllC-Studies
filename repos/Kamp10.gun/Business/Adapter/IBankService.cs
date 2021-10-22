using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Adapter
{
    //Bosta class imiz kalmamali mutlaka bir interface i olmali, bu onemli!!!!!!
    //Bu servisimizi hangi katmana yerlestiriyoruz onu tam bilmiyorum
    public interface IBankService
    {
        decimal ConvertRate(CurrencyRateDto currencyRate);
    }
}
