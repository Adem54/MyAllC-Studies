using HomeworkTest.Entities;
using HomeworkTest.Managers;
using System;

namespace HomeworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User();
            user1.FirstName = "Adem";
            user1.LastName = "Erbas";
            user1.PassportNo = 12345;
            Game game1 = new Game();
            game1.GameName = "GameOfThrones";
            game1.UnitPrice = 30;
            Campaign campaign = new Campaign();
            campaign.CampaignName = "Economic Campaign";
            campaign.ProcentOfCampaign = 0.20m;
            InfoVerificationManager infoVerificationManager = new InfoVerificationManager();
            UserManager userManager = new UserManager(infoVerificationManager);
            userManager.Add(user1);
            SaleManager saleManager = new SaleManager();
            saleManager.Sell(game1,user1, campaign);
      }
    }
}
