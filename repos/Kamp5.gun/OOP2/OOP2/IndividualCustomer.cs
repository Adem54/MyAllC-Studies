using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{//implementasyon-uygulama demektir

    //Customer,Product,Employee,Person bunlar varliktir yani entity dir. Bundan dolayi bunlarin icinde operasyon olmaz. method yazilmaz
    class IndividualCustomer:Customer//IndividualCustomer Customer class inin inheritance aliyor
    //Sadece ona ait ozellikleri yaziyoruz buraya ortak olan Customer a yazdik zaten
    {
      
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
//Gercek hayatta da biz islerimizi parcalara ayiririz ki daha kolay yapalim birbirine karistirmamak icin ozellikle yoksa isler 
//spagettiye doner yani spagetti kod yazmak zorunda kaliriz