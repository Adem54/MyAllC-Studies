using System;

namespace AbstractClassesKullanimBestPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            //ABSTRACT CLASS LAR
            //Abstract class lar aynen interface lergibi newlenemezler
            //Abstract classlar kendisini inherit alan class larin referansini tutabilir
            Database sqlServer = new SqlServer();
            Database oracleServer = new Oracle();
            sqlServer.Add();//Default olarak ekler
            sqlServer.Delete();//SqlServer a gore siler
            oracleServer.Add();//Default olarak ekler
            oracleServer.Delete();//OracleServer a gore ekler

            Console.ReadLine();
        }
    }
    //  DIKKAT.!...........
    //Abstractt class lar birer inheritance dir bir inheritance olayi gibidir dolayisi ile SqlServer class i
    //sadece bir abstractan inherit edilebilir yani 2 tane abstract olmaz ayni inherite gibi, normalde inherite de 
    //o sekilde oluyordu sadecee 1 class inherit edilebilir bir classta ama birden fazla interface implement edilebiliyordu
    //Abstract siniflarda bir class tarafindan 1 tane abstract class inheritance alinabilir ve sonrasinda eger istersek
    //birden fazlz interface kullanabiliriz
    //Ayrica abstraclari kesinlikle new leyemeyiz

 public   abstract class Database
    {//Veritabanlarinin tamami icin kullanacagimiz bir class Database ve orda bir tane default methodu olusturduk
        public void Add()
        {
            Console.WriteLine("Added by default");
        }//Biz diyoruz ki Add methodu butun veritabanlarinda aynidir fakat delet islemine gelince tum veritabanlarinda
        //silme islemi farklidir
        //Iste abstract siniflarla hem tamamlanmis(implemented) methodlar (Add gibi) hem de tamamlanmamis(implement edilmemis)
        //methodlar, (Delete gibi) yapabiliyoruz, tamamlanmamis yani implement edilmemis methodlar yapabiliyoruz
        //

        public abstract void Delete();//Bu ici dolu olmayan virtual methoddur

        public virtual void Update()
        {
            Console.WriteLine("Update by default");
        }
      
    }


    class SqlServer : Database//Database abstract clasini SqlServer implement ediyor ve burda da Database abstrack
        //class i icerisinde abstract olarak yazilmis implement edilmemiis virtual method lar Databasa i implement eden
        //class larda olmmak zorundadir ve override olarak gelecektir zaten
        //Bu abstract olarak yazilan virtual method zaten her ortamda farkli olacagi icin oyle yazilir Abstract class inin
        //icerisinde. Bu abstract class in icerisine yazilan abstract methodu abstract class i implement eden class larin
        //ayri ayri implement etmesi yani kendine ozel kodlarla o abstrackt olarak yazilan methodun icini doldurmasi gerekir
    {
        public override void Delete()
        {
            Console.WriteLine("Deletet by SqlServer");
        }

        public override void Update()
        {
            base.Update();
            Console.WriteLine("Update by Sql Server");
        }
    }

    class Oracle : Database
    {
        public override void Delete()
        {
            Console.WriteLine("Deletet by Oracle");
        }

        public override void Update()
        {
            Console.WriteLine("Update by Oracle");
        }
    }

  public class Postgre:Database
    {
        public override void Update()
        {
            base.Update();
        }

        public override void Delete()
        {
            
        }

    }
        
        
        
        }

