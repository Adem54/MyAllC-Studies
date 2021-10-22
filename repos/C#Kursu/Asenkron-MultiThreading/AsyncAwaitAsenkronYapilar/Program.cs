using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitAsenkronYapilar
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine($"Main thread basladi:  {Thread.CurrentThread.ManagedThreadId}");

            //  Task task1 = Task.Run(Process2);
            //Biz dikkat edersek asenkron yapiyi icinde metodlarimiz calistiran Task class i Run ile calisinca
            //donen yapi yine Task tipinde oluyor...Dolayisi ile biz normalde asenkron yapinin icine
            //bir method verip o methodun arka planda asenkron olarak calismasini saglmais oldukk
            //Ama biz her bir methodumuz icin bir task calistiramayiz bu yuzden ne yapcagiz o zaman o zamanda biz
            //Bizim asenkron yapi yapabilmemiz icin ihtiyac duydugumuz ortam bu, yani biz her bir
            ///methodumuzu task icinde calistirma degilde methodlarimizi da asenkron yapi haline nasil donus
            //tururuz ona bakalim..
            //Biz Task.Run() seklinde calisip Task donduren yapiyi kendi methodlarimizda nasil uygulariz
            //Yani benim methodum onun gibi olsun void donmesinde Task donsunve asenkron olsun...
            //Aynen bizim ProductManager
            //daki methodlarimiz icin yazdigimz IResult tipinde olan ve SuccessResult ve ErroResult doner
            //onlarda bir IResult tur cunku
            Process1Async();//4.thread i acar-asenkron programlama sayesinde bir avantajdir
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            Process1Async();
            //Bu sekilde ayni async methodu birden fazla kez calistiricak o zaman da her seferinde bir thread
            //degilde mesela belli bir sayiya kadar thread acar bu pc nin Cpu si ile iliglidir ve bazi thred
            //leri birden fazla kez kullanir...
            //Ve methodlarin zaman a bagli olmadan calistiklarini gorebiliriz, yani arka arkaya da degil de 
            //asenkron olarak calistiklarini gorebilirz bir kactane  Process1Async(); calistiktan sonra
            //en alttaki Process1 ve Process2 araya girmis ve sonra da  yine  Process2Async(); bazi
            //Process1Async(); lerin onunde calistmistir burdan biz asenkron programlamanin uygulandigni goru
            //yourz..

            //ASENKRON YAPILARI ANLAMAK ICIN PROCESS1ASYNC I KENDI ICINDE 1 SANIYE BEKLESIN DIYE KOD YAZDIKTAN SONRA
            //15-20 KEZ ARD ARDA CALISTIRINCA
            //BIR METHOD BEKLERKEN DIGERI DEVREYE GIRIYOR VE BIZ 20 SANIYE BEKLEMEMIZE GEREK KALMADAN
            //COK KISA BIR SUREDE TUM FONKSIYONLAR CALISIYOR
            //ASENKRON CALISMA MANTIGNI ANLAYABILIYORUZ...
            // static async Task Process1Async()
          
            //{
            //    await Task.Run(() =>//Task.Run diyerek burdaki kodumuzun asenkron oldugunu belirtiyoruz..
            //    {
            //        //COK ONEMLI BIR ORNEK....ASENKRON PROGRAMLAMAYI ANLAMAK ICIN....
            //        Thread.Sleep(1000);//Bunu test etmek icin koyduk ve normalde biz Process1Async() i art arda
            //                           //15-20 kez calistirmamiza ragmen, 15 saniye beklemek zorunda kalmiyoruz cunku bir method
            //                           //calismasi beklerken digerleri hemen devreye giriyor onu beklmiiyuor digerleri ve surekli 
            //                           //calisiiyor...

            //        Console.WriteLine($"Async 1. isleme basladi:  {Thread.CurrentThread.ManagedThreadId}");
            //    });

            Process2Async();//5.thread i acar.asenkron yapinin faydasi
            Process1();
            Process2();
            Console.ReadKey();


            //VE SON OLARAK DA ASENKRON METHOD LARIMIZI DA EGER KONTROL ALTINA ALMAK ISTERSEK
            //O  ZAMAN NE YAPARIZ?
            Task task1 = Process1Async();
            //Daha sonra da task1 uzerinden istedgimiz tum islemleri yapabiliriz...
        }

        //BIR FONKSIYONU ASENKRON HALE GETIRMEK
        //Bir fonksiyonu asenkron hale getirmek icin once fonksiyon basina async koyariz daha sonra da
        //method sonuna Async ifadesini yerlestiririz.Ayrica donus tipini de Task yapmaliyiz
        //Neden donus tipini Task yaptik cunku Task in nimetlerinden faydalanabilmek icin
        //Task derken task tipinde dondurur ama asil methdoun icinde calisan islemi dondurur yine yani
        //senkron olan verisyonunda ne donuyorsa onu Task icinde dondurur sadece....Task orda voide karsilik 
        //geldigi icin de methodlarimiz sorun cikarmadi, birsey dondurmuyor, return etmiyor...
        //Task da zaten kendi icinde Action calistiriyordu bisey dondurmeyen
        //Biz kendi methodumuz asenkron yapmaya calisirken aslinda yaptigimiz nedir yaptigimiz kendi methodumuz
        //ile     Task.Run(Process1) yapisini birlestirmektir...aslinda... Task in altinda kullandigi Run i biz
        //kendi methodumuzun icinde calistiracagiz...
        //ve await ile de icerde calisacak olan Run methodunu callstririz...

        //Genellikle .Net ortaminda ayni fonksiyonun 1 tane normal versiyonunu bir tane de asenkron verisyonu
        //nu olustururuz

        //METHODUMUZUN NORMAL VERSIYONU-SENKRON VERSIYONU-ZAMAN KONTROLLU-SIRA ILE BIRBIRINI BEKLEYEREK CALISAN
        static  void Process1()
        {
          
            //Bu bize mevcut thred numarasini veriyor
            Console.WriteLine($"Senkron 1. isleme basladi:  {Thread.CurrentThread.ManagedThreadId}");

            //Async methodlarimizin altini cizerek uyariyor diyor ki senin await methodun main method biteene 
            //kadar calismaza onu goremebilirsin
          
        }
        //METHODUMUZN ASENKRON VERSIYONU
        // basina async yazmak bunun bir asenkron operasyon oldugunu anlatir await ise, operasyonumuz
        //asenkron olunca asenkron operasyonun kendii icinde saglikli bir surece ihtiyaci var
        //await aslinda bizim taskin wait i, Task.Wait diyerek taskin bitmesini bekliyyordu ya alttaki processler
        //Yani await bizim kendi operasyonumuzun kendi icinde saglikli calismasini saglayacaktir...
        //Yani kendi icinde bir siralama olmasini saglayacaktir...aksi takdir method icinde calisatiracagimiz
        //islemler kontrolsuz olacaktir...
        static async Task Process1Async()//Task altinda bir void operasyondur..Task cunku icinde Action barindirir
            //idi Action bir void operasyondur...
        {
            await Task.Run(() =>//Task.Run diyerek burdaki kodumuzun asenkron oldugunu belirtiyoruz..
            {
                //COK ONEMLI BIR ORNEK....ASENKRON PROGRAMLAMAYI ANLAMAK ICIN....
                Thread.Sleep(1000);//Bunu test etmek icin koyduk ve normalde biz Process1Async() i art arda
                //15-20 kez calistirmamiza ragmen, 15 saniye beklemek zorunda kalmiyoruz cunku bir method
                //calismasi beklerken digerleri hemen devreye giriyor onu beklmiiyuor digerleri ve surekli 
                //calisiiyor...
                
                Console.WriteLine($"Async 1. isleme basladi:  {Thread.CurrentThread.ManagedThreadId}");
            });
            //Bu bize mevcut thred numarasini veriyor
            
        }
        static void Process2()
        {
           
            //Bu bize mevcut thred numarasini veriyor
            Console.WriteLine($"Senkron 2. isleme basladi:  {Thread.CurrentThread.ManagedThreadId}");

        }
        static async Task Process2Async()
        {
           await Task.Run(() =>
            {
                //Bu bize mevcut thred numarasini veriyor
                Console.WriteLine($"Async 2. isleme basladi:  {Thread.CurrentThread.ManagedThreadId}");
            });
           

        }
    }

}
