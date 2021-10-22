using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskVeAlternatifKullanimlari
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");

            //Task kullanim-1-Iki satirda taski calistirma...
            //Task task1 = new Task(Process1);
            //task1.Start();

            //Task Kullanim-2-Task asenkron sekilde calisan nesneyi tek satirda calistirma
            //Task task2 = Task.Factory.StartNew(Process1);
            //Burda da StartNew parametre olarak action gecilmesi gerekyor yani bir method
            //  Task task1 = Task.Run(Process1);
            //Task Kullanimi-3-Bu en fazla kullanilan task kullanimidir
            //Task.Run() icerisine method vermemiz gerekir action var cunku...
            //Ama action return u olmayan yani void bir method ver demektir bir delegedir..
            //Action method demek func yani anonim methodun return donmeyen halidir, yani void hali 
            //Ve dolayisi ile biz bu methodu disarda n verme yerine calisma esnasinda da olusturabiliriz..
            //Illa gidip bir yerden method cagirmamiza gerek yok direk bir tane anonim bir method da 
            //icinde calistirabilirirz void olmaldir buna dikkat...
            //Asenkron yapiinin calisma esnasinda biz bu Action yani void olan anonim fonks calistirarak
            //asenkron yapilarin calismasini takip edebiliriz..
            //Ayrica biz dedik ya Run icindeki yapi Action dir action ise delegedir delege nedir
            //delege ise method tutucudur icerisindde istedigimiz kadar method tutailiriz ama Action bir
            //void method tutan delegedir ondan dolayi biz birden fazla void methodu da Task.Run icindekki
            //action  icinde calistirabiliriz...
            //Task icerisinde methodlarimiz asenkron olarak calisacaktir
            //Task icinde yazdigimiz farkli methodlar da asenkron olarak sira ile caliscaktir 
            //Asenkron sekilde calisan yapilar dan once eger ana thread,main thread calisiyorsa asenkron yapi
            //mutlaka yeni bir thread olusturur ve kendi icindeki processleri o thread de takip eder..
            //Ve o sonradan acilan threac icindeki processler ise main thread i ile calisan processler bittikten
            //sonra arkasinda gelecegi icin, kod satiri olarak ustte olsalar bile en son calisacaklardir..
            //Task task2 = Task.Run(() =>
            //{
            //    Process1();
            //    Process2();
            //}
            //    );
            //Asenkron yapilarda kendi icinde sirali bir sekilde yukardan asagi calisirlar...

            Task task3 = Task.Run(Process1);

            task3.Wait();//Task in isleminin threadinin bittiginden emin ol ondan sonra
            //asagi gec,yani asagidaki kodlari calistir demektir bu....evet bu cok kritik bir islem yapiyor burda....
            //Dikkat edelim burda kodlarin calismasini kontrol altina alabiliyoruz...yani bize cok lazm olacak bu islemler
            //Kodlarimizin arka arkaya calismasi gerekebilir bazen...illa ki asenkron yapiyoruz diye de kodlarin 
            //hizli bir sekilde hepsinin kontrolsuz calismasi da iyi degil cunku bizim islemlerimiz
            //birbirne bagli oluyor cogu zaman yani birinden cikacak bir sonuc digerine parametre olarak gidiyorsa
            //daha sonuc cikmadan , o sonucu parametre olarak alacak olan mehtod u calistirmaya calisirsa bu sefer de ne olur
            //bizim uygulamammiz patlar...
            //Soyle dusunebilir e zaten yukardan asagi calisiyordu normalde o zaman asenkron niye yaptik?
            //Asenkron yaptiimiz icin birden fazla thread olusmasini sagladik ve performansi arttirmis olduk..
            //Hem thread artisini sagladik hem de thread havuzu dolu ise thread lerin ortak kullanimini saglamis olduk..

            //BIZ NIYE TASK ILE CALISTIK
            //1-ASENKRON PROGRAMLAMA ILE ICERISINDE ISTEDIGIMIZ KADAR METHOD CALISTIRABILIYORUZ..
            //2-TASK SAYESINDE TASKIN ALTINDAKI METHODLARIN TASK IN ICINDEKI METHODLAR CALISMAMASINI SAGLAYABILIYORUZ
            //YANI TASKDAN SONRA GELEN ALTTA KI ISLEMLERIN TASKDAN SONRA CALISMALARINI KONTROL ALTINA ALABIILYORUZ
            //3-ASENKRON CALISMANIN FAYDALRINI KULLLANMAK
            //4-BOS THREAD LERI VERIMLI BIR SEKILDE KULLANMAK VEYA THREAD LERI ORTAK KULLANMA AVANTAJLARINDAN YARARLANMAK IICIN
            //BIZ BU SEKILDE CALISIRIZ.

            Process2();
           
            Console.WriteLine("Merhaba");
            Console.WriteLine($"Thread no:  {Thread.CurrentThread.ManagedThreadId}");


            Console.ReadKey();
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
//ASENKRON PROGRAMLAMA UFAK BIR DUZELTME
//Normalde asenkron yapi icinde caliosacak olan mehtod dan once bir process basladi ise yani herhangi bir kod
//parcasi calismaya basladi ise o main thread ile baslar asenkron yapi disindaki islemleri main thread ile
//calisir biter onlardan sonra asenkron yapi icindeki processler yeni bir thread de calisir..Ama
//her zaman illa ki asenkron yapi icindeki process ler main thread indeki processs lerin bitmesini bekleyecek
//diye bir kural yok...

