using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            //Biz normalde aynı method u sadece parametreleri daha fazla sayıda kullanmak istediğimiz zaman aynı isimde
            //method u parametre sayısını arttırarak yazabiliyorduk ve buna da overlaod diyorduk
            //Peki biz parametrede diyelim ki 5,6,7,8,...50 tane paramtre kullanmamız gerekti sürekli olarak
            //overload mı yazacağız o zaman

            int result = Topla(1, 2, 3, 4, 5, 6);
            Console.WriteLine("result: "+ result);
            Console.ReadLine();


        }

        //PARAMS KEYWORD İLE ARRAY PARAMETRE ATAYARAK İSTEDİĞİMİZ KADAR SAYIYI PARAMETREYE ATAYABİLİYORUZ
        //Params keywordünden önce parametre de ayatabiliriz mesela 1 tane keyword tanımlarsak o zaman method çalışırken ilk 
        //parametre params dan önce tanımladığmız parametre için çalışır sonrakiler ise params ile tanımladoğmız array elemanı 
        //olarak çalışır ve Sum methodu ile içindeki tüm sayıları toplatabiliriz
        //Params ile tanımladıımız array parametresinden sonra parametre tanımlayamayzı burasına dikkat edelim
        static int Topla(int sayi1,params int[] numbers)
        {
            return numbers.Sum();
        }
    }
}
