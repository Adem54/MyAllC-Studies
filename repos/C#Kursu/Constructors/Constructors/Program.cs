using System;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer() { Id=5,FirstName="Adem",LastName="Demir", City="Oslo" };
            customer.Id = 4;
            customer.LastName = "Leer";
            customer.City = "Stavenger";
            customer.FirstName = "Sercan";
            //new leme yaptigimiz zaman ki parantezimiz constructor u temsil ediyor aslinda
            //O parantez constructor in calistigini gosteriyor
            Customer customer2 = new Customer(3, "Ahmet", "Derin","Skien");
            Console.WriteLine(customer2.FirstName);
            Console.WriteLine(customer2.LastName);
            Console.WriteLine(customer2.Id);
            Console.WriteLine(customer2.City);


        }
    }

    public class Customer
    {
        //Default constructor
        public Customer(int sayi,string name1,string name2, string city )
        {
            Id = sayi;
            FirstName = name1;
            LastName = name2;
            City = city;


        }

        public Customer()//DEfault constructor//parametreli constructor yazdigimiz zaman burayi ezmis oluyoruz default
        {

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
