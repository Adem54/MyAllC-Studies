using HomeworkTest.Entities;
using HomeworkTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTest.Managers
{
    public class SaleManager : ISaleService
    {


        public void Sell(Game game,User user, Campaign campaign)
        {
            Console.WriteLine($"{user.FirstName} kullanicisina {game.GameName} oyunu " +
                $"{game.UnitPrice} fiyatindan {campaign.CampaignName} kampanyasi ile" +
                $" satilma islemi gerceklestirildi");
        }

        
    }
}
