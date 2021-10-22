using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTest.Entities
{
  public  class Campaign:IEntity
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public decimal ProcentOfCampaign { get; set; }
    }
}
