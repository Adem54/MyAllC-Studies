using System;
using System.Collections.Generic;
using System.Threading;

namespace DelegateActionFuncPredicate
{
    class Program
    {
        public delegate void MyDelegate();//void olan ve parametre almayan operasyonlarin reeferansini tutabilecek
        //
        public delegate void MyDelegate2(string text);

        public delegate int MyDelegate3(int number1, int number2);
        static void Main(string[] args)
        {
       
            CustomerManager customerManager = new CustomerManager();

            MyDelegate myDelegate = customerManager.SendMessage;//customerManager in SendMessage methodunun referansini tutuyor 
            //myDelegate
            myDelegate();//Bu sekilde de calisir...
            myDelegate += customerManager.ShowAlert;
            myDelegate.Invoke();//Boyle de calisir

            //Ornegin biz buyuk bir operasyonu mesela 10 tane farkli methodun calismasi sonucunda calisacaksa iste o 
            //10 methodun hepsini bir delegate de tutabiliriz....
            //Belli sartlara gore yapilacak islemleri once bir toplayip sonra yapilacak isleme gore methodlari belli bir siraya
            //gore cagirmak isteyebiliriz..
            //Biz belli sartlara gore yeni method ekleyebiliriz veya cikarabiliriz...
            myDelegate -= customerManager.SendMessage;
            //Biz burda delegelerimize methotlari sakliyoruz yani methodlari calistirmiyoruz onun icin methodlari paranttezle 
            //vermemize gerek yok...
            MyDelegate2 delegate2 = customerManager.MesajVer;
          
            delegate2 += customerManager.UyariVer;
            delegate2("Merhaba");
            delegate2.Invoke("Bu bir mesajdir");
            // delegate2 = customerManager.UyariVer; Daha oncesinde delege baska bir method tutuyrsa ve ben tekrardan bu sekilde
            //yeni bir method verirsem o zaman sadece bu  verdigim methodu tutar ama eger bu metodu eklemesini istersem o zaman
            //+= ile eklerim, ya da cikarmak istersem -= ile cikaririz

            //Delegate de ki kisit ise sudur ki mesela biz 1 parametreli methodlara delegate lik yapiyorsa o zaman
            //calistirdigimiz zaman methodlarin hepsine de ayni method gitmis olacak...
            //Burda durumu nasil degistirebiliriz tabi ki parametreye ayni  property nesnesini kullanan method lar icin delegatei
            //kullanabiliriz...

            Matematik matematik = new Matematik();
            MyDelegate3 myDelegate3 = matematik.Carp;
            myDelegate3(3, 6);
            myDelegate3 += matematik.Topla;
            Console.WriteLine(myDelegate3(4,8));//En son hangi return u yaparsa onu dondurecektir
                                                //Onceki methodlarda da tabi ki return yapiyor ama en son neyi return ederse onu goruruz biz

            //ACTION
            //https://www.mehmetkordaci.com/blog/2013/12/action-func-ve-predicate-delegeleri/
            //   public delegate void Action<in T>(T obj); Action da bu sekilde tanimlanabilir ayrica
            Action<long> actionIleKaresiniAl;
            actionIleKaresiniAl = karesiniAl;
            actionIleKaresiniAl(3);//Burda action delegate imizde methodu calistiririz...method sonuc return etmez,...

            static void karesiniAl(long sayi)
            {
                Console.WriteLine((Math.Pow(sayi, 2).ToString()));
            }
            //Action delegesi olduğunun farkına varmasak da kodlarımız içinde lambda ile birlikte bu delegeyi oldukça
            //fazla kullanmaktayız. Örneğin aşağıdaki kodda (kodun anlamsız olduğunun farkındayım amaç net şekilde
            //gösterebilmek 🙂 )
            List<int> sayilar = new List<int> { 2, 3, 5, 6, 7, 8 };
            sayilar.ForEach(x => Console.WriteLine((Math.Pow(x, 2).ToString())));
            //ForEach methodunun tanımına gittiğimizde Action tipinde bir parametre aldığını görebiliriz.
            //
            //public void ForEach(Action<T> action);
            //Yani aslında biz ForEach içerisine long tipinde bir değer alan ve içerisinde bu değerin karesini alıp
            //Console.Write ile gösteren bir fonksyion yazdık.
            //FUNC DELEGESI
            //Func delegesi Action’a benzer bir yapıdadır ama Actiondan farklı olarak bir dönüş değeri vardır.
            //    Func delegesinin tanımlarına baktığımızda iki farklı kullanım görebiliriz. Hiç parametre almadan bir 
            //    değer dönebilir.
            //	public delegate TResult Func<out TResult>()
            //Ya da bir parametre alıp bir değer dönebilir.
            //
            //public delegate TResult Func<in T, out TResult>    


            //PREDICATE DELEGESI-dönüş tipi bool olan özel delege yapılarıdır
            //Predicate delegesi ise tam olarak Func<T, bool> parametresinin yaptığı işi yapar.
            //Yani herhangi bir tipteki değişkeni alır ve geriye boolean bir değer döner.  Kullanımı da benzer şekildedir.


            //    Predicate<long> predicateDelegesi;
            //    predicateDelegesi = ikiHaneliMi;
            //    if (predicateDelegesi(55))
            //        Console.WriteLine("Evet");
            //    else
            //        Console.WriteLine("Hayır");
            //}
            //static bool ikiHaneliMi(long sayi)
            //{
            //    return sayi < 100 && sayi > 9;
            //}

            //Aralarında en temel farkı kısaca açıklayacak olursa; Action dönüş tipi olmayan (void), Func dönüş tipi generic olan,
            //Predicate ise dönüş tipi bool olan özel delege yapılarıdır.  



            //ACTION VE FUNC DELEGE TUTUCULARI
            //(Action action) bir method bloguna karsilik gelir donusu void olan bir method bloguna karsilik gelecektir
            //Action icin ornegin bir kod blogu gondeririz...mesela biz ortak bir exception yapmak istersek
            //Yani heryere exception yazmak yerine bir tane yazip tum methodlarda kullanmak istersek
            //Once Action icin bir kod blogu yazariz...

            HandleException2(delegate
            {

                Find();

            });

            static void HandleException2(Action action)
            {
                try
                {
                    action.Invoke();//Biz invoke edince Find() methodu calisacaktir....
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);
                }
            }

