using System;
using System.Threading;

namespace DelegateFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Delegate Func ile Calismak
            //Bir donus tipi olan methotlari calistirmak icin tasarlanmistir
            //Action da amacimiz belli kod bloklarini sarmallayip onlari gonderip  calistirmak idi
            //Action da biz asagida invoke ile bunu calistir diyorduk sadece ama func ta ise hem calistir
            //ayni zamanda bana bir de deger gonder diyebiliyoruz
            //FUNC YAZIMI
            Func<int, int, int> add = Topla;//Delegelerdeki gibi bu sekilde cagirilir cunku func tipinde
            //bir veridir ayni zaman da parametrelerden ilk 2 integer parametreden gelir sonuncu int ise
            //return olan yani result donus olandir
            //add operasyonu bir delegeye karsilik geliyor
            Console.WriteLine(add(3,5));
            //Func<int>//boyle birsey gorursek sunu anlamaliyiz yani eger bir tane deger tipi varsa generic
            //icinde o zaman o return dur yani parametresiz sadece return donduruyor demektir bunu anlama
            //liyiz
            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();//Random sayi veren class tir bu
                return random.Next(1, 100);
                
            };
            Console.WriteLine(getRandomNumber());//Her calistiginda biz 1-100 arasi sayi uretecektir
            //Aynen action gibi func i da bir kod blogu olarak parametreye gonderebiliriz

            Thread.Sleep(1000);//2 tane random deger ayni degeri donmesin diye aralarinda biraz zaman koymak
            //icin verilir
            //Yukarda yazzdigim delegasyonun aynisini farkli bir sekilde yapalim simdide
            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);
            //()=>parametresiz bir methoda delgasyon yapacagini anlariz buradan
            Console.WriteLine(getRandomNumber2());//Her calistiginda biz 1-100 arasi sayi uretecektir

        }

        static int Topla(int x, int y)
        {
            return x + y;
        }
    }
}
