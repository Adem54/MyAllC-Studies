using System;
using System.Collections.Generic;
using System.Text;

//INTERFACE NE ICIN VE NE TUR DURUMLARDA KULLANILIR
//Biz interface de tum sistemler icin bir sablon olusturuyoruz ayni zamanda da referans tutucu gorevi goruyorlar
//Interface leri birbirinin alternatifi olan ama kod icerikleri farkli olan durumlar icin kullaniriz!!!!!!!
//Kredi turlerinin hepsinde hesaplama vardir odeme plani vardir.Ama her bir kredi turunun kodlari farklidir,
//faiz orani farklidir, dosya masraflari farklidir
//kredi turu kurallari hepsinin kendi icinde farklidir iste boyle durumlarda interface kullaniriz......
//Ornegin siz projenizde loglama yapmak istiyorsunuz. Loglama nedir.KIm ne zaman hangi operasyonu cagirdi
//yani o sistemdeki olan hareketleri doktugumuz bir 
//dokumdur

//INTERFACE LERE BIR ORNEK DAHA...
//Loglama yi farkli yontemlerle uygulayabilirsiniz.Mesela loglarini bir dosyada tutabilirsiniz, loglarinizi bir
//veritabaninda tutabilirsiniz, loglarinizi sms
//olarak tutabilirsiniz.Ornegini biri bir krediye basvuruyu yapinca ona sms gonderilmesi veya mail gonderilmesi
//veya kendi sistemimizde onu dosyaya yazmamiz da
//onu veri tabanina yazmamizda loglamanin alternatifleri. Hepsi logluyor hepsinin imzasi ayni ama dosyaya yazarken
//dosyaya yazma kodlar, veritbanina yazarkek
//veritabanina yazma kodlari, sms yollarken sms yollama kodlari, email yollarken eposta yollama kodlari yazilir
//hepsinde yapilan islem bir loglamadir
//Bu sisteme bir log entegre edelim....
//Peki biz interface i en basta kullanmaya nasil karar veriyoruz. Cok basit birbirinin alternatifi olan sistemler var.
//Veritabanina yazma, dosyaya yazma, eposta
//yollama, sms yollama gibi birbirini alternatifi olan sistemler.Bazen alternatif sistemler vardir ama sen onun
//alternatifi oldugunu bilmezsin, tek sistem
//vardir o da veritabanina yazmadir baska da birsey istenmez ic musteri tarafindan, ic mussteri bankadaki ilgili birimler.
//Ic musteri sadece veritabani isteye
//bilir boyle durumlarda bile biz ona bir interface ekleriz

//Biz interface i olusturuyoruz cunku hem diger tum kredi turlerinin referansini tutsun ve interface de imzasini
//olustrudgumuz tum class larda yapilmaasi
//zorunlu operasyonlarin her classs in kendi kurallarina gore uyguladigi ayni isimli operasyonlari istedigimz sekilde
//tum class larda uygulayabilmek icin
//Ayrica ekstra yapmak istedigimiz kredibasvurusu gibi operasyonlar icin yazdigimiz class larda diger tum kredi
//turlerinde ortak olan bazi methodlar yani inter
//face de imzasi olan bazi methodlari biz kredibasvuru class inda hangisini istersek orda kredihesplamasini gormek
//istiyoruz ve kactane istersek de ayni anda
//gormek istiyoruz mesela o zaman iste yazdgimiz mehtod a paramtre olarak interface verrirsek Program.cs de biz o
//method da parametreeye hangi kredi turunu
/// istersek onu verebiliriz. Ozellikle birden fazla kreddi turune ayni anda ulasmak istersek de o zaman interface
/// i  Liste olarak parametreye veririz ve
/// Program.cs de o liste icine birden fazla kredi turu atabiliriz ve oraya attgimiz kredi turlerinin hesaplamasini
/// bir kere de getirtebiliriz.....
/// </summary>

