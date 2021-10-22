using System;

namespace Interfaces3
{
    class Program
    {
        static void Main(string[] args)
        {


            //INTERFACELER ONU IMPLEMENTE EDEN CLASS LARIN REFERANSLARINI TUTABILIYORLAR ONDAN DOLAYI BIZ INTERFACE I 
            //BIR OPERASYONDA PARAMETREYE VERINCE ONUN YERINE ONU IMPLENTE EDEN CLASS LARI DA METHOT CALISTIRILIRKEN PARAMET
            //REDE KULLANABILIYORUZ
            ICustomerDal customerDal1 = new SqlServerDal();
            ICustomerDal customerDal2 = new OracleServerDal();

            //KATMANLAR ARASI GECISTE KULLANDIK VE HEM SQL E HEM DE ORACLE ENTEGRE ETTIK SISTEMIMIZI
            //BUNUN ADI ASLINDA POLIMORFISM DIR.ICustomer i HEM ORACLE BICIMINDE HEM DE SQLSERVER BICIMINDE IMPLEMENTE ETTIK
            SqlServerDal sqlServerDal = new SqlServerDal();
            OracleServerDal oracleServerDal = new OracleServerDal();

            CustomerManager customerManager1 = new CustomerManager();
            customerManager1.Add(sqlServerDal);
            customerManager1.Add(oracleServerDal);

            





            Console.ReadLine();
        }
    }
}
