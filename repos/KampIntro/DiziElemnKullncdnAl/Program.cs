using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziElemnKullncdnAl
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sayilar1 = new int[4];
            //4 elemanlı dizi oluşturup dizinin elemanlarını kullanıcıdan alma

            for (int i = 0; i < sayilar1.Length; i++)//dizinin eleman sayısı kadar dönderiyoruz
            {

                Console.Write("Sayılar dizisinin "+ (i+1) + " . index değerini giriniz: ");
                sayilar1[i] = int.Parse(Console.ReadLine());
                

            }

            foreach (var item in sayilar1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Girilen sayının dizide olup olmaddığını kontrol etme");

            int sayi1 = int.Parse(Console.ReadLine());
            int[] dizi1 = { 6, 7, 2, 12,6, 34, 55,6, 8, 32 };

            int sayac = 0;
            int adet = 0;
            int sayi4;

            foreach (var item in dizi1)
            {
                if (sayi1==item)
                {
                    adet++;
                    sayi4 = item;
                    Console.WriteLine(sayi1+" elemanı dizi1 içerisinde "+adet +" tane mevcuttur");
                    
                }
                else
                {
                    Console.WriteLine("Aradığınız elemen dizinin "+ sayac+ ". elemanında bulunamamıştır");
                }
                sayac++;

                if (item==dizi1[(dizi1.Length-1)])
                {
                    Console.WriteLine(sayi1+ " sayısı dizi içerisinde toplamda "+ adet +" kez tekrar etmiştir");
                }
            }

            Console.ReadLine();
        }
    }
}
