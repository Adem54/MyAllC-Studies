using KampanyalıOyunSatisi.Abstracts;
using KampanyalıOyunSatisi.Entities;
using System;

namespace KampanyalıOyunSatisi
{
    public class CampaignManager : ICampaignService
    {
        public void Add(Campaign campaign)
        {
            Console.WriteLine(campaign.CampaignName + " adlı kampanya sisteme eklendi");
        }

        public void Delete(Campaign campaign)
        {
            Console.WriteLine(campaign.CampaignName + " adlı kampanya sistemden silindi");
        }

        public void Update(Campaign campaign)
        {
            Console.WriteLine(campaign.CampaignName + " adlı kampanya güncellendi");
        }
    }
}