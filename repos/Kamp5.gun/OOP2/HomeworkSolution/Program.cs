using HomeworkSolution.Concretes;
using System;

//PROJE YAPARKEN IPUCLAR....
//Bir projeye baslarken ilk yapacagimiz is varliklilarimizi bulmak yani bizim olusturacagimiz property class larimizi netlestirmek
//Projeimzde bir oyuncudan bahsediliyor dolayisi ile bu iste bir property class idir 
//Bunlarin kayit olabilcegi, kayitlarin guncellenebilecegi ve silinebilecegi bir islemler deniliyor bunlar operasyondur
//Yani bunlar method, veya operasyonn class i olusturacagiz..
//Biz operasyon sinifi olusturacagimiz zaman bir aliskanligimiz olsun hemen 1 tane interface ile baslamaliyiz....
//Biz 1 tane interface olustururuz ve interface leri biz o entity class imizi property class imizla iligili islem ici yazdigimiz
//icin biz interface lere GamerService ismini veririz property class imizin ismi Gamer ise ornegin
//Interface i implement edecek class imiza da GamerManager diye adlandiririz bu isimlendirmeler artik standart
//bir sekilde kullanabiliriz
//Peki biz neden hemen dogrudan bir operasyon olur olmaz interface ekliyoruz.Suna mutlaka alismaliyiz biz hicbirzaman hicbirsinifi
// ciplak birakmamaliyiz!!!!!!Dolayisi ile biz bir operasyon class i yazacagimiz zaman ilk once gidip interface yazmaliyiz sonra
// gelip o interface i implemente edece class larimizi yazmaliyiz.........
//Ciplak birakmak demek bir operasyon class inin herhangi bir inheritance veya implementasyon almamasi demektir
//Eger bir class ini ciplak birakiyorsan anla ki ilerde problem yasayacaksin....................
//Bizim disardan bir servisi kullanip orayi kullanarak bir dogrulama yapma vs islemleri icin kullandigimiz bir servise 
//MicroServis deniyor
//GamerManager class imin icerisinde baska bir servis kullanacagim

//Interface yazarken icerisine biraktigimiz imzamiza parametre olarak Gamer i verdik  ama biz bunu daha profesyonel yapabilrdik
//Biz burda Gamer i bir User adli bir inherit edilmis ortak bir property class indan da getirebilirdik ki yarin oburgun biz
//sisteme sadece oyunculari degil baska person tiplerini de kaydedebilmek icin...
//Yani property classs lari olustururduk ve ortak bir class olusturup ortak verileri onda tutardik ve bu parametreye de
//o ortak class i verirdik ki o ortak class i da diger property class lar ya inherit ederdi ya da interface olarak verirsk
// de implement ederdi...
//Gercek proje hazirlarken de mesela bizim bir dogrulama servisine ihtiyacim var veya bir eticaret sitesi yapiyoruz ve bizim
// kredi karti alisverisini dogru yapip yapmadigimizi test etmek icin illa gidip gercekten bir alisveris yapip test edilmez
//Fake yapilarla calisilarak test edilir yani lokalde fake yapilarla calisilarark test edilir
//COK ONEMLI NOT!!!!!!!!
//DEPENDENCY INJECTION...BAGIMLILIKTAN KURTARIMIS OLUYORUZ....
//Bir manager sinifinin icerisinde baska bir manager sinifini kullanacaksan yani bir manager class inin icindeki bir method
//sana diger manager sinifinda lazim ise kesinlikle  ihtiyacin olan manager sinifini kullanacagini diger operasyon sinifi 
//icerisinde NEWLEMEMELISIN!!!!!!
//DEPENDENCY INJECTION ILE BIZ CONSTRUCTOR A PARAMTRE OLARAK KULLANACAGIMIZ MANAGER SINININ SOYUTUNU INTERFACINI VERIRIZ VE
// CONSTRUCTOR ICERISINDE BIZ O INTERFACE UZERINDEN IHTIYACIMIZ OLAN CLASS I GLOBALLL HALE GETIRIRIZ.... 
//public GamerManager(IUserValidationService userValidationService) { _userValidationService = userValidationService;}
//Bu islemle disardan bir class i ben bu class icerisindeki tum
//operasyonlarda kullanma firsati vermis oluyorum....
//COKK ONEMLIIII-BIZ NEDEN KENDIMIZ BIR DOGRULAMA SERVISI YAZARIZ DIREK SERVISTEN DOGRULAMAYI
//ADD ISLEMINDEN ONCE KULLANMAK YERINE????????????????????????
//Biz GamerManager icesinde Add methodunda once dogurlama yapariz ama bu dogrulamayi dogrudan Mernis veya baska bir servisten
//yapmayiz da kendimiz bir dogrualama servisi yazarizzz ki biz direk bir servise bagimli olmayalim mesela bugun bir servis le
//calistik yarin baska bir servisle calismamiz gerekirse yeni servisi dogrudan sistemimize dahil edebilmeliyiz...
//GERCEK HAYATTAN BIR SENARYO!!!!!
//Diyelim ki yarin devlet bu dogrulama senaryosunu bambaska bir sisteme gecirdi..
//Diyelim ki devlet kimlik dogrulama sistemini degistirdi ve Mernis ile dogrulama yerine artik yeni bir dogrulama sistemine gecti
//O zaman hem geliriz bir tane yeni bir dogrualama manager i olustururuz NewEStateUserValidationManager adinda ve
// bu class da IUserValidationService interface ini implement ettirririz ve interface dekiimzamiz otomatik buraya getirirz
// artik dogrulama kodlarini yeni sisteme gore bunun icerisine yazariz ve tum sistemimiz ayni sekilde 
// hic birseye dokunmadan calismaya devam eder....
//Iste amac da bu zaten interface leri kullanmaminn getirdigi olay da tam olarak bu...

