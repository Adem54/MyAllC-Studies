using System;

namespace Constructors1
{  //Constructor da amacimiz bir sinifin ilk olusum anini kontrol etmektir
    //Constructor bir class ı new lediğimiz zaman yani bir class dan new ile yeni bir obje veya nesne oluştrudğumuz zaman ilk çalışan bloktur
    //Bir class ilk kez oluştuğu zaman bir kere çalışır ve bir daha çalışmaz
    class Program
    {//Kodlarımızı çalıştıracağımız ana class içinde yani Program class ı içerisinde methodumuzun çalışması için static ile başlaması gerekiyor bunu unutmayalım
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // customer1,customer2,customer4,customer5 bu 4 new leme olayında da aşağıdaki default yani parametresi olmayan constructor çalışacaktır
            Customer customer1 = new Customer();//Dikkat edelim biz new Customer() yazınca sanki bir method veya function çalıştırıyor
            //Eğer constructor a hiç parametre vermezsek veya default olarak kullanırsak arka tarafta kendisi oluşan şekliyle o zaman
            //kendimiz elemanı customer1 değişkeninde olduğu gibi ekleyebiliyoruz. Biz bir class a değişken verip sonra


            //customer2 de biz constructor a eleman atayabiliriz ancak bu yöntem ile biz default halinde obje veya nesne oluşturup ona eleman göndermiş oluyoruz 
            //yani herhangi bir parametre vermezsek o zaman bu şekilde eleman atarız ancak biz Customer classından constructor
            //oluşturursak ve parametreler verirsek o zaman burası problem olur çünkü biz default halini ezmiş oluyoruz bizim
            //bu tarafta yazdığımız constructor geçerli olmuş oluyor. Peki hem default halini hemde kendimiz bu tarafta parametre vererek oluşturdğumuzz
            //constructor ın çalışması için ne yaparız overloading yapıyoruz
            Customer customer2 = new Customer { Id = 12, FirstName = "Engin", LastName = "Demirog", City = "Oslo" };                                   //gibi yaparız ki zaten aslında biz burayı bu şekilde yazınca Customer Constructor ı

            //Paramtresi olmayan constructor a biz default constructor diyoruz
            Customer customer4 = new Customer() { Id = 16, FirstName = "Kemal", LastName = "Ata", City = "Madrid" };

            Customer customer5 = new Customer();
            customer5.Id = 20;
            customer5.FirstName = "Kristian";
            customer5.LastName = "Johannes";
            customer5.City = "Porsgrunn";

            //KENDİ OLUŞTURDUĞUMUZ CONSTRUCTOR YANİ DEFAULT OLMAYAN YANİ KENDİMİZ PARAMETRE VEREREK OLUŞTURDUĞUMUZ CONSTRUCTOR
            // Eleman ekleme nin başka bir yöntemi de kendimiz constructor ı ön tarafta oluştururuz ve constructor a eklemek istedğimiz özellikleri parametre olarak da veririz
            Customer customer3 = new Customer(15, "Adem", "Erbas", "Skien");                                   //çalıştırmış oluruz ki zaten o da bir default method gibi çalışır ondan dolayı
            Console.WriteLine("customer3Firstname"+customer3.FirstName);                                                                                                   //biz aynı method çalıştırır gibi çalıştırıyoruz.
                                                                                                                                                                           //Şu kısım çok önemli biz bir class ı new ledğimiz zaman aslında Constructor ı çalıştırıyoruz
            Customer customer6 = new Customer(14,"Ramazan", "Sarı","Barcelona");                                                                                                   //Constructor da bir method gibi çalıştığından dolayı biz bir class ı new lerken Customer
                                                                                                                                                                                   //customer=new Customer() şekllinde bir methodu  çalıştırırken ki parantez
            string nameLastname = customer6.GetFirstNameLastName();                                                                                                       //koyduğumuz gibi bunu da bu şekilde yazarak instance oluştururuz
                                                                                                                                                                          //Biz kendimiz class ımızın içine constructor oluşturmasak bile o her zaman biz class ımız
            Console.WriteLine(nameLastname);                                                                                                       //newlediğimizde arka planda çalışacaktır biz ön planda kendimiz yazarsak da bizim yazdığımız
                                                                                                                                                   //constructor çalışacaktır
            Customer customer7 = new Customer(35, 45);                                                                                                    //Customer id sini newliyoruz yani ondan bir instance yani obje veya nesne oluşturmuş oluyoruz
            int getNumbers = customer7.GetNumbers();                                                                                                               //Kendimiz ön tarafta constructor yazarsak eğer o zaman arka tarafta default olarak oluşan constructor ı ezmiş oluruz

            Console.WriteLine("Numaraları Al=    "+getNumbers);

            Customer customer8 = new Customer("Kemaletting", 68);
            string getFirstNameNumber1 = customer8.GetFirstNameNumber1();
            Console.WriteLine("GetFirstNameNumber1=   " + getFirstNameNumber1);
            
            
            
            NewMethod(6, "Serhat", "Kaya", "Drammen"); //Eğer methodu kodlarımızı çalıştırdığımız ana class olan Program cs clasında
                                                       //oluştursak o zaman static ile olşturmalıyız o methodu çalıştırabilmek için tüm
                                                       //methodlarımızı çalıştrıdığımız Main methodunun dışında bir method oluştururuz
                                                       //ve onu da yine çalışması için Main methoduna çalıştırırız

