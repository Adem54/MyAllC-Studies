using KampanyalıOyunSatisi.Abstracts;
using KampanyalıOyunSatisi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KampanyalıOyunSatisi.Concrete
{
    public class SaleManager : ISaleService
    {
        public void CampaignSale(Gamer gamer, Game game, Campaign campaign)
        {

            Console.WriteLine(gamer.FirstName + " adlı oyuncu " + game.GameName + " adlı oyunu " + campaign.CampaignName + " kampanyasıyla satın aldı.");
            Console.WriteLine(gamer.FirstName + " adlı oyuncu " + game.GameName + " adlı oyunu " + campaign.CampaignName + " kampanyasıyla " + campaign.getUnitPriceAfterDiscount() + " liraya satın aldı.");
        }

        public void Sale(Gamer gamer, Game game)
        {
            Console.WriteLine(gamer.FirstName + " adlı oyuncu " + game.GameName + " adlı oyunu satın aldı.");
        }
    }
}
