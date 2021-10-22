using System;

namespace Interfaces6
{
    class Program
    {
        static void Main(string[] args)
        {

            IPersonManager customerManager = new CustomerManager();
            IPersonManager employeeManager = new EmployeeManager();
            Internship internship = new Internship();

            //customerManager.Add();
            //employeeManager.Add();

            ProjectManager projectManager = new ProjectManager();
            projectManager.Add(customerManager);
            projectManager.Add(employeeManager);
            projectManager.Add(internship);

            Console.ReadLine();
        }
    }


    class PersonManager
    {
        //Buna implemented operation yani tamamlanmis veya ici doldurulmus operasyon deniyor
        public void Add()
        {
            Console.WriteLine("Eklendi");
        }
    }

    interface IPersonManager
    {
        //unimplemented olarak yazmak zorundayzi interface lerde buna imza diyoruz, tasarim diyoruz
        //Interface uyeleri disardan erisilebilir olmalidir yani default olarak zaten publictir onun icin bir daha public
        //yazilmaz
        //unimplement ici bos birakilmis, ibi doldurulmamis

        void Add();
    }

    class CustomerManager : IPersonManager
    {
        public void Add()//Add methodunun icini IPersonManager i implement eden class lar doldururlar
        {
            //Customer ekleme kodlari yazilir
            Console.WriteLine("CustomerManager eklendiii");
        }
    }

    class EmployeeManager : IPersonManager
    {
        public void Add()
        {
            //Employee ekleme kodlari yazilir....
            Console.WriteLine("EmployeeManager eklendi!!!!");
        }
    }


    //TUM PROJEYI TEK NOKTADAN YONETECEGIMIZ BIR CLASS OLUSTRURUZ
    //BIZ INTERFACE LERI ASIL BU TARZ CLASS LARDA KULLANACAGIZ YANI INTERFACE I IMPLEMENT EDEN CLASS LARIN ICERISINDE
    //YAZILMIS IMZASI AYNI OLAN ICERIGI FARKLI OLAN OPERASYONLARI AYRI BIR CLASS IN ICERISINDEN GENEL ADD ISLEMI GIBI
    //ISLEMLERI YONETECEGIZ ISTE BU BIZE SURDURULEBILIRLIGI SAGLIYOR YANI YENI BIR OZELLIK EKLEDIGIMIZ ZAMAN MEVCUT KODLARA
    //DOKUNMADAN ISLERIMIZI HALLETMIS OLACAGIZ....
    class ProjectManager
    {
        //Bu Add bu class in kendi Add i genel bir Add operasyonu olacak...
        //Yani burda Add methodumuzun icerisinde biz Customer ve Employee nin Add methodlarini calistiracagiz aslinda
        //Burda biz customer veya employee hangisini parametre olarak verecegiz birini versek digerini ekleyemeyiz
        //Iste burda biz paramtre olarak interface i verirsek onu implement eden hem
        public void Add(IPersonManager personManager)
        {
            personManager.Add();
        }
    }

    //Yeni bir ozellik ekleyelim sonradan bir tane ve bakalim kurdugumuz sisteme entegre olacak mi?
    //Hicbir sorun olmadan mevcut kodlara dokunmadan yeni bir ozellik ekleyebildik

    class Internship : IPersonManager
    {
        public void Add()
        {
            Console.WriteLine("Internship eklendi");
        }
    }
}

//Inheritance de ici doldurulmus bir methodu onu inherit edenler kullanabiliyor ama onu inherit edenlerin hepsi ayni
//methodu kullaniyor ancak inheritance da biz methodun sadece imzasini atiyoruz icini doldurmuyoruz icini o interface i
//implement eden class lar kendi sartlarina kendi kurallarina gore icini dolduruyorlar yani method isminin Add olmasi
//bizi yaniltmasin o Add isimli method un icini her class kendisi dolduruyor icerikler farklidir iste bu inheritance ile
//interface arasindaki onemli bir farktir
//Class ta inherit ---interface de implement denir
//Interface biz bir sablon belirleriz ve o interface i implement eden class lar o sablona uymak zorundadir deriz 
//Tabi ki  o sablonlarin iciini istedikleri gibi doldurabilirler
//Interface ler new lenemez
//Normal sartlarda class lar herbiri ayri bir tiptir ve bir classtan olusturulan bir degiskena baska bir class in instance
//si atanamaz..... Ama istisnamiz nedir eger bir class baska class lar tarafindan inherit edilmisse o zaman o inherit
// edilmis olan class kendini inherit eden classlarin referansini tutabilir yani o classtan olusan bir degiskene biz
//onu inherit eden class larin instancelerini atayabiliriz hatta inherit edilen class tipinde bir List veya dizi olusturup
//onun icerisiine onu inherit eden farkl class larin instancelerini atabiiriz
//Zaten bu dediklerimizden dolayi biz bir operasyon un parametresine sadece inherit edilen class i yazariz ve o metod calis
//tirilirken inherit edilen class i inherit eden class larin hepsini o paramtre yerine koyabiliriz
//Interface lerde de durum hemen hemen busekildedir interface ler onlari implement eden class larin referansini tutabilirler