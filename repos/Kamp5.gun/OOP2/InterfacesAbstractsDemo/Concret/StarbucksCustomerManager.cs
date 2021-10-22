
using MusteriYonetimSistUygulamasi.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygulamasi.Concret
{//Bir class ta ancak 1 tane class i inherit edebilir, 1 tane abstract class i inherit edebilir ancak birden fazla 
    //interface i implement edebilir.Ama hem class i inherit ediyor hem de interface i implement ederse inherit edilen class
    //veya implement edilen abstact class ilk yazilir devaminda virgul koyark interface ler yazilabilir
    public class StarbucksCustomerManager : BaseCustomerManager//,ICustomerCheckService
    {
        
        //BURAYI ANLAMALISIN!!!!!!! DEPENDENCY INJECTION-------
        ICustomerCheckService _customerCheckService;//Dependency injection yontemi ile initialize edersek bir constructor 

        public StarbucksCustomerManager()
        {
        }

        //olusturur ve parametre olarak da ICustomerCheckService yi verir

        public StarbucksCustomerManager(ICustomerCheckService customerCheckService)
        {
            _customerCheckService = customerCheckService;
        }

        //BURAYI ANLAMALISIN!!!!
        //---------------------------------------------------------------------------------------------
        
     

        public override void Save(Customer customer)
        {
            if (_customerCheckService.CheckIfRealPerson(customer))
            {
                base.Save(customer);
            }else
            {
                throw new Exception("Not a valid Person");
            }
            
           
        }

     
    }
}

//Starbacks in dogrulamaya ihtiyaci var o yuzden Save kullaniyor


//Normal bir class in icerisinde dogrudan bir method yazmak normal olan birsey degildir eger bir class in icersine method
//yazacaksak cok iyi dusunmeliyiz cunku o yazacagimiz method o anda ve ondan sonra da baska bir class da kullanilma
//ihtimali olmayan bir class olmali yani tamamen o class a ozgu olmali yoksa nesnellik problemi yasayacaksindir ilerde...

//Musteri yonetimini hazirladigimiz sirketleri birer nesne gibi dusunelim onlar da bir class tir yani
//Object-orianted ta hersey bir class dir herseyi biz class lar uzerinden yonetiriz
//Bu Starbacks in Customer larini yonetmek icin yazilmis bir nesnedir bir class tir

//Hem Starbacks da hem de Nero da ayni veritabanina kaydedecegimizi dusunelim ve bunlari sadece firma id ile dagitiriz
//Yani ikisinin de veritabani operasyonu kesinlikle ayni. Ikisini de ayni tablodan yonetecegiz
//Her ikisi de detayinda da ayni kodu yazacagi icin yani sadece imzalar ayni degil kodlar da ayni oldugu icin biz
//interface yerine abstract bir sinifi implemente edecegiz..

///Starbacks da mernis dogrulaamasi yapacagimiz icin biz Save methodunu BaseCustomerManager abstract class inda virtual
///yapmistik ve StarbacksCustomerManager class ina geliriz ve burda override deyip sonra imlecimize gelen secenekler arasindan
///Save methdouna tiklarsak SAve methodu icerisinde defatult kodu ile gelir simdi bize ne lazm dii hem default hali ile
///kaydedecekti ama oncesinde mernid dogrulamasi yapmasi gerekiyordu ondan dolayi default hali kalacak biz default halinin 
///ustine gelip mernis dogrulamasini orda yapmaya calisacagiz.......
///Ama dogrudan mernise baglanma ve dogrulamayi yapma kodlarini biz direk StarbacksCustomerManager da yapabiliriz ancak
///Yarin oburgn ayni seyi Nero da isterse veya baska bir sirketi de bu projeye dahil edecegimizi varsayalim o sirket de 
///Starbacks gibi bir talebi olursa o zaman mevcut koldarimiza mudahele etmemiz gerekecek ki bu olmamasi gereken bir durum
///Bundan dolayi biz Abstrackt klasorumuze bir tane ICustomerCheckService interface i olusturuyoruz....
///Burda bir kisi ile ilgili kontrolleri yapmak istiyoruz..
///Bir class in icine bir method yazacaksan uzerine kesinlikle iyice dusunmek lazim acaba bu ozellik simdi ve bundan sonrasi
///ile alakali olarak da bu methoda ozgu mu kalacak hep yarin oburgun o methodu eger baska bir musteri vs icin kullanma
/// ihtimali varsa o zaman  class in icine tutup da bir methodu dogrudan yazmaayalim kolay kolay....
/// BIZ ICUSTOMERCHECKSERVICE INTERFACE INI STARBUCKSMANAGER IMPLEMENT ETTIRMISTIK AMA DAHA IYI BIR YONTEM LE ONU DEGISTIRIRIZ
/// 
