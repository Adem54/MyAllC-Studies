using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsIntro
{ 

    //KENDIMIZ LIST GIBI CALISAN KENDI GENERIC CLASSIMIZI NASIL OLUSTURURUZ
    //GENERIC CLASS LAR TIP BAGIMLI CALISIR VERECEGIMIZ TIPE GORE CALISIRLAR ONDAN DOLAYI GENERIC CLASS LARDAN INSTANCE OLUSTURURKEN
    //MUTLAKA CALISACAGIMIZ VERI TIPINI BELIRTMELIYIZ
    //Normalde generic list olustururken icerisine koyacagimiz veri tipini buyuktur kucuktur isareti icerisine yazariz
    //List<string> cities=new List<string>(); .Biz Listelere sadece stringleri degil tum tiplerdeki verileri koyabiliriz
    //int,bool,dobule,Product class tipi gibi tum tipleri genericlisteler icerissine koyabiliriz
    //GENERIC CLASS OLUSTURMA
    //GEneric class olusturmak icin class ismimizin yanina <T> yazilir type dan geliyor, tip den ozel bir tip old icin
    //Normalde biz <T> yerine <A> da yazsak olur aslinda
    //GENERIC CLASS DA BIR DIZI OLUSTURURKEN TIP SORUNU YASAMAMAK ICIN T[] items= seklinde OLMALIDIR!!!!!!
    class MyList<T>//Ben Mylist imde T ile calisacagim demektir
        //Burda <T> yazinca ona bir tip vermis oluyourz ki o da asagiyi ona gore yapilandiriyor yani biz hangi tiple calisacagimizii
        //belirtirsek o tipe gore dizi olusturmus olacak, yani tip problemini hallediyor bu sekilde yaparsak
        //List<string> isimler=new List<string>(); burda List class indan bir string tipinde dizi olusturuyoruz artik bu dizi
        //icerisine isimler.Add("Ahmet") string tipinde veri ekleyebiliriz int ekleyemeyiz iste bu tip durumlarini biz class a
        // MyList<T> dedigimiz zaman ayarlamis oluyoruz
        //MyList<T> dedikten sonra bu generic class icerisinde biz bir method olusturmak istiyoruz ornegin o zaman parametreye 
        //MyList<T> ve Add(T item) diyerek biz demis oluyoruz ki kullanici hangi type yazarsa o tip gecerli olsun demis oluyoruz
    //MyList<string> names = new MyList<string>();
    //MyList<int> numbers = new MyList<int>();
    //MyList<Product> products = new MyList<Product>();
    //Biz generic class i bu sekilde olusturunca zaten ana class imiza gidip de Program.cs orda generic class tan bir liste 
    //olusturmak istersek zaten bize otomatikmen MyList<> seklinde bir yapi geliyor karsimiza yani class in yanina neyi liste
    //seklinde yazacaksak onun tipini belirtmeliyiz, string mi,int mi ya da Product class turunden mi
    //Biz generic class i olustururken MyList<string> biz string yazinca arka planda calisirken parametredeki T string olyor 
    //Yani biz MyList<> bu buyuktur ve kucuktur arasina hangi tip yazarsak o arka planda o tipe donusuyor generic class olusturuken
    //yazdigimiz T sayesinde
    //Normalde bizim kullandigimiz List yani generic class olan list ile biz bir liste olusturduktan sonra o liste ile Add deyip
    //eleman ekliyorduk yani aslinda List arka plan da bir arrayi yonetiyor
    //METHOLAR DISINDA OLUSTURULMUS DEGISKENLER O METHODLARDA KULLANILABILIR AMA TAM TERSI KULLANILAMAZ
        //Bizde bir arrayii kullanalim ayni sekilde Add ile eleman ekleyen kendi class imizi olusturabilmek icin
    //Dikkat edelim biz o tanimlayacaigimiz arrayi gidip method icinde tanimlamayiz gidip class icinde ama method disinda tanimlariz
    //ki o class icindeki olusturacagimiz tum methodlar da kullanilabilsin. 
    //Biz bir methodun disinda olusturulmus olan bir degiskeni o method da kullanabiliriz ama bir method icerisinde olusturulmus olan 
    //degiskeni gidip de o method disinda kullanamayiz
    {


        //Array olusturacagiz ama dogrudan bir tip veremeyiz cunku biz method kullanilirken hangi tip verilirse o tip de veri
        //olusturulmasini istiyoruz.Bir tip verirsek o tiple sinirlandirmis oluruz biz bunu istemiyoruz
        T[] items;//normalde string[] items;
                  //ONEMLI!!!!!!!!!!!
                  //BIR ARRAY IN OLUSMASI ICIN ONUN NEW LENME ZORUNLULUGU VARDIR YANI DIGER TIPLERDE BIZ
                  //string isim; deyip bir strin tip olusturmus olabilirz bununla karistirmayalim referans tiplerin
                  //olusmasi icin new lenmeleri zorunludur heap te bir alan tutmasi veya adres tutmasi , referans almasi icin
                  //Bir arrayin olusmasi icin new lememiz gerekiyor normalde ve new ledikten sonra da eleman sayisinin kac olacagini
                  //belirtmeliyiz ama generıc class larda List<string> names=new List<string>(); yaptiktan sonra
                  //Console.WriteLine(names.Count) dersek eleman sayisini getirir biz eleman sayisinin 0 ile basladigini goruyoruz
                  //Generic class larda olusturacagimiz liste 0 dan basliyor. Yani ben T[] items; arrayi mi new ledigim zaman ilk olarak
                  //0 elemanli bir dizi olusturmak gerekiyor
                  //Bir dizi olusmasi icin diziyi sadece degisken le tanimlamak yetmez new lemek zorundayiz yoksa heap te bir alan tutmaz
                  // Ve dizininn olusmasi icin new ledikten sonra da eleman sayisi 0 vermem lazim generic bir liste mantiginda
                  // yapabilmek icin

        //BIR CONSTRUCTOR OLUSTURALIM-ctor yazip tab a 2 kez basarsak
        //Constructor oldugunu class ile ayni isim ve sadecde basina public gelir normalde constructor biz gormesek bile arkada
        //default olarak calisiyor zaten
        //Bir class new lendiginde calisan bloga constructor deniyor
        //Constructor bir methoddur ve bir MyList classini newlendigimiz zaman ilk olarak bu method calisir
        //yani MyList generic clss ini biz newlersek otomatiktmen ilk olarak consttructor calisir arka planda
        //Constructor ismi class ismi ile aynidir ve sadece public ile yazilir void veya veri tipi yazilmaz....
        //Biz kendi olusturdugumuz items dizisini 0 elemanla baslatmak icin gelip MyList constructor inin icerisinde new lerim
        public MyList()//Constructor-Biz MyList i new ledigimiz anda bu blok calisir ilk bu blok calisir
        {
            items = new T[0];

        }

       
        
        //OLAYIN MANTIGINI TAM KAVRAYALIM----ONEMLI!!!!!!!!!
        //Biz class tan instance olustururken yani MyList class ini newledigimiz zaman constructor orda 1 kez calisir bir daha da 
        //o class i newleyene kadar calismaz dolaysi ile Add methodunu kullandigimizda constructor calismayacaktir.......
        //Yani ilk class newlendiginde bir kez bir array olusturulur zaten biz kendi listemizi olusturmaya caliyoruz ve listelerin
        //calisma mantigina gore biz listeyi 0 dan olusturup tek tek eleman ekleriz yani listelerde array gibi 4 elemanli veya 
        //5 elemanli bir liste olusturuma diye birsey yok dogrudan teker teker 0.eleman,1.eleman diye her Add methodunu calistir
        //digimizda yeni bir eleman eklemis oluyoruz
        
        public void Add(T item)//Constructor sadece bir kere class newlendiginde calisir, methodu calistrdigimiza constructor calismaz
    {
            //Simdi dizimizi 0 elemanli olarak constructor icerisinde new ledikten sonra simdi o diziye eleman nasil ekleyecegiz
            //ona bkaalim dizilerde biz dizi eleman sayisi kadar eleman ekleyebiliyorduk dogrudan ekstra eleman eklemek istersek 
            //eleman sayisini ihtiyacimiz olan kadar olacak sekilde yazarak yeni bir dizi olusturmam gerekiyordu
            //Mesela 0 elemanli bir diziye 1 eleman eklemek icin eleman sayimizi 1 arttirmamiz gerekiyor once ki oraya eleman ekleyebilelim
            // items=new T[1] diyemeyiz surekli bir yapar biz iste her Add methodu calistiginda 1 artmasini istiyoruz

           T[] tempArray = items;//items dizimizdeki elemanlarimizi kaybetmemek icin gecici bir arraya gecici bir adrese, heap de 
            //gecici bir alana atiyoruz, tempArray referansina items in referansini atiyoruz yani items in adreesini tutuyor
            items = new T[items.Length + 1];//Boyle yaparsak icinde kac eleman varsa once o sayiyi verir ve ona 1 eklersek 
                                            //o zaman her new ledigimizde eleman sayisini 1 arttirmis oluruz ve bunu da dinamik yapmis olduk 
                                            //items.Length eleman sayisina gore gelecektir her zaman

            // COOOK ONEMLIIII-BASKA BIR PROBLEMIMIZ DAHA VAR!!!! DIZIYI NEW LEYINCE ESKI ELEMANLARI KAYBETMEMEK ICIN....
            //Biz bu methodu eleman eklemek icin yapiyoruz yani biz normalde elimizde elemanlari var olan bir diziye Add methodu 
            //olusturuyoruz yani biz dizi degiskenine .Add("Ahmet") icerisine eleman verince o elemani mevcut diziye ekstra olarak
            //eklemesini bekliyoruz.Ancak biz new leme yaptik birde dolayisi ile biz new ledigimiz anda Heap te yeni bir alan olusur
            //eski referans numaran hava da kalir ucar.Bizim problemimiz eski elemanlari kaybolmamasini saglamak
            //Bunu saglamak icin new lemeden hemen once dizi icinde mevcut elemanlari kaybetmemek icin onlari baska bir adrese 
            //kopyalariz ki onlari kaybetmeyelim

            //SIMDIDE GECICI OLARAK ELEMANLARI TUTTUGMUZ tempArray den ELEMENLARI ELEMAN SAYISINI 1 ARTTIRIP YENI BIR DIZI OLUSTUR
            //DUGUMUZ YENI BIR ADRES,ALAN TUTTURDUGUMUZ ITEMS A TEKRAR AKTARALIM FOR DONGUSU ILE
            //UNUTMAYALLIM DIZILERDE NE ISLEM OLURSA OLSUN ANCAK ELEMANLARINA AYRI AYRI ULASMAK ISTERSEK FOR ILE DONDURMEMIZ GEREKIR

            for (int i = 0; i < tempArray.Length; i++)
            {
                items[i] = tempArray[i];//gecici diziden eleman sayisini 1 arttirdgimiz diziye verileri aktardik tekrardan

                
            }
            items[items.Length - 1] = item;//Son elemana yeni elemani ekledik
            
           

    }

        public int Length
        {
           get { return items.Length; }
        }

        public T[] Items
        {
            get { return items; }
        }
       
    }
}
//NEWLEMEK DEMEK GIT HEAP BELLEKTE ADRES OLUSTUR, REFERANS AL ORDA YENI BIR ALAN OLUSTUR DEMEKTIR