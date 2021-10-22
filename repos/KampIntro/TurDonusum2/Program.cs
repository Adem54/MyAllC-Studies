using System;

namespace TurDonusum2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir sayi giriniz!");


            int value1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Bir sayi daha giriniz!");
            int value2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(value1+value2);

            int x = 23;
            int y = 34;

            string a = x.ToString();
            string b = y.ToString();

            Console.WriteLine(("a+b= ")+ (x + y));

            double z=23.6;
            int f = Convert.ToInt32(z);
            Console.WriteLine($"f: {f}");

            float k = 12.5f;
            int l = Convert.ToInt32(k);
            Console.WriteLine($"l: {l}");


        }
    }
}
