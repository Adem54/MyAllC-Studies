using System;

namespace Inheritances
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Customer customer = new Customer();
            customer.FirstName = "Kemal";

            Person[] persons = new Person[3]
            {
               new Customer(){FirstName="Engin" },
               new Student(){FirstName="Demir" },
               new Person(){FirstName="Serkan"}

            };//Class ın inheritannce edilmesi ile interface in implement edilmesi arasındaki fark şudur ki
              //interface tek başına bir anlam ifade etmez onun için biz implement edilmiş interface den array
              //oluşturunca içerisine interface atamıyoruz ama inheritance olarak alınmış bir class dan oluşturula
              //n array a o class ı da atabiliyoruz tek başına da o class bir anlam ifade ediyor ama interface
              //tek başına bir anlam ifade etmiyor 
              //Yani inheritance olan class ın kendisi de operasyon çalıştırabiliyor bu önemli...
              //Ayrıca interface den farklı olarak, biz bir class a birden fazla interface implement edebiliyorduk
              //ama class larda bir class bir den fazla inheritance yapamaz yani bir class ın bir tane babası olur
              //Ama bir class hem inheritance hem de impelement edecekse o zaman önce inheritance class ı yazılır daha
              //sonra da implement edilecek interface isimleri yazılır

            //Normalde inheritance mi interface mi hangisini kullanalım dersek interface ler inheritance
            //gibi de kullanılabildiği için öncelikli olarak inheritance lar kullanılabilir yani eğer inheritance yi
            //kullanmanı zorunlu oldğuğu düşünülmüyorsa interface lerden yürümek mantıklı olabilir ama özellikle
            //interface leri nerde kullanabiliriz ona bakalım Abstract sınıflar için ise inheritance kullanmalıyız

            foreach (var person in persons)
            {
                Console.WriteLine(person.FirstName);
            }
            Console.ReadLine();
        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    class Customer:Person //Bu şekilde yazdığımız zaman artık Customer Person ı inheritance aldı yani
                          //Person artık Customer ın babası gibidir dolayısı ile Customer Person içindeki
                          //tüm özelliklere ulaşabilir
                          //Person Customer ın babasıdır yani
                          //Ayrıca customer ın kendine ait özellikleri de olabiir yani babasında olmayan
                          //ama kendinde olan özellikler de olabilir
    {

    }

    class Student:Person
    {

    }
}
