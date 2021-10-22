using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodlar
{
    class Program
    {
        static void Main(string[] args)
        {
            SelamVer();

            Console.ReadLine();
        }
        //Return ile Değer Döndürmeyen Methodlar void ile yazılır

        public static void SelamVer()
        {
            Console.WriteLine("Selamlar, Meraba");

            int kare = KareAl(4, 5);
            Console.WriteLine("KareAl: "+ kare);
        }

        //Biz bu methodu Program class ının içerisinde yazdığımız için bu kodun çalışması için static
        //ile yazmak zorundayız
        //return ile değer döndüren methodlar void yerine veri türü ne ise onun ile yazılır
        public static int KareAl(int sayi1, int sayi2)
        {
            return (sayi1 * sayi1) + (sayi2 *sayi2);
        }
    }
}
