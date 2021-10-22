using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2Inheritance
{
    class PersonManager
    {
        //Buraya biz Person tiplerimizi kaydetmek istiyoruz ama hangi tipi yazarsak onu kaydedelim istiyoruz
        public void Add(Person person)
        {
            Console.WriteLine($"Person adi soyad eklendi :  {person.FirstName}-{person.LastName}");
        }
    }
}
