using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonManager personManager = new PersonManager();
            CustomerManager customerManager = new CustomerManager();
            EmployeeManager employeeManager = new EmployeeManager();
           
            
        }
    }
   public class PersonManager
    {
        public void Add()
        {
            Console.WriteLine("Eklendi");
        }

        public void Update()
        {
            Console.WriteLine("Guncellendi");
        }

    }


    public class CustomerManager:PersonManager
    {
        public void GetBestCustomer()
        {
            Console.WriteLine("En iyi calisan getirildi");
        }
    }

    public class EmployeeManager : PersonManager
    {
        public void GetBestEmployee()
        {
            Console.WriteLine("En iyi calisan  getirildi");
        }
    }
   

}
