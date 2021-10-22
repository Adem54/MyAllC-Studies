using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3
{
    class MortgageCreditManager : ICrediManager//Interface i implement eden class lar interface imzalarini yani method isimlerini
        //kullanmak zournda ama o imzanin icerigini kendine gore doldurmalidir kendi kurallarina gore
    {
        public void Calculate()
        {
            Console.WriteLine("Konut kredisi odeme plani hesaplandi!");
        }

        public void CrediContracted()
        {
            Console.WriteLine("Konut kredisi alindi");
        }
    }
}
