using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{     //Biz PttManager da servise ihtiyaç duyuyoruz ve bağımlıyız  ve burda kullanacağımız bilgilere bağımlıyız
   
    //Bu bağımlılığı interfaceler aracılığı ile çözüyoruz
   //Biz burda interface class ını buraya vermezsek burayı çıplak bırakmış oluruz yani implement ve inheritance yi
   //eksik bırakmışım demektir bu da demekktir ki biz bunu kendimize kural olarak belirleyip gelecekte gelebilecek
   //talepleri düşünerek kodlama ve class ları çıplak bırakmama
    public class PttManager:ISupplierSurvice//En başta bunu vermeli idik
        // Maskeyi yi Ptt dağıtacağı için burda biz Ptt nin maske vermeyi yönetmesinde bu class ı
                     //kullanacağız ve burda PersonManager class ını da kullanacağız
    {

        //Gloabal alana bir tane değişken tanımlanıyor burda daha sonra da burda tanımlanan değişken
        //_applicantService ye constructor içerisindeki parametreden gelen değer atanıyor ki interface i getirmek için
        private IApplicantService _applicantService; //  TASARIM DESENİ

        public PttManager()
        {
        }

        //PttManager olarak başka bir sınıfa ihtiyaç duyuyorum ve ihtiyaç duyduğum sınıfı new lemek yerine onun interfaceini yazıyorum
        //Maskeyi verebilmem için benim PersonManager daki bir methodu çağırmam gerekiyor yani başvuruyu yapan
        //adam yani verilerini veya tc sini girince o tc doğru mu değil mi yada bu tc ptt nin elindeki tc
        //verilerine uyuyor mu şekllinde bir çek etme işlemi yapar

        //Bize class bu class başladğında lazm bu classın başlaması constructor diye bir yapıdır
        //Constructor  bloğu en önce çalışır class başlar başlamaz constructor çalışır ve biz çalışır çalışmaz da hemen uygulaması için interface classsı parametrede veririz
        //new yapıldığında ILK OLARAK constructor çalışır
        public PttManager(IApplicantService applicantService)//Class oluştuğunda. Kısacası biz PttManager i yenildiimiz zaman new lendiği
        {
            //oluşunca parametre olarak bir tane aday servisi vermemiz gerekti ve biz de IApplicantService yi verdik

            _applicantService = applicantService;//field lerı biz constructor dan set ederiz ondan dolayı alt çizgi ile başlarlar
        }

        //Biz private ile başlayan kod ile glabal da değişken tanımlıyoruz daha sonra public PttManager
        //constructorunda parametredeki değeri globalde tanımlanan değğişkene atayarak artık interface den
        //gelen apllicantservis i kullanılabilir hale getirmiş oluyoruz

        //  
        //PttManager ın bağımlı olduğu sınıf yerine o sınıfların interfaceini yazarız
        // Bir tasarım deseni kullanılır dependency injection

        public void GiveMask(Person person)//Maske vermeden önce ilk yapılacak iş başvuran kişinin çek edilmesi doğru elemn olup olmadığı
            //Yani PttManager ın PersonManager class ının içindeki methodu kullanmaya ihtiyacı var
            //Maskeyi verebilmek veriyi çek edebilmek için parametre olarak yine Person class ını vermemiz gerekiyor
        {

            if (_applicantService.CheckPerson(person))
            {
                Console.WriteLine(person.FirstName + " için maske verildi");
            }

            //İŞTE ALTTAKİ KODU YAZABİLMEMİZİ INTERFACE SAYESİNDE OLUYOR PTT MANAGER I KULLANILACAĞI ZAMAN YANİ
            //NEW LENECEĞİ ZAMAN YANİ KULLANILACAĞI ZAMAN YANİ NESNE VEYA OBJE OLUŞTURULACAĞI ZMAAN PARAMETREDE
            //İSTER FOREIGN ISTERSE DE PERSON CLASS I VEREBILIYORUZ. YANI HER KIM KI APPLICATION SERVISI KULLANIRSA
            //AYNEN FOREIGNMANAGER VE PERSON MANAGER I N YAPTIĞI GIBİ İŞTE BURASI YANI PTTMANAGER IKI SINIFIN HEM
            //FOREIGNER HEM DE PERSONMANAGER IN REFERANSINI TUTABILIYOR
            //INTERFACE LER NEW LENEMEZLER AMA REFERANS TUTUCULARDIR.
          //  PttManager pttManager = new PttManager(new PersonManager());//Biz yukarda applicant işlemi ş
            //Eğer bir sınıfı direk new leyip kullanıyorsan bağımlısındır
            /////////////////ÖNEMLİİİİİİİİİİİ
            //  PersonManager personManager = new PersonManager();
            

            //Bu Person class i sadece vatandas icindi ve sen mesela projede bu new leme olayı ile onlarca
            //yerde kullandın ve daha sonra projede değişiklik yapman gerekti ve Person dediğimiz sadece vatandaş
            //içinde ve projeye göre artık vatandaş olmayanlara da maske verilecek o zaman işte bizim projemiz
            //sürdürülmesi zor olaccaktırnew lediğimiz için yani gidip tüm new oluşturduğu yerlerde değiişiklik yapmak zorunda kalacaktır
            //Burada new ile obje oluşturmak veya nesne oluşturmak demek o class a bağımlı  olmak demektir
            //Bu şekilde başka bir class da new lerek obje veya nesne oluşturarak biz eğer işlem yaparsak
            //o zaman değişiklik taleplerine bizim sistemimiz direnç gösterecektir
            //Bu şekilde new leyerek başka class tan yeni bir obje nesne oluşturarak işlem yapmak sürdürülebilrliğe ters dir aslında
            //Örneğin sadece kendi vatandaşına değilde başka ülkenin vatandaşına da maske vermek isterse o zaman
            //bizim bazı değişiklikler yapmamız gerekir işte bizim sistemimiz direk uyum sağlıyor mu değişiklik
            //taleplerine yoksa direnç mi gösteriyor bu çok hayatidir
            //Biz bu sayfada personManager dan new leyerek bu methodu PersonManager a bağımlı hale getirdik işte
            //
            //bizim burda PersonManager a bir bağımlılığımın olmaması gerekiyor işte bunun içinde her zaman class lara başlarken önce abstarct klasöründe interface class ı  oluşturarak başlanır işe

          //  if (personManager.CheckPerson(person)){// CheckPerson sonucu nda default olarak true kabul edildiği için illa ki ==true dememize gerk yok
              //  Console.WriteLine(person.FirstName + " için maske verilmiştir");
            //}

         
            
        } 
    }
}

