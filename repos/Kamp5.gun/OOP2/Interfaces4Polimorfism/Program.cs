using System;
using System.Collections.Generic;

namespace Interfaces4Polimorfism
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Biz sonradan bir veritabni daha eklemek istersek hic sorun yasamadan sistemimize kolaylikla entegre edebiliriz..


            //OracleServerDal i sonradak ekledik ve mevcut kodlara dokunmadan dogrudan sistemimize entegre oldu

            SqlServerDal sqlServerDal1 = new SqlServerDal();
            MysqlServerDal mysqlServerDal = new MysqlServerDal();
            OracleServerDal oracleServerDal = new OracleServerDal();
            List<ICustomerDal> customerDalls = new List<ICustomerDal> { sqlServerDal1, mysqlServerDal,oracleServerDal };
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(customerDalls);//Bir liste verecegiz


            


            Console.ReadLine();
        }
    }
}

//POLIMORFISM
//Polimorfism cok bicimlilik demektir
//Bir nesneyi farkli amaclarla implement edip o implementasyonlarin belli bir kismina veya tamamina ulasmaktir
//KATMANLAR ARASI GECISTE KULLANDIK VE HEM SQL E HEM DE ORACLE ENTEGRE ETTIK SISTEMIMIZI
//BUNUN ADI ASLINDA POLIMORFISM DIR.ICustomer i HEM ORACLE BICIMINDE HEM DE SQLSERVER BICIMINDE
//IMPLEMENTE ETTIK
//Inherit ettigimiz nesne veya implemente ettigimiz interface uzerinden farkli nesneleri kkullanabilmemizdir
//Yani bir dependency injection olayi ile enjekte ettimiz bir interface ile onu implemente eden nesnelere
//ulasmamiz bir polimorfizmdir
//Mesela bir Abstract class i inherit eden 3 farkli nesnenin onun icindeki override methodunu
//hepsinin kendine gore implement etmesi farkli farkli implement etmesi iste cok bicimliliktir