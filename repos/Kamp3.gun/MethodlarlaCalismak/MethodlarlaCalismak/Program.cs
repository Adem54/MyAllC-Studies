using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodlarlaCalismak
{
    class Program
    {
        static void Main(string[] args)
        {
            //Default parametre ile çalışmak

            int result=Topla(20);
            Console.WriteLine("Result: "+ result);

            Console.WriteLine(Carpma(2));
            Console.WriteLine(Carpma(2,5));


            Console.ReadLine();



        }

        static int Topla(int sayi1, int sayi2=30)//Eğer kullanıcı bir tane parametre verirse 2. parametre olan
                                                 //sayi2 default olarak 30 verilir.Dolayısı ile bu method oluştururken
                                                 //2 parametre verilmesinie rağmen, 2.parametresine derfault değer
                                                 //atandığından dolayı  çalıştırılırken 1 parametre vererek de çalıştırılabilliri
         //Bu arada şuna dikkat edelim biz default değeri burda ilk parametremiz olan sayi1 veremiyoruz deffault
         //parametre değerleri herzaman parametrelerin en sonunda olması gerekiyor, yani ilk parametre hariç
         //diğerlerine default parametreler verebiliriz                                       
        {
            return sayi1 + sayi2;
        }

        static int Carpma(int sayi1, int sayi2=10, int sayi3 = 4)
        {//Burda yine ilk parametre hariç sondaki parametrelere default parametre verebildik ve artık bu methodu
         //tek parametre ile de çalıştıraibliriz veya 2 parametre ile de çalıştırabiliriz
            return sayi1 * sayi2 * sayi3;
        }
        //Biz methodlarımızda parametrelere default değerler atayabiliriz ki bundan dolayı da bazen 3 tane
        //parametre veririz sondan 2 sine default değer atarız bu kural gereği sondakilere deffault değer
        //atayabiliyoruz ilk parametreye değil ve artık biz methodu çalıştırırken default olarak verdiğimiz
        //parametreleri atamasak bile methodumz default değerleri kullanarak çalışacaktır
        //Gerçek hayat uygulamalarında eğer kdv hesaplamalarda eğer kdv değer verirse verilen değer kullanılsın ama
         //vermezse 18% kulanılsın şeklinde kullanılıyor
         //Yani özellikle belli bir standart değeri  olan ve bu standart değer bazen gelen veri kaynağına göre
         //değişme durumunda biz standart değerleri default olarak veririz ki eğer o parametre için değer
         //gelmzse biz standarta göre işlekm yapabilelim diye.
    }
}
