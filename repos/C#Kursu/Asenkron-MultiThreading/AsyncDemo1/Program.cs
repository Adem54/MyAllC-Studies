using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo1
{
    class Program
    {
        static void Main(string[] args)
        {//Main thread-UI thread-Single thread
         //Bu  mutlaka vardir bu baslangic threadi dir cunku bunun uzerine yeni thread ler
         //acilabilir
            Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
            //Console uygulamalarinda default olarak single thread vardir durumu bu sekildedir
            //Apilerde thyread sayisi .Net framework tarafindan optimize ediliyor dolayisi ile bizim
            //asenkron programlamayi iyi ogrenmeliyiz..
            //Bunun icin biz Task adi verilen bir sinifi kullanacagiz..
            //Task dedigmmizde zaten System class i altindadir, asenkron programlamada zaten bir 
            //threding mimarisidir.Threading in uzerine konulmus bir yapidir.
            //Asenkron programalama threading den tamamen farkli degil yine threading var ama
            //Task larda asenkron programlama vardir
            Task task1 = new Task(Process1);
            task1.Start();
            //Task icerisine bir Action istiyor Action ne idi action sonu return donmeyen bir method
            //tutucu idi anonim bir fonks gibi ,bir delege idi
            //Action dedigimiz aslindas bir delegedir yani bir methoddur
            //Hatirlarsak delegelerde de method calistirilir gibi gonderilmez sadece ismi gonderilir
            //Icine koyarken calistir demiyoruz sadece o methodu tanimliyoruz...
            //Task class inin constructor ina Process1 i gonderiyoruz...


            Process2();
            Process1();

            Console.WriteLine("Merhaba1");
            Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Merhaba2");
            Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Merhaba3");
            Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();//herhangi bir tusa basinca islem sonlanmasi icin bunu yazariz...

            //Thread no:  1
            //2.isleme basladi
            //Thread no: 1
            //1.isleme basladi
            //Thread no: 1
            //Merhaba1
            //Merhaba2
            //Merhaba3
            //1.isleme basladi
            //Thread no: 4

            //Process1();
            //Thread.Sleep(5000);//Islemi 5 saniye durduruyor...
            //Process2();


            //Console uygulamasi default olarak single thread oldugu icin islemler sirasi ile gidiyor yani biz
            //thread i 5 saniye durdurunca ondan sonraki islem de mecbur onun bitmesini bekliyor
        }
        static void Process1()
        {
            Console.WriteLine("1. isleme basladi");
            //Bu bize mevcut thred numarasini veriyor
            Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
        }
        static void Process2()
        {
            Console.WriteLine("2. isleme basladi");
            //Bu bize mevcut thred numarasini veriyor
            Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");

        }

       

    }
}

//Asenkron programlama eger sadece 1 thread varsa main thread, o zaman o thread e dokunmaz yeni 
//bir thread acma egilimine girer
//Asenkron programlama yaptigmiz zaman kodlar yukardasn asagi calismaya devam eder sistem
//hicbiryerde bloke olmayacaktir
//Simdi bize gelen ciktiyi yorumlayalim-asenkron programlamanin hayat dongusu nasil oluyor diye




//Burasi Asenkron programlamadir
//  Task task1 = new Task(Process1);
// task1.Start();
//Asenkron programlama genellikle egilimi main thred varsa sadece ona dokunmaz, yeni bir thread acar
//Burda da oyle yapiyor bu hayata girmeye calisriken hemen bir alttaki Process2 calisiyor ayni anda 

//BU ACIKLAMA COK ONMELI!!!!ASENKRON PROGRAMLAMAYI ANLATIYOR...
//Ilk once calismaya baslayan trhead 
// Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
//Ilk bu satir calisti main thread olan thread no 1 threadine girdi bu islem
//Bu thread onden basladi gidiyor biz tabi su an bir asenkron programlama ya gore konusuyoruz...
//Simdi bundan sorna bu thread ile beraber calisacak kodlar sira ile calisacaktir tabi ki ancak

///Bundan dolayi Process2 de thread1 ile calisacagi icin task dan altta olmasina ragmen
//task dan once calisiyor cunku task new lenip calismaya baslyana kadar Process2 bakiyor ki Maint thread bos hemen ona yapisir
//ve calismaya baslar o esna da task new leme ile mesgul old icin newlndikten sonra Task icindeki mehod calisir ondan dolayi da
//Task icindeki method Process2 den sonra calisir





//Thread no:  1              Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");
//2.isleme basladi            Task task1 = new Task(Process1); task1.Start();
//Thread no: 1                Process2(); 
//1.isleme basladi            Process1();
//Thread no: 1
//Merhaba1                    Console.WriteLine("Merhaba1");
//Merhaba2                    Console.WriteLine("Merhaba2");
//Merhaba3                    Console.WriteLine("Merhaba3");
//
//
//
//1.isleme basladi
//Thread no: 4



//Task task1 = new Task(Process1); task1.Start(); bu daha bellekte new lenmeye calisirken
//Bazen de task class imiz newleye  calisirken method eger bitrese yani i
//process in icinde calisacagi method biterse o zaman da o process hic hayata giremeyebilir mesela
//threadno 4 demek yeni bir process demektir..
//o yetisemezzse o zaman onu hic goremeyiz..yani task nesnesi new leme isi de yapiyor yani
//o new leyene kadar bazen program bitebilir o zamaan da onu hic goremeyiz...
//O zaman bizde onu gorebilmek icin ReadKey() yazariz...