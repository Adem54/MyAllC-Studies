using System;

namespace RefAndOutKeywords
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = 20;
            int number2 ;
            var result = Add2(ref number1,out number2);
            
            Console.WriteLine("result "+ result);
            Console.WriteLine("number1: "+number1);
            Console.WriteLine("number2: "+number2);
            Console.ReadLine();
        }

        static int Add1(int number1=20,int number2=30)
        {
            var result1 = number1 + number2;
            return result1 ;
        }
        //DIKKAT!!!!!
       
        //biz disarda parametrelere deger veriyoruz mesela disarda parametrelere deger verirken
        //degisken adini number1 yapalim diyelim ama bu number1 in Add2 methodunun parametresi
        //olan number1 ile alakasi yok cunku o bir parametre sen hangi degeri verirsen onu alir
        //degisken olarak degil deger olarak alir ve methodu icine deger olarak gider....
        //DEGER TIP YANI....
        //Dolayisi ile parametreler aldigi degerin degiskeninin ne oldugu ile ilgilenmez
        //Deger i alir gecer onun icin Add2 icindeki number1=30 olayinin
        //Ya da soyle dusunelim disarda atanan number1 degiskeni deger tip oldugu icin degerini
        //verir ve gecer baska birsey bilmez
       //REF KEYWORDU
        //Ama biz eger olusturdgumuz number1 degiskeni parametreye verdigimiz zaman icerdeki degi
        //sikliklerden etkilenmesini istiyorsak o zaman refkeywordu ile gondeririz ve ref basina
        //eklersek o zaman number1 artik method icinde aldigi deger donusur
        //parametredeki number1 e ref ekleyerek diyoruz ki sen sana degeri atayan number1 in refe
        //ransini kullandiyoruz ve artik onun referansini kullaniyor ve ref degerlerde
        //sonra dan degisince icerik ayni referans turundeki tum elemanlarda da degisir
        //Parametreye disardan atayacagimiz deger parametre icerisinde degisebilecegini bek
        //liyorsaniz ve sizin icin gecerli is kodu ise o zaman onu ref olarak gondeririz
        //OUT KEYWOR DU GIRMEMIZ GEREKIYOR
        //Ref keywordunde disardan bir number1 degiskeni mutlaka set edilmelidir ama
        //out ta boyle bir zorunluluk yoktur
        static int Add2(ref int number1,out int number2)
        {
            number1 = 30;
            number2 = 50;
            return number1 + number2;

        }
    }
}
