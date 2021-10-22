using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donguler
{
    class Program
    {
        static void Main(string[] args)
        {

            string sayi = "1";
            for (int i = 2; i <= 11; i++)
            {
                Console.WriteLine(sayi);
                sayi = sayi + i;
                
            }

            Console.WriteLine("////////////////////////////////////////////");

            for (int i = 0; i <=10; i++)
            {

                for (int j = 1; j <=i; j++)
                {
                    Console.Write(j);//Aynı satırda yazıyor kodu
                }

                Console.WriteLine("");//Kodu bir satır aşağı atıyor

            }

            int sayi2 = 1;
            while (sayi2 <= 6)
            {
                Console.WriteLine("Sayımız: " + sayi2);
                sayi2++;
            }


            int sayi3 = 1;
            do
            {

                Console.WriteLine("Sayı: "+sayi3);
                sayi3 += 1;
            } while (sayi3<=10);

            Console.ReadLine();
        }
    }
}
