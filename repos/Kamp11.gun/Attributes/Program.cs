
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { Id = 1, FirstName="Adem", LastName = "Erbas", Age = 33 };
            CustomerDal customerDal = new CustomerDal();
          //  Console.WriteLine(customer.Id + customer.FirstName + customer.LastName+ customer.Age);
            customerDal.Add(customer);


           
            Console.ReadLine();

           
        }
    }

    //Biz attribute yapisini genellikle dinamik sorgular uretmek icin kullaniriz
    //Calisma esnasinda nesnelere veya nesne property ve methodlarina anlam katmak icin attribute ler kullaniriz

  [ToTable("Customers")]//Veritabanindaki Customers tablosu
  [ToTable("TblCustomers")]
    //Iki tane alt atla kullanilmasina izin verdigimiz icin kullanabiliriz
    //AllowMultiple =true 
    //Burda da mantik ya Customers i ara Customers i bulamazsan TblCustomers a uygula gibi birsey demek

    //    Bir nesneye, bir methoda veya bir ozellige kisacasi C# yapilarina uygulayabilecegimiz ayrica yapilardir						
    //Bu yapilar vasitasi ile attribute uyguladigimiz yapiya anlam katiyoruz
    //Is kurallarimizi yazarken add, delete, update islemlerinde gonderilen nesne propertylerinden 
    //    istemedgimiz formatta olan varsa ona bir tepki gosterelim veya ona bir uyari vermek istedigimiz
    //    zaman attribute leri kullanabiliriz
    //Bu kurali merkezi bir noktada attribute lerle yonetebiliriz yani heryerde gidip if ile is kuralimizi
    //    kontrol etmek yerine bu sekilde cok daha kolay bir sekilde kontrol edebiliriz

    class Customer
    {
        public int Id { get; set; }
        [RequiredProperty]//FirstName I girmek zorunlu olsun demis oluyoruz
        public string FirstName { get; set; }
       [RequiredProperty]//LastName I girmek zorunlu olsun demis oluyoruz

        public string LastName { get; set; }
       [RequiredProperty]//Age i girmek zorunlu olsun demis oluyoruz

        public  int Age { get; set; }
    }

    class  CustomerDal
    {
        [Obsolete("Don't use Add, instead use AddNew methdo", true)]
        //Add methdunu kullanma yerine AddNew kullan
        //[Obsolete] hazri bir attribut e dur 
        //Add methodunu kullanmaya calisirsak uyari verecektir
        //Ama eger Add methodunun hic kullanilmasini istemezzsek de o zaman 2.parametre kulanabilirz
        //Erro parametresi ne true verirsek o zaman sadece mesaj vermez ayni zamanda kullanima da izin vermez
        public  void Add(Customer customer)
        {
            //string message = String.Format("{0,5},{1},{2},{3}  added",
            //    customer.Id + customer.FirstName + customer.LastName + customer.Age);
            Console.WriteLine(customer.Id + customer.FirstName + customer.LastName + customer.Age);

        }
        //Ornegin biz projemizde artik Add methdodunu kullanmayacagiz bundan sonra NewAdd methdounu kullanacagiz
        //Ama daha onceki yazdigimiz kodlardan dolayi da Add methodunun da kalmasin gerekiyor silemiyoruz
        //Bu tur durumlarda kullanilmasini istemedigimiz methodu uzerine [Obsolete] hazir attribute yazariz
        //Ve demis oluruz ki artik bunu kullanma
        //Biz bu sekilde hazir attribute leri kullanabiliriz
        public void NewAdd(Customer customer)
        {

        }
    }

  
   
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,AllowMultiple =false)]
    //RequredProperty attribute sadece propertylerde ve field larda kullanilsin demektir
    //Veya sadece propertylerde de kullanabiiriz
    // AllowMultiple =false=>Ust uste 2 kez kullanilmasina izin vermemiz oluyoruz
    //RequiredProperty
    //RequiredProperty

    //Attribute tanimlamak, olusturmak
    //Bir attribute kendi required attributunu yazabilmesi icin isminin sonu Attribute ile bitmeli
    //Attribute sinifindan inherit edilmeli
    //Biz bu RequiredPropertyAttribute class ini yazdiktan sonra artik  [RequiredProperty] sekilde kullanabilirizz
    class RequiredPropertyAttribute : Attribute
    {

    }

    //[ToTable("Customers")] Customers parametresi yollanmis attribute, attribute zaten bir class olduguna
    //gore biz class lara parametreyi constructor uzerinden veriyorduk unutmayalim
    //Olusturdgumuz attribute u sadece class larda kullanmak istersek onada bir attribute  yazariz
    //Attribute uzerine bu sekilde bir attribute yazarak o attribute kullanimini sinirlandirabilirz
    //[AttributeUsage(AttributeTargets.Class)] ToTableAttribute u sadece class larda calisir
    //Eger attribute sadece methodlarda calismasini istersek de
    //[AttributeUsage(AttributeTargets.Method)]
    //[AttributeUsage(AttributeTargets.Property)] sadece propertylerde kullanilmasini istersek
    //Hem Clsass da hem de mehtodda kullanilmasini istersek
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple =true )]
    //AllowMultiple =true aynii attribute un birden fazla arka arkaya veya alt alta ayni atrubute kullanimina
    //izin verir
    //Eger hicbirsey yazmazsak varsayilan olarak [AttributeUsage(AttributeTargets.All)] herseude gecerlidir
    class ToTableAttribute : Attribute
    {
        private string _tableName;
        public ToTableAttribute(string tableName)
        {
            _tableName =tableName ;
        }

    
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple =true)]
    class TestAttribute : Attribute
    {
        private Type _getMessage;
        //Attribbte icinde parametre de baska bir nesneye ait kurallarin  attribute un uzerine kondugu nesneye uygulanabilmesi icin
        // biz baska bir nesneyi parametreye Type tipi ile koyariz
        public TestAttribute(Type getMessage )
            //Attribute te constructor da baska bir nesneyi Type tipi ile gecmek zorundayiz!!!!!
            //Attribute u uygulayacagimiz class in getMessage class indan turetilen instancesindeen
            //gelen kurallara uymasi icin yani  [TestAttribute(typeof(GetMessage))] bu sekilde kullanabilmek icin
            // [TestAttribute(typeof(GetMessage))] altina yazilan class GetMessage nin kurallarindan gecmeden calismaya baslamasin 
            //demektir

        {
            _getMessage = getMessage;
        }

    

    }


   public class GetMessage
    {
    
            public void Message()
            {
                Console.WriteLine("Bu method calistirilmadan once bu tipin kurallari dikkate alinmalidir!!!!");
            }
        
    }


    public class ProductManager
    {
     [TestAttribute(typeof(GetMessage))]//GetMessage tipinin kurallarii uygula Add methodunu calistirmadan once
     //Validation lar bu sekilde yapiliyor.Gelen product verisinin is kurallarina uygun olup olmadigi denetlenirken 
     //Run-time calisma esnasinda Reflection sayesinde Add methodunun oncesine araya bu attribute ile GetMessage icindeki
     //kurallardan geciyor da ona gore Add methodu calismaya basliyor bu yapilan isin adi Interceptor yani araya girme anlamina gelir
        public void Add(Product product)
        {
            Console.WriteLine("Product Eklendi!");
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }



    class SampleAttribute : Attribute
    {
        public string Name;
        public string Version;
    }

    [Sample(Name ="Adem", Version="1.0")]//Birkactane ayni methdoun versiyonun belirtmek isteyebiliriz
    //Kodu okuyan kisiye o method veya class la ilgili dikkat etmesi gerken veya bilmesi gereken 
    //seyleri belirtiyoruz 
   public  class GetInfo
    {
        public string GetAdSoyad()
        {
            return "Adem Erbas";
        }
    }


  
    public class Calculate
    {
        public int GetNumber()
        {
            return 5 + 8;
        } 
    }

   




}
//"{ 0},{1},{ 2},{ 3}  added",