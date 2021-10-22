using System;

namespace DizilerleIlgiliUygulamalar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ArkadasSayiBulma();

            Console.WriteLine("/////////////////////////////////////////////////////////////7");

            //EnBuyukVeEnKucukElemaniBulma();

            //Console.WriteLine("------------------");

            //int girilenDeger = Int32.Parse(Console.ReadLine());

            //int sayi = 1;
            //for (int i = 0; i <girilenDeger ; i++)
            //{
            //    sayi = sayi * (i + 1);

            //}

            //Console.WriteLine("sayi="+ sayi);



        }

        //Bolenleri toplami birbirlerine esit olan sayiyi bulma!!
        private static void ArkadasSayiBulma()
        {
            int sayi1 = int.Parse(Console.ReadLine());
            int firstNumber = BolenlerininToplaminiBulma(sayi1);
            int sayi2 = int.Parse(Console.ReadLine());
            int secondNumber = BolenlerininToplaminiBulma(sayi2);


            if (sayi1 == secondNumber && sayi2 == firstNumber)
            {
                Console.WriteLine($"{sayi1} ve {sayi2} arkadas sayidir");
            }
            else
            {
                Console.WriteLine($"{sayi1} ve {sayi2} arkadas sayid degildir");
            }
        }

        private static int BolenlerininToplaminiBulma(int sayi1)
        {
            int toplam = 0;
            for (int i = 1; i < sayi1; i++)
            {
                if (sayi1 % i == 0)
                {
                    Console.WriteLine("i= " + i);
                    toplam += i;

                }
            }
            Console.WriteLine("toplam= " + toplam);
            return toplam;
        }

        private static void EnBuyukVeEnKucukElemaniBulma()
        {
            int[] sayilar = new int[6];
            sayilar[0] = 8;
            sayilar[1] = 2;
            sayilar[2] = 5;
            sayilar[3] = 7;
            sayilar[4] = 4;
            sayilar[5] = 11;



            int maks = sayilar[0];
            int min = sayilar[0];
            for (int i = 0; i < sayilar.Length; i++)
            {

                int current = sayilar[i];

                maks = maks >= current ? maks : current;
                min = min < current ? min : current;

            }
            Console.WriteLine("Dizinin en buyuk degeri= " + maks);
            Console.WriteLine("Dizinin en kucuk degeri= " + min);
        }
    }
}
