using KampanyalıOyunSatisi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KampanyalıOyunSatisi.Abstracts
{
    public interface ISaleService
    {
        void Sale(Gamer gamer, Game game);
        void CampaignSale(Gamer gamer, Game game, Campaign campaign);
    }
}
