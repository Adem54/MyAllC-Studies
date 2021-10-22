using HomeworkTest.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTest.Services
{
  public  interface ISaleService
    {
        void Sell(Game game,User user,Campaign campaign);
    }
}
