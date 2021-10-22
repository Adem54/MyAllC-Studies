using System;

namespace ReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Array ler,class lar,interface ler,method lar referanse tiplerdir... 

            Person person1 = new Person();
            person1.FirstName = "Engin";
            Person person2 = new Person();
            person2 = person1;
            Console.WriteLine("person2.FirstName="+ person2.FirstName);
            person1.FirstName = "Adem";
            Console.WriteLine("person2.FirstName=" + person2.FirstName);
            Person person3 = new Person();
            Customer customer1 = new Customer();
            Employee employee1 = new Employee();
            person3 = customer1;
            person3 = employee1;
            //Base class instancesi  olan person3 yani inherit edilen class olan Person dan 
            //Base class onu inherit eden nesnelerin,class larin adresini yani referansini tutabiliyor....
            //Bu cok kritik bir bilgidir....

            //BOXING OLAYI ILE INHERIT EDEN CLASS LARDAN BIRINE BIZ BASE CLASS UZERINDE ERISEBILDIK!!!
            string crediCartNumber=(((Customer)person3).CreditCardNumber);
            //Boxing bizim direk person3 uzerinde onun adresine gitmemizi sagliyor..

           
            

        }
    }

    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }

    class Customer:Person
    {
        public string CreditCardNumber { get; set; }

    }

    class Employee:Person
    { 
        public int EmployeeNumber { get; set; }
    }
}
