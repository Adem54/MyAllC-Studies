using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3
{
    class ShopkeeperCreditManager : ICrediManager
    {
        public void Calculate()
        {
            Console.WriteLine("Esnaf kredisi odeme plani hesaplandi!");
        }

        public void CrediContracted()
        {
            Console.WriteLine("Esnaf kredisi alindi");
        }
    }
}