//3.Sisteme yeni kampanya girişi, kampanyanın silinmesi ve güncellenmesi imkanlarını simule ediniz.
//3. MADDE DE ISTENILEN LER
//SUNU UNUTMAYALIM EGER BIR ISLEM OPERASYON VARSA ONCESINDE BIR PROPERTY CLASS I VARDIN ONCE O OPERASYONUN PROPERTY CLASS INI
//YAZ YANI KAMPANYA PROPERTY CLASS I SONRA DA KAMPANYA INTERFACE I SONRA DA KAMPANYA MANAGER I YAZACAGIZZZZZ
//
//4.     Satışlarda kampanya entegrasyonunu simule ediniz.
//4. SATISLARDA KAMPANYA ENTEGRASYONU DIYOR YANI BURDA SATISLAR ICIN 1 TANE ORDER PROPERTY SONRA ORDER INTERFACE SONRA DA 
// ORDER MANAGER OLUSTURURUZ VE SATISA DA KAMPANYA ENTEGRESI ICIN KAMPANYA OPERSASYON UNU ORDER CLASS ININ ICERISSINE
// DEPENDENCEY INJECTION YONTEMI ILE ENJEKTE EDEREK ORDERMANAGER ICERISINDE KAMPANYA MANGER I KULLANABILMELIYIZ.....
//




namespace HomeworkSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Gamer gamer1 = new Gamer() { FirstName = "Adem", LastName = "Erbas", BirthYear = 1988, IdendityNumber = 12345 };

            //GamerManager gamerManager = new GamerManager(new UserValidationManager());
            
            //DEVLETIN DOGRULAMA SERVISINI DEGISTIRME SENARYOSU UZERINE YAZDIGIMIZ YENI DOGRULAMA OPERASYON SINIFIMIZ 
            //SORUNSUZ CALISIYOR MEVCUT SISTEME DOKUNMADAN DIREK SISTEME ADAPTE OLDU....
            GamerManager gamerManager = new GamerManager(new NewEStateUserValidationManager());
            gamerManager.Add(gamer1);

            Console.ReadLine();
        }
    }
}


//Bir oyun yazmak istiyorsunuz. Bu yazılım için backend kodlarını C# ile geliştirmeyi planlıyoruz. 
//    Yeni üye, satış ve kampanya yönetimi yapılması isteniyor. Nesnelere ait özellikleri istediğiniz gibi verebilirsiniz.
//    Burada amaç yazdığınız kodun kalitesidir. Ödevde gereksinimleri tam anlamadığınız durum benim için önemli değil, 
//    kendinize göre mantık geliştirebilirsiniz. Dediğim gibi kod kalitesiyle ilgileniyoruz şu an :)



//Gereksinimler

//1.Oyuncuların sisteme kayıt olabileceği, bilgilerini güncelleyebileceği, kayıtlarını silebileceği bir ortamı simule ediniz.
//    Müşteri bilgilerinin doğruluğunu e-devlet sistemlerini kullanarak doğrulama yapmak istiyoruz.
//    (E-devlet sistemlerinde doğrulama TcNo, Ad, Soyad, DoğumYılı bilgileriyle yapılır. 
//    Bunu yapacak servisi simule etmeniz yeterlidir.)

//2.Oyun satışı yapılabilecek satış ortamını simule ediniz.( Yapılan satışlar oyuncu ile ilişkilendirilmelidir.
//    Oyuncunun parametre olarak metotta olmasını kastediyorum.)

//3.Sisteme yeni kampanya girişi, kampanyanın silinmesi ve güncellenmesi imkanlarını simule ediniz.

//4.     Satışlarda kampanya entegrasyonunu simule ediniz.

//5.     Ödevinizi Github’a yükleyiniz. Github linkinizi paylaşınız.