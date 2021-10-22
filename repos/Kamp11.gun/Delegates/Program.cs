using System;
using System.Collections.Generic;

namespace Delegates
{
    
    public delegate void MyDelegate();//Bu elcilik tanimidir burdan instance olusturarak bu formata ozel 
    //elci instanceleri olusturmus oluruz.Bir delegeden birden fazla elcilik yapan delege olusturabiliriz
    //Bu bir elci(delegate)
    //Yazdigimiz MyDelegate delegesi su anlama geliyor birsey dondurmeyen void methodlara ve
    //parametre almayan operasyonlara delegelik yapiyor diyebiliriz
    //Yani biz MyDelegate delegesini void ve parametre almayan methodlarda kullanabiliriz
    
    //Parametre alan bir delege de olusturalim bir tane
    public delegate void MyDelegate2(string text);
    //Herhangi  birsey dondurmeyen yani void olan void donduren ve parametre olarak string
    //tipde bir parametre alan bir delegdir
    public delegate int MyDelegate3(int number1, int number2);//2 tane int parametresi olan ve int donduren
    //operasyonlara methodlara hizmet eden bir delegedir

    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert();

            //Delegemizii kullanmak
            MyDelegate myDelegate = customerManager.SendMessage;
            //myDelegate CustomerManager in SendMessagina delege edilmis durumda
            //Burda yaptigimiz islem delegeye hangi bilgiye elcilik yapacagini soyledik ama henuz 
            //bu bilgiyi nereye ulastiracagini gorevini yerine getirmesini bildirmedik
            
            myDelegate();//Simdi gorevini yapiyor
            Console.WriteLine("---------");
            myDelegate += customerManager.ShowAlert;
            myDelegate();
            //Delegelerle yapacagimiz islemleri arka arkaya toplayabiliriz bu sekilde mesela
            //yemek yapma surecinde adim adim uzeirne koya koya gideriz sogan dogra,tavaya yag koy
            //sogani kavur gibi
            //Yapilacak islemleri belli bir siraya koyup en nihayetinde cagirma islemi  yapabiliyorum 
            //Projelerimizde delegeler siklikla bu amacla kullanilabilir
            //Delegeler daha guncel formatta kullaniliyor
            //Bir sarta gore calis diyebiliriz yani yukarda delegemize dedikki git once bir selam ver 
            //sonra da dikkatli ol dedik ama biz diyebiliriz ki hic selam falan gonderme direk dikkatli ol
            //demek isteyebiliriz boyle durumlarda yapmak istedigimiz islemi geri almak icin
            //-= ile yapmak istedigimiz islemi geri de alabiliriz
            myDelegate -= customerManager.SendMessage;
            Console.WriteLine("-------");
            myDelegate();//Sadece be careful sonucu verir

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;

            myDelegate2("Merhaba");//Bu degeri her iki parametre icin de kullanacagi icin 2 kez Merhaba yazar
            //Objelerle calisarak mesaji degistirebiliriz

            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Topla;
            var sonuc = myDelegate3(5, 3);
            Console.WriteLine(sonuc);
            myDelegate3 += matematik.Carp;
            Console.WriteLine("---------------------------");
            //Delegelerde eger return donen bir operasyona uygulanan delege ise ve iki tane operasyon birden
            //delegeye arka arkaya kullanirsak o zaman en son return ne donduruyorsa bize onu verecektir
            var result = myDelegate3(5, 3);
            Console.WriteLine(result);

            //ACTION ILE CALISMAK
            //Action dedigimiz bir operasyona veye methoda karsilik gelir method ve void olanlari calistirmak
            //uzere tasarlanmis bir mimaridir
            //Biz exception yonetiminde try-catch ile yonetiyorduk ama her seferinde try-catch yazmak
            //yorucu olabilir onun icin merkezi bir exeption ortami olusturabiliriz

            HandleException(() =>//Parametresiz bir methoda delege edecegimizi soyluyoruz burda
            {
                Find();//Action icin gonderilen kod blogudur ve HandleException da invoke diye calistirilir
            });
       

            Console.ReadLine();
        }

        //Boyle bir meethod yazariz ve methoda parametre olarak action gondeririz
        private static void HandleException(Action action)//Bu kod blogudur yani methodun iceriigidir
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
        }

        private static void Find()
        {
            List<string> students = new List<string> { "Engin", "Derin", "Salih" };
            if (!students.Contains("Ahmet"))
            {
                throw new RecordNotFoundException("Record Not Found");
            }else
            {
                Console.WriteLine("Record Found");
            }
            
        }
    }

   public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Hello");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be Careful!");
        }
        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }

    }
    public class Matematik
    {
        public int Topla(int sayi1,int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
//Bir devletin yoneticisi baska bir devlet yoneticine bilgi gonderirken elci cagiriyor ve
//elciye emir veriyor gidip bilgiyi gerekli yere ulastirmasini ve yorum katmadan ulastirmasini bekliyor
//Programlama da da benzer husus soz konusudur