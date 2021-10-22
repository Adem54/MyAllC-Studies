using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakContinue
{
    class Program
    {
        static void Main(string[] args)

        {
            //57 te kadar olan sayıları yazdır
            for (int i = 0; i <= 100; i++)
            {
                if (i==57)//Eğer bu şart sağlanırsa döngüyü tamamen bitirir ve döngü den sonraki
                          //koda geçer, aşağğı doğru devam eder
                {
                    break;
                }
                Console.WriteLine(i);
            }

            Console.WriteLine("-------------------------------------------------------");
            //5 ve 6 hariç 10  a kadar olan sayıları yazdır
            //Continue dediğmiz anda o bulunduğu yerde kodu bitirip for döngüsnün şartına döner yani kendinden sonra
            //for bloğunun kodlarını çalıştırmaz ve doğrudan for döngüsünün parantezine döner
            for (int i = 0; i < 10; i++)
            {
                if (i==5 || i==6)
                {
                    continue;
                }
                Console.WriteLine(i);
            }

            //Çarpım Tablosu

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i + " ler çarpım");
                for (int j = 1; j <= 10; j++)
                {
                   
                    int sayi = i * j;
;                    Console.WriteLine(i+" * "+  j+" = " + sayi);
                }

              
            }

            Console.ReadLine();

        }
    }
}
