using System;

namespace Interfaces2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //İşte interface ler biz hangi server ile veri eklemek istersek o server ile veri ekleyebilmemizi sağlıyor
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add(new SqlServerCustomerDal());
            customerManager.Add(new OracleServerCustomerDall());

            //Bu çok önemli ve hayat içerisinde kullanışlı
            //İlerde yeni bir veritabanı desteği getirdğimiz zaman direk bu sisteme adapte edebiliriz mevcut hiçbir koda dokunmadan bu işlemi yapabiliriz
            ICustomerDal[] customerDals = new ICustomerDal[2]
            {
                new SqlServerCustomerDal(),
                new OracleServerCustomerDall()
            };//Burda biz bir array oluşturduk 2 elemanlı ve eleman olarak da sırası ile olutşturduğumuz class lardan nesne veya
              //instance oluşturarak içine attık ve biz artık foreach ile bu array i döndürebiliriz

            foreach (var customerDal in customerDals)
            {
                customerDal.Add();//customerDal sıra ile dönen elemanlardır ve bu şekilde biz sırası ile tüm veriyi hem Oracle da hem de Sql de eklemiş oluyoruz
            }

        }
    }

    //Interface lerin temell kullanım amacı bir temel nesne veya operasyon oluşturup tüm nesneeri ondan implemente etmektir
    //Interface lere abstract nesne yani soyut nesne denir, Customer ve Student class ına ise somut nesne denir
    //Soyut nesneler tek başlarına hiç bir anlam ifade etmezler, bize lasım olan bir Customer ile veya bir Student ile ilgili işlemler yapmaktır
    //Fakat Student ta bir kişidir, Customer da bir kişidir onun için somut class larımız olan Customer ve Student soyut class ımızı olan IPerson ı implement eder
    //Interface lerde public kullanılmaz kendisi default olarak publictir zaten
    interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
    //Interface de tanımlanan property veya operasyonlar,methodlar vs onu implement eden(yani inheritance alan ama interface e implement
    //etti denir) class larda olmak zorundadır
    class Customer : IPerson
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Ayrıca müşteriye özel ayrı bir özellik de tanımlayabiliriz
        public string Adress { get; set; }
    }

    class Student : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }

}
