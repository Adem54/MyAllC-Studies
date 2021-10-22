using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces4Polimorfism
{
    class CustomerManager
    {
        //Eklenen verinin her iki veritabaninda da isleemlerini yapabilmek istiyorum
        //Amacim elimdeki veriyi tum veritabanlarina gondermek istiyorum
        //Veya elimdeki veriyi tum veritabanlarinda guncellemk ya da tum veritabanlarindan silmek istiyorum
        //ICustomerDal i hem SqlServerDal, hem MysqlServerDal hem de OracleServerDal implemente etmektedir
        //Iste bu CustomerManager da Add methodu icine List<ICustomerDal> paramtre olarak veriliyor
        //Ve bir Add islemi icinde hem SqlServerDal,MysqlServerDal hem de OracleServerDal a ekleme islemi
        //yapma firsati sunyor yani cok bicimlilik
        public void Add(List<ICustomerDal> customerDals)
        {
            foreach (var customerDal in customerDals)
            {
                customerDal.Add();
                customerDal.Delete();
                customerDal.Update();
            }
        }
    }
}
