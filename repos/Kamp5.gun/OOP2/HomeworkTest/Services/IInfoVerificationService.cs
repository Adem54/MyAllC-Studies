using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTest.Services
{
 public  interface IInfoVerificationService
    {
        bool CheckUserInfo(User user);
    }
}
