using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeObjectOrientedDemoUygulamasi.Entities
{
  public  class CurrencyRateDto
    {
        public decimal Price { get; set; }
        public int Currency { get; set; }//Hangi kura cevrilecek...Burda kurlar numarali yani orn dolarsa 1
        //euro ise 2 gibi...
    }
}
