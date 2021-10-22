using System;
using System.Collections.Generic;

namespace OOP2Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person() {FirstName="Kasim",LastName="Servet" };
            Person person2 = new Person() { FirstName = "Murat", LastName = "Ari" };
            Person person3 = new Person() { FirstName = "Remzi", LastName = "Oya" };
            //Class ta olusan instancelerimizi bir class listi olusturup ona atabiliriz

            List<Person> persons = new List<Person>(){ person1, person2, person3 };

            foreach (var person in persons)
            {
                Console.WriteLine(person.FirstName+ person.LastName);
            }



            //Basse class-onu inherite eden tum class larin referansini alabiliyor
            Person employee1 = new Employee() {FirstName="Yusuf",LastName="Lale" };
            Person customer1 = new Customer() { FirstName = "Mert", LastName = "Kara" };
            Person internship1 = new Internship() { FirstName = "Ahmet", LastName = "Erik" };

            PersonManager personManager = new PersonManager();
            personManager.Add(employee1);
            personManager.Add(customer1);
            personManager.Add(internship1);

            //BOXING ILE Base class la olusturdugumuz instance uzerinden onu inherit eden class a ozeel bir propertye ulasmak
            ///Console.WriteLine((((Employee)person1).EmployeeNumber));

            Console.ReadLine();
        }
    }
}
