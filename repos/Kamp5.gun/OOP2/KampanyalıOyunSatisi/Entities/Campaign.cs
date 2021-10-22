using System;
using System.Collections.Generic;
using System.Text;

namespace KampanyalıOyunSatisi.Entities
{
    public class Campaign : IEntity
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public double CampaignRate { get; set; }
        public double UnitPrice { get; set; }
        public double getUnitPriceAfterDiscount()
        {
            return this.UnitPrice - (this.UnitPrice * this.CampaignRate / 100);
        }






    }
}
