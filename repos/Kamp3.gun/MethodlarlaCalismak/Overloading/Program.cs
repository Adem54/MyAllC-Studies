using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    class Program
    {
        static void Main(string[] args)
        {


            int result1 = Multiply(5, 6);
            Console.WriteLine("result1 "+result1);

            int result2 = Multiply(5,6,2);
            Console.WriteLine("result2 "+ result2);
            Console.ReadLine();
        }

        static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
        //METHODLARDA OVERLOADING
        //Bizim yukardaki Multiply fonksiyonunu çalıştırırken bazen de 2 parametre yerine 3 parametre kullanma ihtiyacımız
        //oluyorsa eğer o zaman biz aynı method ismi ile bir method yazabiliyoruz çünkü parametreyi 3 tane kullanıyoruz,
        //parametre sayılarımız farklı olduğu müddetçe aynı isimde method birden fazla yazabiliyoruz ihtiyacımıza göre işte
        //bunun adına methodlarda overloading deniyor
        static int Multiply(int number1, int number2, int number3)
        {
            return number1 * number2 * number3;
        }
    }
}
