using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    class AracKredisi : ICreditManager
    {
        public void Hesapla()
        {
            Console.WriteLine("Arackredisi hesaplandi");
        }

        public void KredilerileriYazdir()
        {
            Console.WriteLine("Arac kredisi yazdirildi");
        }
    }
}
