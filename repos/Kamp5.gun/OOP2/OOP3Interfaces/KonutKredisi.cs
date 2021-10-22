using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    class KonutKredisi : ICreditManager
    {
        public void Hesapla()
        {
            Console.WriteLine("Konut kredisi hesaplandi");
        }

        public void KredilerileriYazdir()
        {
            Console.WriteLine("Konut kredisi yazdirildi");
        }
    }
}
