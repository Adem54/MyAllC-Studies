using HomeworkSolution.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkSolution.Concretes
{
    class UserValidationManager : IUserValidationService
    {
        public bool Validate(Gamer gamer)
        {
            if (gamer.BirthYear==1988 && gamer.FirstName=="Adem" && gamer.LastName=="Erbas" && gamer.IdendityNumber==12345)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
