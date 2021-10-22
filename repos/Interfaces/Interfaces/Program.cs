using System;

namespace Interfaces
{   //Interface lerde mantık biz interface lere belli şablonlar oluştururuz ve bu şablonlar onu implement eden class larda olmak zorundadır
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // IPersonManager personManager = new IPersonManager();=>interface ler newlenemez....
            //biz interface i değil biz interface i implement eden class ları newleyeceğiz ama şuna dikkat
            //edelim biz değişken oluştururken önce değişken tipini veriyoruz ki burda da tip olarak
            //
            //interface ismini veririz nasıl ki class larda o classs ın ismini veriyoruz aynı şekilde interface de bir tipdir aslında string,integer gibi
            //burda da interface ismi değişkenimiz= new ve interface imizi implement eden class ismini veririz
            //Peki nasıl oluyor da interface değişkeni bir class tan oluşan instance veya obje,nesne yi tutuyor çünkü interface lerde referanse tiplerdir
            //Interface ler onu implement eden class ın referans numarasını tutabilirler, referans adres numnarasını tutabilirler
            //Şu kısmıda hatırlayalım biz bir class ı newleyip ondan bir instance oluşturduğumuzda veya obje,nesne oluşturduğmuzda
            //o gidip heap kısmında birr adres oluşturuyor du ve referans tiplerde değerler değill adres ler tutulur
            //interface ismimiz sonra değişken ismi çünkü interface de bir değişken tipidir eşittirin sağ tarafına ise new dedikten sonra
            //biz interface imizi implement etmiş herhangi bir class ı new leyebiliriz.Bu arada interface i implement etmiş demek bir class ın sanki başka bir
            //class ı inheritance alması gibidir ama inheritance alınan interface olduğu için biz buna implement edildi deriz
            IPersonManager personManager = new CustomerManager();
            //Artık personManager değişkenimizde ister Add() methodunu ister Update() methodunu çağırabiliyoruz
            personManager.Add();
            personManager.Update();

            IPersonManager employeeManager = new EmployeeManager();
            employeeManager.Add();
            employeeManager.Update();
            /////////////////////////////////////////////////////////////////////////////
            ProjectManager projectManager = new ProjectManager();
            //  IPersonManager customManager = new CustomerManager();
          // biz projectManager.Add parametre olarak CustomerManager ı new lemiş oluyoruz yani aslında IPersonManager interfacei türüdür değişken
          // adı da customerManager dersek o zaman biz parametre yerine yani new CustomerManager() yerine customerManager değişkenini de
          // koyabilirdik 
            projectManager.Add(new CustomerManager());//Bizden ProjectManager clasından oluşturduğumuz nesnemize parametre olarak IPersonManager
                                                      //vermemzi istiyor ama IPersonManager ise interface dir tekbaşına oraya yazılamaz
                                                      //çünkü interface ler unutmayalım newlenemez o zaman biz ne yapıyoruz biz de IPersonManager interfaceimizi
                                                      //implement eden class ları parametre olarak verebiliriz o zaman biz ne yapmış oluyoruz bize
                                                      //ne lazım sa parametreye onu vererek işlemimizi tek class üzerinden çözmüz oluyoruz
                                                      //yani hem CustomerManager hem de EmployeeManager ı hallediyoruz ayrıca birde eğer sonradan ekstra
                                                      //yeni class oluşturmamız gerekirse onu da doğrudan tüm sistemimize adapte edebilecek bir sistem kurmuş oluyoruz
            projectManager.Add(new EmployeeManager()); //EmployeeManager ı da implement ettiği için onun da interface değişkenimiz onu tutabiliyor çünkü interace de bir reference tipdir

