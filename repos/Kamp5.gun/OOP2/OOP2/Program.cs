using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Biz id ve customerNumber lara her iki property class imizda da ulasiyoruz cunku ikiside Customer i miras aldi
            //CUSTOMER I MIRAS ALDIKLARI ICIN ONDAKI OZELLIKLERE ONU MIRAS ALAN CLASS LAR ULASABILIYOR
            Console.WriteLine("Hello World!");
            //Once IndividualCustomer a verilerini yazalim
            IndividualCustomer individualCustomer = new IndividualCustomer();
            individualCustomer.Id = 1;
            individualCustomer.CustomerNumber = "12345";
            individualCustomer.FirstName = "Engin";
            individualCustomer.LastName = "Demirog";
            individualCustomer.IdentityNumber = "12345678910";

            //CorporateCustomer-kodlama.io
            CorporateCustomer corporateCustomer = new CorporateCustomer();
            corporateCustomer.Id = 2;
            corporateCustomer.CustomerNumber = "54321";
            corporateCustomer.CompanyName = "Kodlama.io";
            corporateCustomer.TaxNumber = 1234567890;

            //---------------------------------------------------------------------------------------------------------
            //ISTE ASIL ODAKLANMAMIZ GEREKEN VE ANLAMAMIZ GEREKEN KISIM!!!!!!
            //Customer class i hem IndividualCusotmer hem de CorporateCustomer class inin referansini tutabiliyor
            //Customer classi hem IndividualCustomer hem de CorporateCustomer class ina ait adresi bellein heap kisminda tutabiliyor
            //Artik ben Operasyonlarimda CustomerManager gibi mesela, parametreye sadece Customer class in i verdigim zaman 
            //Customer class ini inheritance alan tum class lari da o parametrede kullanabilecegim
          //ONEMLI!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //Base sinifimiz olan Customer bir referans tutucudur onu inherite eden siniflarin referansini tutabildigii icin
          //onu kullanabildgimiz yerlerde onu inherit eden class lari da kullanabiliyoruz aynen CustomerManager classinin Add 
          //methodunda parametrede Customer verdik ve artik orada hem Customer,hem IndividualCustomer hem de CorporateCustomer i 
          //parametre olarak verebiliyoruz

            Customer customer3 = new Customer();//Temel-Base
                                                //

            Customer customer1 = new IndividualCustomer();//Base sinifi inheherit eden IndividualCustomer class
            Customer customer2 = new CorporateCustomer();//Base sinifi inherit eden CorporateCustomer class 
            //
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new Customer());
            customerManager.Add(new IndividualCustomer());
            customerManager.Add(new CorporateCustomer());
            customerManager.Add(customer1);
            customerManager.Add(customer2);
            customerManager.Add(customer3);
            customerManager.Add(individualCustomer);
            customerManager.Add(corporateCustomer);
         
            
            //-------------------------------------------------------------------------------------------------------------

            Console.ReadLine();
        }
    }
}

//Gelen musteriyi veritabanina kaydedecek bir method, veya operasyon yazmak istiyoruz
//Operasyon classlari