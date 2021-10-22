using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ifElseKararYapilari
{
    class Program
    {
        static void Main(string[] args)
        {
            NotOrtalama();

            Console.ReadLine();
        }

        public static void NotOrtalama()
        {
            Console.WriteLine("Birinci notu giriniz: ");
            int sayi1 = int.Parse(Console.ReadLine());
            Console.WriteLine("2. notu giriniz: ");
            int sayi2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Üçüncü notu giriniz: ");
            int sayi3 = int.Parse(Console.ReadLine());
            
            int ortalama = (sayi1 + sayi2 + sayi3) / 3;
            Console.WriteLine("Ortalama: "+ ortalama);
            if (ortalama>80 && ortalama<=100)
            {
                Console.WriteLine("Notunuz A+ dür");
            }else if(ortalama>60 && ortalama<=80)
            {
                Console.WriteLine("Notunuz A dır");
            }else if(ortalama>=40 && ortalama <= 60)
            {
                Console.WriteLine("Notunuz B+ dır");
            }else
            {
                Console.WriteLine("Notunuz FF dir");
            }
        }
    }
}
