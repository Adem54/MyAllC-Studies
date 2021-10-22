using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();
        }
    }

    class CustomerManager
    {
        public void Add()
        {
            Console.WriteLine("Veri Eklendi!");
        }
    }
}
