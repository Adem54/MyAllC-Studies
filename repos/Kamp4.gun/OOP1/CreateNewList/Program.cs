using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNewList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList1<int> numbers = new MyList1<int>();
            numbers.Add(36);
            numbers.Add(46);
            Console.WriteLine($"Liste eleman sayisi: {numbers.Length}");
            numbers.Add(64);
            numbers.Add(78);
            Console.WriteLine($"Liste eleman sayisi: {numbers.Length}");
            foreach (var item in numbers.GetItems)
            {
                Console.WriteLine(item);
            }



            Console.ReadLine();


        }
    }
}
