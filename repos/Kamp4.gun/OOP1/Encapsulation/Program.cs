using System;

namespace Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person person = new Person();
            person.FirstName = "Jack";

            Console.WriteLine(person.FirstName);
            Console.ReadLine();
        }
    }
}