//BU KISIM ASENKRON YAPI ILE ILGILI KAFAMDAKI EN NET ACIKLAMADIR
//Asenkron yapi icinde calisan yapi dan sonra gelen method o esnada hangi thread bbos ise ona yapisir hemen
//Dolayisi ile asenkron yapidan onceki main thread de calisan mehtod isini zaten bitirmis oluyor ve 
//main thread musait oluyor ama asenkron yapi dedigimiz task ise new lemesi lazm ilk once yani new lemeden
//process alamiyor dolayisi ile o new leyene kadar task in altindaki process ler hemen kendisini 
//main thread e yapistiriiyor, Peki, task in oldugu satir, orda dururken alttaki satirlara nasil devam ediyor
//Iste bunuu da saglayan asenkron yapidir zaten asenkron yapinin farki bu degil mi idi hicbirseyi bekletmez
//Bazen ayni thread de birden fazla islem ayni anda alabilir...ve calistirabiliriz asenkron yapi sayesinde

//PROCESSLERIMIZ THREAD SECERKEN HANGISI BOS ISE HEMEN ONA YAPISIRLAR ILLA KI BELLI BIR THREAD DE OLACAKLAR DIYE
//BIRSEY YOK....
//BURDA ASENKNRON CALISANA KADAR DIGER PROCESS LERIN HEPSI CALISIP BITIYOR BILE DE O YUZDEN BIZ ASENKRON U EN 
//GORURUZU
//AMA EGER BIZIM ASENKRON OLARAK CALISAN YAPIDAN SONRA COK UZUN SATIRLARCA KODUMUZ OLSA IDI O ZAMAN DA 
//ONLARIN HEPSI CALISMADAN ASENKRON YAPI CALISMAYA BASLARDI VE ASENKRON YAPI BASLADIKTAN SONRA DA ASENKRON 
//YAPININ ALTINDA BULUNAN KODLARDAN CALISMAYANLAR DA ASENKNRONDAN SONRA CALISABILIRLERDI VE 
//ASENKRON DA SONRA CALISAN LARDA YINE MAIN THREAD DE CALISIYORLAR YANI
//ASENKRON YAPI ICINDE CALISACAK PROCESSLER MAIN THREAD PROCESSLERININ BEKLEME ZORUNLULUKLARI YOKTUR
//SADECE OLAY CABUKLUK OLAYIDIR..ASENKRON BIR SEKILDE CALISACAK PROCESS LER ONCE ASENKRON YAPININ NEW LENMESINI
//BEKLERLER ISE O ESNADA DIGER MAIN THREAD ZATEN BIR COK PROCESS I CALISTIRIYOR...
//AMA ASENKRON YAPI NEW LENDIKEN SONRA TUTUP DA MAIN THREAD I BEKLEMEZ..OYLE BIR OLAY YOK ASENKRON YAPI DA
//CALISMAYA BASLAR...