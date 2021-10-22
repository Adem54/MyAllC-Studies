using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefOutKeywords
{
    class Program
    {
        static void Main(string[] args)
        {

            int number1 = 20;
            int number2 = 100;
            //Parametreye bizim yazdığımız değişkenleri doğrudan değerleri olarak düşünelim orda o değişken isimlerinin
            //yazmasının önemi yok sadece mesele o değişkenlerin değerleridir
            //değişken olan number1 imizin method ile alakası sadece parametreye gelir 20 değerini verir ve artık
            //hiç bir ilişkisi kalmaz, methodun içindeki olan değişiklikler onu bağlamaz
            int result = Topla(number1, number2);//Bu methodun parametresine biz yukarda tanımladığımız değişkenleri
                                                 //verdiğimiz zaman aslında sadece onların değerini vermiş oluyoruz yani biz
                                                 //parametreye yukarda tanımladığımız number1 değişkeninin sadece değerini kullanır
                                                 //Method içerisindeki 1.parametreye tekrar değer atanması sadece parametrenin 
                                                 //değerini değiştirmek içindir yoksa method içerisinde dışardan gelen bir 
                                                 //değişkenin değerini değiştirmek değildir

            Console.WriteLine("result: "+ result);
            Console.WriteLine("number1: "+ number1);//Number1 yine 20 dir çünkü number1

            Console.WriteLine("-------------------------------");


           

            int sayi1 = 5;//Ref keywordü ile değer tipden ref tipe dönüştürme de buraya mutlaka değer atanmalı sadece tanımlamak yeterli olmaz
            int sayi2 = 12;
            
            
            int result1 = Carpma(ref sayi1, sayi2);//Methodu çalıştırırken de başına ref yazmalıyız
            
            
            Console.WriteLine("result1: "+ result1);
            Console.WriteLine("sayi1: "+sayi1);

            Console.WriteLine("-----------------------------------");
            int nummer1 ;//Eğer değer tipden ref tipe dönüştürmeyi out ile yaparsak o zaman  nummeret1 i sadece tanımalamız da yeterli olur veya
                         //istersek de değer de atayabiliriz ama aslına değer atamamızın çok bir esprisi yoktur çünkü method içerisinde parametreye
                         //atadğımız bu değerin set edilmesi gerekir yani yeni bir değer atanması gereki out ta yoksa o zaman sorun alırz ancak ref
                         //keywordünde de böyle bir zorunluluk yoktur
                         //ref keywor dü ile mutlaka değer atanmalıdır sadece tanımalamk yeterli olmaz
            int nummer2 = 5;

            int result2 = Bolme(out nummer1, nummer2);
            Console.WriteLine("result2= "+ result2);

            Console.WriteLine("nummer1= "+ nummer1);

            Console.ReadLine();
        }

        static int Topla(int number1, int number2)
        {
            //number1 = 30;
            return number1 + number2;
        }
        //DEĞER TİPLERİN REFERANS TİP GİBİ KULLANILMASININ SAĞLANMASI-REF KEYWORD

          //Biz methodumuzu çalıştırırken parametreye verdiğimiz değer içerde parametrede yapılan değişikliklerden etkilenmesini
          //istersek o zaman biz bu değerin başına ref int sayi1 şeklinde yazarak onu ref tip gibi yazarız ve biz methoduz
          //çalıştırırken sayi1 değişkenini parametreye atdağımız zaman parametre sayi1 in adres ini tutmaya başlar ve 
          //o parametre method içerisinde tekrardan yeni bir atama olunca tabi ki artık dışarda parametreye ref tip olarak
          //atadığımız sayi1 method içerisindeki değişiklikten etkilenecek çünkü onunla birlikte aynı adresi tutan parametrede 
          //bir değişiklik oluyor yani aynı adresi tutuyorlar doğal olarak dışardaki sayi1 de ondan etkileniyor ve artık
          //yeni değer olarak method içerisinde atanan değeri almış oluyor
         static int Carpma(ref int sayi1, int sayi2)
        {
            sayi1 = 10;
            return sayi1 * sayi2;
        }

        //OUT KEYWORD ILE DEGER TIP TEN REFERANS TIPINE DONUSTURME
        //ref keywor dünden farkı şudur ki nummer1 int değerine Main methodu içerisinden sadece tanımlaması da yeterli oluyor out ile ama ref keywordünde 
        //Main içerisidnde tanımlayıp da parametre olarak atadığmız nummer1 değerini sadece tanımlamak yetmez aynı zamanda değer de atanmak zorundadır,
        //eğer ref keyword ü ile biz değer tipi ref tipe dönüştürürken
        //Out keyword unde de dışardan değer atadğımız parametre değerinin mutlaka method içerisidne set edilmesi yani yeni bir değer
        //atanması gerekiyor atanmazsa o zaman hata alırız bu çok önemli!
        static int Bolme(out int nummer1, int nummer2)
        {
            nummer1 = 20;
            return nummer1 / nummer2;
        }
    }
}
//REF KEYWORD-DEĞER TİPLERİN REF. TİP GİBİ KULLANILMASI NERDE İHTİYACIMIZ OLUR
//Gerçek hayatta nasıl kullanırız.Örneğin bir banka da kredi hesaplaması yapıyorsunun kredi oranı var onu dışardan alıyorsunuz
//Aldığınız kredi oranına göre hesaplarken müşterinin tipine göre ekstra bir indirim oranı kazandı o zaman dışardan aldığınız o
//parametre müşterinin durumuna göre method içinde değişmesi gerekiyor ve ayrıca method daki işlem bittikten sonra işlemin 
//devamında bizim müşteriye uyguladığımız özel indirim olan veriye ihtiyaç devam ediyorsa method içindeki değere dışarda da
//ihtiyacımız varsa o zaman bu şekilde çalışmalıyız

//Ref mi Out mu kullancağız? Değer Tipi Ref Tipe Dönüştürürken
//Eğer biz parametreye atayacağımız değeri baştan set etme ihtiyacımız varsa o zaman ref kullanırız yoksa o zaman out kullanırız