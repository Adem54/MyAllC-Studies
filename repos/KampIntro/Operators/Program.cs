using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {

            int sayi1 = 13;
            int sayi2 = 3;

            Console.WriteLine(sayi1+=3);//3 artırmış oluyoruz. Artışı bu satır da da görürüz. 3 arttır sayi1 e ata diyoruz
            Console.WriteLine(sayi1=sayi1+3);//Burda bu satırda artar ve artışı bu satırda da görürüz
            Console.WriteLine(sayi1++);//Bu satırda arttırır ama artışı bu satırda göremeyiz bir alt satırda artış görürüz
            Console.WriteLine(sayi1);

            Console.WriteLine(sayi1%sayi2);//sayi1 in sayi2 ye bölümündek kalanı alıyoruz yani modunu alıyoruz

            Console.WriteLine(sayi1*=2);//sayi1 i 2 ile çarp ve sayi1 e ata demektir
            Console.WriteLine(sayi1/=10);//sayi1 i 10 a böl sayi1 e ata demektir

            //== operatörü, != eşit değildir operatörü
            //&& ve operatörü
            //|| veya operatörü
            //! değil operatörü yani var olan  birşeyi tersine çevirir, mesela bool veri tipinin başına koyarsak
            //true ise false, false ise true ya çevirir

           
            Console.ReadLine();


        }
    }
}
