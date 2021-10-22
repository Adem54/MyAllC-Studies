using HomeworkTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTest.Managers
{
    public class InfoVerificationManager : IInfoVerificationService
    {
        public bool CheckUserInfo(User user)
        {
            if (user.FirstName=="Adem" && user.LastName=="Erbas"&& user.PassportNo==12345)
            {
              
                return true;
            }else
            {
               
                return false;
            }
        }
    }
}
