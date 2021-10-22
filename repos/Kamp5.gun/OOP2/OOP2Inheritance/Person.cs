using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2Inheritance
{
    //Projelerimizi olustururken property class larinda stratejimiz bir tane tum property class larinda ortak olacak
    //porperties leri baridirian bir base class yazariz once bu base class diger property class lari tarafindan inherite edilir
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdendifyNumber { get; set; }
    }
}
