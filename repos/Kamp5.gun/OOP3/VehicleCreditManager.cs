using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3
{
    class VehicleCreditManager : ICrediManager
    {
        public void Calculate()
        {
            //Tasit kredisine has olan kodlari icerikte yaziyoruz
            Console.WriteLine("Tasit kredisi odeme plani hesaplandi");
        }

        public void CrediContracted()
        {
            Console.WriteLine("Tasit kredisi  alindi!");
          
        }
    }
}
