using System;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            //CASTING KULLANIM YERLERI
            //1)TUR DONUSUMLERINDE
            //Bir sayisal degeri mesela ondalikli bir sayiyi kendisinden daha az olan sayisal bir ture
            //bilincli bir sekilde donusturmek. 3.6 yi direk 3 e donusturmek veri kaybi olacagi icin casting
            //ile yapabiliyoruz yani casting ile biz diyoruz ki tamam ben bunu bilerek yapiyorum diyoruz
            int x = 4;
            float y = x;////Problem olmaz cunku veri kaybi olmaz int 4 u direk bunyesine alir
            int z =(int)y;//Burda veri kaybi yasanabilir onun icin casting yapariz 
            //Int eger a float deger atamaya calisirsak o zaman casting yapmaliyiz

            int sayi1 = 12;//int deger araligi olarak cok daha genis old icn deger kaybi ihtimali var
            short sayi2 = (short)sayi1;
            //2)BOXING->UNBOXING
            //
            object a = 34;//Elimizdeki object bir degere herhangi bir turu atarsak ne yapiyoruz boxing yapmis
            //oluyoruz 
            //Objecte donusturdugumuz bu integer degeri normal integer ile elde emtek istersem unboxing
            //yaparak elde etmek istersem cast operatoru ile elde deriz
            int b = (int)34;

            //3)Char->int e | int->CHARA  ASCII kanyak kodlari uzerinden donusum yaparken
            int sayi3 = 93;//93 ASCII kaynak kodlarindan neye karsilik geliyor onu bulmak istersek
            char c = (char)sayi3;


            Console.WriteLine("Hello World!");
        }
    }
}
