using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CurrencyRateDto:IDto
    {
        public decimal Price { get; set; }
        public int Currency { get; set; }
    }
}