            //Yukardsa yaptigimiz HandleException2 ile HandleException olayin da da her ikisinde de Action delegasyonu 
            //parametresiz bir fonksiyonu icine alip calistiriyor.... 
            //delegate{Find();}); ile ()=>{Find();}); ayni seydir....lambda expression..ayni zamanda...Func ayni seyd

            HandleException(() => //Burda HandleException deyip parametresiz bir methoda delege edecegimizi soyluyoruz..
            //Parametresiz methoid da bizim kod blogumuz parantezi acip icine ne yazarsak onu gonderiyor biz Find() yazmisiz
            //Burda bizim Action fonksiyoonumuz Find methoduna delegelik yapiyor...dikkat edelimm....
            // BURAYA COK DIKKAT  ()=> ILE delegate AYNI SEYDIR HER IKISINIDE YAZABILIRIZ HER IKISIDE DELEGEYI TEMSIL EDER...
            {
                Find();
            });
            //HandleException methodu icinde bir tane method var action methodu  ve bu Action methodu aslinda
            //sudur  ()=>{Find();} boyle bir methoddur ve bu method parametrededir simdi biz artik biryere gidip
            //parametreye Action action verirsek ve gidip de action.Invoke edersek o methodu calistiracaktir....

            static void Find()
            {
                List<string> students = new List<string> { "Engin", "Derin", "Salih" };
                if (students.Contains("Ahmet"))
                {
                    Console.WriteLine("Record Not Found!");
                }
                else
                {
                    Console.WriteLine("Record Found");
                }
            }

            //Try-cathc icerisidne calismasini istedigimiz kod u once aynen HandleException daki gibi delegate ile yazariz ve
            //isimsiz bir fonksiyon Action yani ve icinde calismasini istedigimiz kod ne ise onu yazariz ve ondan sonra try-cath
            //icine gelip parametreye Actoin action yazariz ve sonra action.Invoke dedigimiz zaman bizim yazdigimiz delege icine
            //gonderdigimiz Find metodu gibi methodumuz calisacaktir...
            
            static void HandleException(Action action)
            {
                try
                {
                    action.Invoke();//Biz invoke edince Find() methodu calisacaktir....
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message);
                }
            }
            //Biz gercek projelerde exception yonetimini transaction yonetimini boyle merkezi bir noktada kullanabiliyoruz
            //Cunku hepsinde try catch ani
            //Yani action icin yazdigimiz method da diyoruz ki ben senden birsey dondurmeni istemiyorum sen sadece benim gonderdigim
            //methodu calistir yeter diyoruz...
          

            //Build-In dir hem Action hem de Func. Action void turunde dir ozel bir tip donudurmez.Func ise return olarak donus tipi vardir
            //
           static int Topla(int x,int y)
            {
                return x + y; 
            }
            //Kullanim amacimiz bizim Func,Action da belle kod bloklarini sarmaallayip onlari calistirmak idi
            //Func da diyecegizki calistir ve bana da bir deger donder demis oluyoruz...

            Func<int, int, int> add = Topla;//Func<> bir delegedir onun icin delege gibi cagiriyoruz aslinda...
            //add bir delegeye karsilik geliyor....
            Console.WriteLine(add(5,8));//Bu Topla yi calisitirir

            Func<int> getRandomNumber = delegate () //getRandomNumber bir delegedir....
              {
                  Random random = new Random();
                  return random.Next(1, 100);//Bizim icin artik 1-100 arasi bir sayi donderecektir
              };

            Console.WriteLine(getRandomNumber());
            //Func<int>  Eger 1 tane tip varsa <> icinde bu demekkki int donuruyor ve parametresiz bir methodda delegelik ypaiyor....
            //Func i da aynen Action gibi kullanabiliriz,Func i da parametrede bir func isteyip ayni action gibi kullanabilirz.. 
            //Simdi hemen ustte yazdigim Func inin aynisini farkli bir sekilde yazalim..
            //= () => parametresiz bir methoda delegelik yapiyor delegasyon yapiyor =>lambda
            Thread.Sleep(1000);
            Func<int> getRandomNumber2 = () => new Random().Next(1,100);
            Console.WriteLine(getRandomNumber2());
        }

        //Ayni sekilde Func<int> i da biz gidip bir methodun parametresine gonderebilriz ama sadece donus degeri dondurmemiz gerekecektir
    }

    public class CustomerManager
    {
        //Burdaki methodlar da void ve parametre almamistir....yani delegemizde saklanabilirler, tutulabilirler
        public void SendMessage()
        {
            Console.WriteLine("Hello");
        }

        public void ShowAlert()
        {
            Console.WriteLine("Be Careful");
        }

        public void MesajVer(string mesaj)
        {
            Console.WriteLine(mesaj);
        }
        public void UyariVer(string uyari)
        {
            Console.WriteLine(uyari);
        }
    }

    public class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
