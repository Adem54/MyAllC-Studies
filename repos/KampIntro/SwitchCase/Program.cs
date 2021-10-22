using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchCase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kullanıcıdan alınan değere göre bazı işlemler yapan bir uygulama yapalım switch case kullanarak
            // 1-Bakiye görüntüle
            // 2-Para çek
            // 3-Para yatır
            // 4-Çıkış Yap
            // 1-2-3-4 dışında bir değer girilirse hata versin

            Console.WriteLine("Bir sayı giriniz");

            int sayi = int.Parse(Console.ReadLine());

            switch (sayi)
            {
                case 1: Console.WriteLine("Bakiye görüntüle");
                    break;
                case 2: Console.WriteLine("Para Çek");
                    break;
                case 3: Console.WriteLine("Para Yatır");
                    break;
                case 4: Console.WriteLine("Çıkış Yap");
                    break;

                default:
                    Console.WriteLine("1,2,3,4 dışında bir sayı girdiniz Hatalı giriş!!!!");
                    break;
            }
            Console.ReadLine();
        }
    }
}
