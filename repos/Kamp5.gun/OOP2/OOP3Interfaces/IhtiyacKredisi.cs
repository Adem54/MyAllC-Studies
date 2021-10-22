using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    class IhtiyacKredisi : ICreditManager
    {
        public void Hesapla()
        {
            Console.WriteLine("Ihtiyac kredisi hesaplandi");
        }

        public void KredilerileriYazdir()
        {
            Console.WriteLine("Ihtiyac kredisi yazdirildi");
        }
    }
}