namespace OOP3
{  //INTERFACE LERI NERDE KULLANACAGIZ!
   //Bir bankada krediler var ve biz krediler de geri donus tutarlari belirliyoruz ve onlara deniyor ki eger sen
   //bu kadar kredi cekersen
   //belli bir yil sonra ne kadar geri odemesi gerektigini hesaplayip musteriye geri donus tutari belirleniyor,
   //orn ciftci kredisi,
   //esnaf kredisi kullanirsan bu miktar, ciftci kredisi kullanirsak bu miktar, morgace kreadisi kullanirsan bu
   //kadar odersin seklinde 
   //tutarlar belirleniyor
   //Bu bankada bir cok kredi turu var mesela burda hesaplama yaparken eger tuketici ise boyle hesapla, esnaf
   //kredisi ise boyle hesapla
   //ciftci kredisi ise boyle hesapla diye if kullanirsak, ortalama bir bankada toplam tanimlanmis 100 lerce
   //kredi turu var
   //Siz eger tum mantigi tutup if ile bir class in icinde kurmaya calisirsaniz burasi karmakarisik bir hale doner
   //Bundan dolayi bu tip durumlarda biz once tum farkli kredi turlerinde ortak operasyonlarin olacagi CrediManager
   //adinda bir base manager olustururuz diger krediturlerine de onlara has operasyonlari koyariz ve onlar da
   //CrediManager i inherit
   //ederler
   //Biz olusturacagimz kendine ozel tum kredi turlerinin CrediManger i inherite almasini saglariz ve bu sekilde
   //CrediManager
   //classinda yazilan operasyonlari onu inherit alan diger class lara da yazmaya gerek kalmadan kullnmalarini
   //saglamis oluruz
   //Do not repeat your self kuralina uygun hareket etmis oluruz
    interface ICrediManager//Okunurlugu arttirmak icin biz interface isimlerini I harfi ile baslatirizki interface
                           //oldugu anlasilsin
    {
        //Interfacce de public kullanilmaz zaten o default olarak publictir sadece imza koyariz
        void Calculate();
        void CrediContracted();
        
    }//Interface icerisine su ana kadar var olan veya bundan sonra var olma ihtimali olan tum kredi turlerinde
     //olacagina kesin 
    //gozu ile bakilan operasyonlarin imzasi yazilir ve interface sablon demektir yani interface i implement eden
    //class lara biz
    //diyoruz ki sen interace in sablonuna uymak zorundasin
}

//INTERFACE LERI NEYE GORE VE NE ZAMAN, HANGI DURUMLARDA KULLANMALIYIZ???????????????????????????????
//Biz diger tum krediManager cesitlerine CrediManager i inherit aldirdik ancak tum bu farkli kredi cesitleri
//birbirlerinin 
//alternatifleridir hepsinin kendine ait bir faiz orani vardir ona gore dosya masraflari ve diger masraflari vs vardir
//Hepside CrediManager da yaptidimiz hesapla isini farkli bir sekilde ele alir  kendilerine ozel kurallarla ele alirlar
//CrediManager da bulunan Calculate methodu nu diger tum operasyon class lari kullanacak MortgageCreditManger,
//VehicleCreditManager,
//ConsumerCredtitManager hepsi de bu methodu adini kullanacak calculate islemi yapacak yani imza kismi hepsinde ayni
//  public void Calculate()=>Imza
//Ama Calculate methodunun iceriginde hepsinin kendine ozel kurallari var tum krediManager cesitleri bu hesapla
//islemini kendi
//kurallarina gore yaparlar.
//Iste imzanin ayni oldugu ama icerisinin farkli oldugu durumlarda biz BaseClass inda olusturdugumuz class i class
//olarak degil de 
//Interface olarak olustururuz
//Ayni base class mantiginda imzalari ortak olan ama icerikleri farkli olan operasyonlari interface imizde yazariz
//Interface de sadece imza yazilir suslu parantez yazilmaz
//Interface aslinda sablon gorevi goruyor
//Bir interface bize derki egerki birisi bu interface i kullanirsa interface icindeki methodu kullanmak zorundadir der
//Interface leri genellikle operasyonel methodlarda kullaniyoruz!!!!!!!!
