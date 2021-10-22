using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    class EsnafKredisi : ICreditManager
    {
        public void Hesapla()
        {
            Console.WriteLine("Esnaf kredisi hesaplandi");
        }

        public void KredilerileriYazdir()
        {
            Console.WriteLine("Esnaf kredisi yazdirildi");
        }
    }
}
