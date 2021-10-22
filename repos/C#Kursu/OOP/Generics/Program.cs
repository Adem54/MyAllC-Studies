using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sayilar = new List<int>();
            sayilar.Add(2);
            sayilar.Add(5);

            sayilar[0] = 24;//Set islemi

         
                Console.WriteLine(sayilar[0]);//Get islemi
           
          
           

            Console.WriteLine("Hello World!");
            MyList<string> cities = new MyList<string>();
            cities.Add("Skien");
            cities.Add("Ski");
           cities[0] = "Kristiansand";
            Console.WriteLine("cities[0]= "+ cities[0]);
            Console.WriteLine(cities.Count);

            foreach (var item in cities.GetItem)
            {
                Console.WriteLine(item);
            }
           

            }
        }
   




}