            IPersonManager internManager = new InternManager();
            projectManager.Add(internManager);
        
        }  ////////////////////////////////////////////////////////////////////////////////////7
    }

    class Person { }////Interface lerde ise class ın içersinde üyeler oluyor ama üyelerin içi boş oluyor

    class Customer:Person //Customer class ı Person class ını inherit ederek artık Person class ının içerisindeki tüm metholdarını kullanabiliyordu
    { }
 
    //Interface lerde nasıl yapıyoruz ona bakalım
    //interface diye yazdıktan sonra interface ismi de büyük harfle başlar yani PascalCase mantığındadır ve başına da interface in I si getirilerek isimlendirirlir
    interface IPersonManager {
        //interface lerde implemented değil unimplemented olarak yazmak zorundayız methodlar ve ya fonksiyonlarda
        //Unimplemented
        //interface üyeleri dışardan erişilebilir olmalıdır o yüzdeen default olarak publictir tekrar public yazmıyoruz
        void Add();
        //Biz şimdi bir interface yazmış olduk normal class tan farkı biz interface de içini doldurmuyoruz implement etmiyoruz unimplement ediyoruz
        //Class larda Add methodunun içerisine yazdığımız operasyonlar heryerde ortak demekti ama interface öyle değil Add methodu heryerde ortak değil
        //Yani interface i iplement eden class lara göre ekleme ayrı oluyor biz void Add(); kısmına da imza diyoruz
        //class larda biz bu işleme inherit derken- Bir class ın interface i alma işlemine implement(class larda inheritance) diyoruz
        //Interface ler newlenemez bunu hiç bir zaman unutmayalım!!!!!
        void Update();//Bir imza daha ekliyoruz buraya ve biz interface içerisinde yazdığımız imzalarla diyoruz ki bu interface
                      //i implement eden class larda Add ve Update imzası olmak zorunda demiş oluyoruz
                      //Biz Update imzasını interface e eklediğimiz zaman eğer bu interface imizi implement etmiş olan class lar
                      //içerisinde Update imzası yoksa o zaman  IPersonManager interface sini implement edeen class ismin yanına
                      //yazdığımız interface ismi nin altı çizilecektir ve uyarı verecektir, yani kısacası bizim interfaceimizin
                      //imzaları interfaceimizi implement eden class larda bulunmak zorundadır yoksa uyarı alırız 
    }

    class CustomerManager : IPersonManager //Interface imizde "void Add();" imzaasına sahibiz ama CustomerManager ın içindeki Add ayrıdır EmployeeManager
                                         //içindeki kod ayrıdır her ikiside aynı imzaya sahip olmasına rağmen
    {
        public void Add()
        {
            //Müşteri verileri eklendi
            Console.WriteLine("Müşteri verileri eklendir");
        }

        public void Update()
        {
            Console.WriteLine("Müşteri güncellendi!");
            //throw new NotImplementedException()=>//İçini doldurmadığımız zaman hata mesajıdır bunu silebiliriz
        }
    }

    //Biz interface ile bir şablon belirliyoruz ve interface i implement eden class lar ın bu şablona uymak zorunda olduğunu
    //belirtmiş oluyoruz ki zaten bunu biz bir interface i implement edince interface imizin altı çizili oluyor biz seçeneklerden
    //implement deyince doğrudan zaten interface içerisinde oluştrduğumuz şablonu otomatiik getiriyor
    //Interface i implement eden class lar interface imzasını taşımak zorundadır yani "void Add();" imzasını veya interface de
    //hangi imzalar(yani içi doldurulmamaş-unimplement edilmiş olan method veya fonksiyonlar) taşımak zorundadır
    //yoksa hata verir zaten ama içerisine tabiki kendi kodunu yazabilir

    class EmployeeManager : IPersonManager
    {
        public void Add()
        {
            //Personel verileri eklendi
            Console.WriteLine("Personel verileri eklendi");
        }

        public void Update()
        {
            Console.WriteLine("Personel güncellendi!");
            //throw new NotImplementedException();İçini doldurmadğımız için gelen hata mesajıdır
        }
    }

    //YAZILIMDA ÇOK HAYATİ BİR PRENSİP VARDIR YENİ ÖZELLİK EKLENECEĞİ ZAMAN MEVCUT KODLARA DOKUNULMAZ!!!!!!!
    //Biz sistemimizi interface üzerine kurduktan sonra hemen bir senaryo olarak şirkete yeni bir stajyer alınacak ve biz onları
    //da sistemimize dahil etmek istiyoruz. İşte şimdi bakalım interface kullanmak bize yeni bir değişiklikte neler getiriyor ona bakalım!

    class InternManager : IPersonManager//InterManager da bir IPersonManager dır çünkü biz eleman bilgilerini ortak bir yerde tutmak için
                                        //IPersonManager ı oluşturmuştuk dolayısı ile IPersonManager ın altı otomatik çizilir niye
                                        //çünkü IPersonManager interfacimize bıraktığımız imza desenlerini burda kullanmak zorundayız
                                        //ki altı çizili kısma gelip seçeneklerden implement dersek zaten otomatik imza desnelerini getirecektir
    {  //Biz Add ve Update operasyonları içerisine istedğimiz kodları yazdıktan sonra şimdi sadece yukarı gidip InternManager ı
       //newleyip onu Interface değişkenine atayıp o değişkeni de ProjectManager dan oluşan nesne ile çağırdğmız Add methoduna
       //parametre olarak atamak kalıyor hatta biz doğrudan bu ProjectManager nesnesi ile çağırdğmız Add methodunun içinde
       //InternManager ı newleyede biliriz
       // IPersonManager internManager = new InternManager();  projectManager.Add(internManager); projectManager.Add(new InternManager());
       //Bu şekilde sonradan projemize eklenebilecek yeni elemenları diğer kodlara hiç dokunmadan ki bu bir prensiptir yeni birşey
       //ekleneceği zaman mevcut kodlara dokunulmadan yeni değişikler projeye eklenir

        public void Add()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Stajyer Eklendi");
        }

        public void Update()
        {
            Console.WriteLine("Stajyer Güncellendi!");
          //  throw new NotImplementedException();
        }
    }


    class PersonManager
    {
        //Implemented Operations-İçi doldurulmuş implemente edilmiş fonksiyon, operasyon deniyor bir method yazılıp içerisi doldurulmuşsa eğer
        public void Add() 
        {
            Console.WriteLine("Eklendi");
        }
}
   //class CustomerManager: PersonManager //CustomerManager class ı PersonManager class ını inherite ediyor burda.... { }

    class ProjectManager //Tüm projeyi tek noktadan yöneteceğimiz bir class oluşturuyoruz
    {
        //Amacımız burdaki Add operasyonunda hem Customer hem de Employee istedğimiz gibi eklemektir. Asıl amacımız projemizi tek bir noktadan
        //yönetebilmektir yani denilebilir ki ne gerek var ProjectManager doğrudan diğer class ları çağırıp ekleyeceğmizi onlara ayrı
        //ayrı eklesek olmaz mı o kullanımdaki problem biz birden fazla nesne ile çalışacağız ve her zaman projemizde değişiklik teklifleri de alabilrizi

        //HATALI KULLANIM!!!!!
        //public void AddCustomer(CustomerManager customerManager)//Genel bir Add operasyonu yazıyoruz yani Add methodu yazıyoruz burda bu Add in interface den
        //gelen Add ile alakası yok karıştırmayalım 
        //{          customerManager.Add();//Bunu bu şekilde yazdıktan sonra gidip Main methodunda classımızı newleriz ve bu methodumuzu çalıştırırız tabi 
        //}
        //Main içerisinde CustomerManager customerManager=new Customermanager();
        //ProjectManager projectManager=new ProjectManager(customerManager);
       // HATALI KULLANIM!!!!!
       // public void AddEmployee(EmployeeManager employeeManager)
        //{            employeeManager.Add();
        //}
        //DOĞRU KULLANIMA BAKALIM
        //Bizim ekleme işlemini tek bir merkezden yöntetmek istediğimiz class da ekleme yapmak istedğğimiz class lar
        //EmployeeManager ve CustomerManager class ları IPersonManager ı yani interfacePersonManager ı implement ediyordu
        //dolayısı ile interface ler kendini implement eden class ların referansını tutabiliyordu işte bu kısım işin püf noktası
        //onun için biz burdaki genel Add operasyonumuza parametre olarak ne CustomerManager ne de EmployeeManager veririrz onun
        //yerine biz doğrudan interface imizi veriririz ve bundan sonra asıl bizim Main içerisinde işi nasıl koparacağımıza odaklanalım
        public void Add(IPersonManager personManager)
        {
            personManager.Add();
        }
    }

    //YAZILIMDA EN BÜYÜK PROBLEM SİZ PROJEYİ BİTİRİRSİNİZ 3 AY SONRA MÜŞTERİNİN YENİ TALEPLERDE BULUNMASIDIR BU KABUL
    //ETMEMİZ GEREKEN BİR GERÇEKTİR ÇÜNKÜ YAZILIM DEDİĞİMİZ ŞEY YAŞAYAN BİR ORGANİZMA. BİZ YANLIŞ ANLAMIŞ OLABİLİRİZ, MÜŞTERİ
    //YANLIŞ ANLATMIŞ OLABİLİR, MEVZUAT DEĞİŞEBİİR HERYEŞ OLABİLİR 
    //

}