            Constructor2 constructor2 = new Constructor2("Adem","Erbas");
            Constructor2 constructor21 = new Constructor2(5, 6, 7);
            Constructor2 constructor22 = new Constructor2();

        }

       

        static void NewMethod(int id, string firstName, string lastName, string city) {

        
        }
    }
    //Yeni bir class oluşturulurken ana class ın Program adlı klasın dışına oluşturulur ve bizim kodlarımızı çalıştırdığımız yer ise
    //Main adlı methodun içerisinde koldlarımızı çalıştırırız
    class Customer
    { //Class lar, property ler, Constructorlar ve methodlar Pascal case yontemi ile yazilmalidir yani basharfleri buyuk olmalidir

        //CONSTRUCTOR OLUŞTURURKEN public ve o class ın adını büyük harfle yazarız sanki bir method yazargibi
        //oluştururuz sadece void ya da herhangi bir şey olmayacak
        //Biz kendimiz constructor ı oluşturur ve yeni parametreler atarsak o zaman arkada çalışan default halini ezmiş oluruz
        //OVERLOADING
        //Peki hem default halini hemde kendimiz bu tarafta parametre vererek oluşturdğumuzz
            //constructor ın çalışması için ne yaparız overloading yapıyoruz
        //DEFAULT CONSTRUCTOR    
        public Customer() { 
       
        
        }//Burası deault constructor olduğu için yukarda customer1 ve customer2 değişkenlerine parametre
                                 //vermediğimiz için customer1 ve customer2 de bu constructor yani default halinde parametre
                                 //verilmeden oluşturulmuş constructor çalıştı
        //Biz bu constructor ı da oluşturunca o zaman yukarda Main methodu içerisinde elemena eklediğimiz
                                 //hem default haline göre eleman eklediğimiz hemde bizim burda parametre vererek oluşturduğumuz constructor çalışmış olacaktır
      
        //Default OLmayan Constructor
        public Customer(int number1, int number2)
        {
            this.Number1 = number1;//Biz bu Number1 ve Number2 ye this ile ulaşma sebebimiz en altta property olarak
                                   //belirttiğimzden dolayı yoksa doğrudan this ile değişken üretemeyiz bu this ile
                                   //doğrudan değişken üretme işini python da yapabiliyorduk orda da bu şekidle oluyor
            this.Number2 = number2;//Doğrudan Number2 diye de yazabilirdik
        }

        public int GetNumbers()
        {
            return this.Number1 + this.Number2;
        }
        
        //DEFAULT OLMAYAN CONSTRUCTOR
        public Customer(int id, string firstName, string lastName, string city)//Buraya da parametre verdiğimiz için yukarda customer3 de de burası çalışacaktır
        {
            Console.WriteLine("Yapıcı blok çalıştı");
            //biz burda eğer parametreleri altta verdiğimiz propertilere atamazsak o zaman bu constructor methodu çalıştırılarak
            //oluşturulan obje veya nesne ya da instance elerimizde biz parametreye atadığımız değerleri alamayız çünkü dikkat edelim
            //biz propertiesleri Customer class ının içine yazıyoruz ama customer constructor larını propertilerin dışında oluşturuyoruz
            //ve dikkat edleim biz yukarda bu class üzerinden new leme yapınca burdaki constructorlar çalışıyor bizim new leme olayında
            //paramtre verirsek burda parametre vererek oluşturdğumuz constructor çalışır new leme de parametre vermezsek de parametre
            //vermeden olşturduğumuz default constructor çalışacaktır
            Id = id;//Bu tanımlama ile this.Id=id aynı şeydir
            FirstName = firstName;
            LastName = lastName;
             City = city;

            

        }

        public Customer(string firstName, int number1)
        {
            this.FirstName = firstName; //Biz
            this.Number1 = number1;
           

        }

       public string GetFirstNameNumber1()
        {
            return this.FirstName + this.Number1;
        }

        public string GetFirstNameLastName()//Burda şuna dikkat edelim biz yukardaki constructor da özelliklerimize parametredeki
                                            //değerleri atadığımız zaman biz Customer class ı içerisinde yazacağımız tüm
                                            //methodlarda artık this. aracılığı ile o değişkenleri kullanabiliriz
        {
            return this.FirstName + this.LastName;
        }//Biz yazdığımız methodlarda this ile ulaşmak istiyorsak propert olarak tanımlamalıyız bu pyhtonda bu şekilde
         //değil doğrudan this(self) ile tanımlanabiliyor
        //
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }

       
    }
}
//Biz constructor ları özellikle bir sınıfı new lediğimizde çalışmasının istdediğimiz kodlar varsa oraya koyarız bunu unutmayalım
//Yazdığımız class türü property barındıran Customer adında Entities yani varlıklar ın olduğu class türüdür
//Birde operasyon yapan class türleri vardır.Yani ekleme,silme,kaydetme,güncelleme,filtreleme gibi işlemler yapan operasyon yapan class larda constructor kullanabiliyoruz
//