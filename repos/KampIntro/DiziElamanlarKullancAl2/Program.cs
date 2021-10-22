using System;

namespace DiziElamanlarKullancAl2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            int[] sayilar = new int[4];
            int diziEleman;
            for (int i = 0; i < sayilar.Length; i++)
            {
                Console.WriteLine($"Dizinin {i+1}. elemanini giriniz:  ");
                diziEleman=int.Parse(Console.ReadLine());
                sayilar[i] = diziEleman;         

            }

            Console.WriteLine("sayilar dizisinin icerigine bakalim");

            foreach (var sayi in sayilar)
            {
                Console.WriteLine(sayi);
            }


            Console.WriteLine("Girilen sayının dizide olup olmaddığını kontrol etme");

            int sayi1 = int.Parse(Console.ReadLine());
            int[] dizi1 = { 6, 7, 2, 12, 6, 34, 55, 6, 8, 32 };

            int sayac = 0;
            for (int i = 0; i < dizi1.Length; i++)
            {
                if (dizi1[i]==sayi1)
                {
                    sayac++;
                    Console.WriteLine($"Bu sayi dizide {sayac}  kez bulunmaktadir..");
                }

            }

        }
    }
}