//Abstract sınıflar sınıf hiyerarşisinde genellikle base class (temel sınıf) tanımlamak için kullanılan ve
//soyutlama yeteneği kazandıran sınıflardır.
//Ornegin farkli farkli database lerimiz var SqlServer,Oracle,PostgreSql ve bunlarin ucunde de biz Add,Update islemleri ortak
//ayni icerikleri de ayni yapacagiz ama Delete islemi her veritabaninin kendine ozel yapacagiz yani birbirine denk olan
//nesnelerimiz var farkli veritabanlari gibi ve bunlarin icerigine kadar ayni olan methodlari da olacak ama
//tamamen kendilerine ozel methodlari da olacak bu tarz durumlarda iste Abstract siniflar kullanabiliriz ve her veritabaninin
//kendine ozel olan methodunu abstract class icinde imzasini atariz icini bos birakiriz ayni interface de yaptigimiz gibi ve
//Onun icini her bir veritabani kendisi doldurur burda su fark var eger biz abstract bir class icinde abstract bir method
//olusturursak  onun icini bu abstract class i inherit eden classlar da  doldurmak zorundayiz
//ABSTRACT METHOD ILE VIRTUAL METHOD
//Peki bir abstract class i icindeki methodlardan bazilarini Abstract kullanmak ile virtual kullanmak arasinda nasil bir fark
//var Soyle ki  abstract method un abstract class ı ıcınde ıcı doldurulmaz sadece ımzası atılır aynı ınherıtance methodu gıbı
//ve abstract method icinde bulundugu abstrac class i inherit eden nesneler icinde ici doldurulmak zorundadir. Ama bir virtual 
//methodu bir kere icini default bir sekilde doldurabilir yani mesela bir senaryo olarak ornegin Sql,Postgre,Oracle in 1 tane
//icerigi de ayni olan methodlari olsun onu zaten direk yazariz, bir tane her birisinin kendine ozel bir methou olsun
//bir tane de 2 veritabaninda da ortak ama sadece birinin kendine ozel bir method olsun iste bu durumda virtual kullanabilirz
//Cunku virtual in biz icini zaten abstract class veya normal class ta  icini dolduduruz o class i inherit edenler ister ici
//doldurulmus halde kullanir, ister se de icini tamamen kendisi doldururu ister se de hem ici dolu halini kullanir hem de
//ekstra dan kendine ozel olan seyleri de o methoda yazabilir....
//Virtual method da icini illaki doldurmak zorunda degiliz ayrica virtual methodda biz abstract class i icinde
//illa ki bir default method yazmak zorunda da degilz istersek de icini ayni abstract methodu gibi bos da birakabiliriz
//Constructors (yapıcı metodlar) ve destructors (yıkıcı metodlar) bulundurabilirler.Interface lerde biz constructor bulunduramiyoruz
//Static tanımlanamazlar. ( Tanımlanmaya çalışılırsa compiler “an abstract class cannot be sealed or static” hatası verir)
//Abstract class lar adinda anlasilacagi uzere bir Base class tir
//Abstract class lar interface lerle virtuel methodun birlesimi gibi dusunebiliriz
//Tamamen inheritance amaci ile kullanilir
//Interfacelerle virtual methodlarin tam kullanim nedenlerini bir araya getirdiginnizdee ortaya ne cikiyorsa abstact
//class larda da amac odur


//ONEMLI....
//Abstract class'lar soyut nesnelerdir ve abstract classlardan new ile yeni nesneler türetilemez
//Abstract sınıf bir methodu veya özelliği diğer class'larda miras olarak verebileceğimiz ovveride method içerir
//İnterface'den en büyük farkı ise interfacedeki methodları içi boş iken abstrat class'larda methodlarin
//içi boş veya dolu da olabilir


//ONEMLI BIR FARK....   
//NOT=>Virtual Methods da override yani ezme islemini bize zorunlu kilmiyor ama abstract class larda override islemi
//zorunlu kilinmistir.....
//Abstract class ta imza niteligi tasiyan implement edilmemis bir imza o abstrack class i implement eden diger class
//larda override edilmekk zorundadir
//Abstract class i implement eden her sinif abstract class icinde abstract ile yazilmis method veya propert yi implement emtekk
//zorundadir, eger abstract olan bir method ise zaten override ile yazmak zorundayz...Zaten abstract icinde biz bir 
//methodu abstract ile tanimliyorsak sadece imzasini yazmak zorundayiz yani govdesi yazilmas, implement edilmez...
//Bir abstract sinif icersinde abstract olan elemnalar olabilecegi gibi abstract olmayan elemanlarda olabilir....
//Abstract class lar newlenemez, nesne veya instance olusturulamaz..........
//Abstract class icindeki abstract method  public,private,protected olabilirken bir interface de
//imzalar default olarak public tir zaten ve public yazilmaz baslarina ve private,protected olamazlar
//Abstract class lar kendilerini implement eden diger class larin referansini tutabilir

//Abstract class'lar kendinden türeyecek olan class'lar için aslında bir template görevi üstlenir(base class).
//Bu sayede C# dilindeki abstraction sağlanmış olur. Aslında c# dilinde tüm sınıflar bir template'tir
//yani bir veri yapısıdır ancak genellikle bir varlığı simüle ederler.
//Abstract class'lar ise varlıktan ziyade varlıkların yaptığı genel fonksiyonaliteyi belirtirler.
//Bu sebepten nesne instantiate edilemezler(new'lenemezler :) ), zaten bu durum mantıklı da olmaz.
//Eğer bir class bir abstract class'ı miras alıyorsa o şablonda belirtilen tüm abstract metotları ezmek(override)
//etmek zorundadır. Ayrıca abstract class'larda gövdeye sahip olan metotlarda yazılabildiğinden farklı farklı
//class'larda aynı kodu yazmak gerekmeyecektir. Örneğin canlılar için nefesAl() metodu gibi.
//---
//Abstract class lari implement eden class lar abstract class larin abstract olmayan, soyut olmayan methodlarini
//direk kullanabilirler zaten , yani soyut olmayan methodlar abstract sinifi inherit eden siniflarda tekrardan yazmak 
//zorunda degil aynen bir class in bir class i inherit etmesi gibi dusunebilirz.Yani Database class inda bulunan
//Add methodunu Database class ini implement eden SqlServer class i direk kullanabiliyor sanki kendi methodu gibi




