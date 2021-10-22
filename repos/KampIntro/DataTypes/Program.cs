using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            byte maxDeger = byte.MaxValue;
            byte minDeger = byte.MinValue;
            Console.WriteLine(maxDeger);
            Console.WriteLine(minDeger);

            //short,int,long
            //char
            //float,double
            //bool
            //object

            short shortMaxDeger = short.MaxValue;
            short shortMinDeger = short.MinValue;

            Console.WriteLine(shortMaxDeger);
            Console.WriteLine(shortMinDeger);

            //int-4 byte yer kaplar
            //8 bit 1 byte
            //1024 byte 1 KB
            //1024 KB 1 Gb
            //1024 GB 1TB

            //char veri tipindeki veriler tek tırnakla yazılır
            char karakter1 = 'E';
            Console.WriteLine(karakter1);
            //?,!,& tarzı karakterlerden 1 tane karakter tek tırnak içinde olmalıdır
            char karakter2 = '?';
            Console.WriteLine(karakter2);

            //float veri tipinde ondalık sayı tanımlayınca bunu defuault olarak double olarak tanıyor onun için ondalık sayı
            //kullanmak istediğimizde double ile kullanalım ama illaki float kullanmak istersek o zaman atadığımız değerin sonun f yazmamız gerekiyor
            float ondalikliSayi1 = 34.5f;
            Console.WriteLine(ondalikliSayi1);

            //object veri tipi tüm veri tiplerindeki değerleri tutabilen bir veritipidir tüm veri tiplerinin atasıdır
            object veri1 = 14;
            Console.WriteLine(veri1);
            veri1 = "Merhaba";
            Console.WriteLine(veri1);
            veri1 = 45.6;
            Console.WriteLine(veri1);
            veri1 = true;
            Console.WriteLine(veri1);
            //Hiç hata vermeden tüm değerleri yazdırıyor
        }
    }
}
