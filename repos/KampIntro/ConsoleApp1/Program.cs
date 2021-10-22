using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diziler
{
    class Program
    {
        //Biz Farklı Farkı türlerde dizi oluşturabiliriz, class da bir türdür class a da bir dizi oluşturabiliriz
        static void Main(string[] args)
        {
            Console.WriteLine("Merhaba");

            string[] isimler1 = { "Ahmet", "Mehmet", "Kemal", "Serkan" };

            foreach (var isim in isimler1)
            {
                Console.WriteLine(isim);
            }
            Console.WriteLine("---------------------------");
            string[] isimler2 = new string[4];
            isimler2[0] = "Jack";
            isimler2[1] = "Adam";
            isimler2[2] = "Bjarne";
            isimler2[3] = "Maria";

            foreach (var isim in isimler2)
            {
                Console.WriteLine(isim);
            }
            Console.WriteLine("--------------------------------");
            int[] sayilar1 = new int[] { 2, 3, 5, 6 };
            foreach (var sayi in sayilar1)
            {
                Console.WriteLine(sayi);
            }

            double[] notlar1 = new double[] { 1.3, 2.4, 4.5 };


            Console.ReadLine();


        }
    }
}
