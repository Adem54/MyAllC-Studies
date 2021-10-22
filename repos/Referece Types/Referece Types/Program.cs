using System;

namespace Referece_Types
{
    class Program
    {
        static void Main(string[] args)
        {
          
            int sayi1 = 10;
            int sayi2 = 20;
            sayi1 = sayi2;
            sayi2 = 100;
            Console.WriteLine("sayi1= "+sayi1 );

            int[] sayilar1 = new int[] { 1, 2, 3 };
            int[] sayilar2 = new int[] { 10, 20, 30 };
            sayilar1 = sayilar2;//sayilar1 değişkenine sayilar2 değişkeninin sahip olduğu adres atanıyor burda. Referans tiplerde değer
                                //atama diye birşey yoktur adres atama diye birşey vardır bunu unutmayalım
                                //Değer değil adres vardır bunu unutmayalım adres tutar
                                //sayilar1 e sayilar2 nin adresini atadıktan sonra sayilar1 in eski dizi değerleri boşta kalacağı için
                                //garbage collector tarafından belli bir süre sonra silinecektir
            sayilar2[2] = 1000;
            Console.WriteLine(sayilar1[2]);

            //arrays, classes, interface ler referans tiplerdir

            //Stack(referans tiplerin sadece degisken adini burda tutar ama deger tiplerin degisken adi ve karisindaki degerini de burada tutuyor
            //- Heap(referance tipler icin adres olusturur burda)
            //Her new deyip yeni bir obje,nesne veya dizi olusturdugunuz zaman istersek elemanlari ayni olan 2 tane dizi
            //olusturalim bu iki dizinin adresleri birbirinden farkli olacaktir ve bu iki dizi birbirine esit diyemeyiz 

            string[] cities1=new string[] {"Oslo", "Stavenger","Skien"};
            string[] cities2=new string[] {"Oslo", "Stavenger","Skien"};
            if (cities1==cities2)
            {
                Console.WriteLine("cities1 dizisi cities2 dizisine eşittir");
            }
            else
            {
                Console.WriteLine("cities1 dizisi cities2 dizisine eşit değildir");
            }
            //Bu iki dizi birbirine eşit değildir
            //

            Person person1 = new Person();
            Person person2 = new Person();
            person1.FirstName = "Engin";
            person2.FirstName = "Mehmet";

            person1 = person2;//Person2 nin adresini Person1 e atamış oluyoruz yani biz burda değer
                              //eşitlemesi değil adres eşitlemesi yapıyoruz bunu unutmayalım
            person2.FirstName = "Kemal";

            Console.WriteLine("Person1FirstName= " +person1.FirstName);
            person1.FirstName = "Serhat";
            Console.WriteLine("Person2.FirstName= " + person2.FirstName);
            Customer customer = new Customer();
            Employee employee = new Employee();
            //Farklı class lardan oluşturduğumuz nesne ve objeleri birbirlerine atayamayız bunlar farklı tiplerdir
            //çünkü aynen integer ı string e atayamayacağımız gibi yani customer ile employee yi birbirne atayamayız
            //ama aynı class tan oluşturacağımız farklı isimdeki nesneleri birbirine atayabiliriz örneğin Customer
            //class ından  customer1 ve customer2 yi oluşturursak bunları birbirine atayabiliriz 
            //Bu arada farklı class lardan oluşturduğumuz objeleri birbirine atayamayız normalde ancak istisna olarak eğer
            //bir class ı biz başka bir class a inheritance almışsak işte o zaman o inheritance olarak alınan class tan oluşturulan bir
            //nesneyi atadığımız değişken e inheritance olarak alan class tan oluşturulan obje değişkeni atanabilir
            //Yani Person class ı Customer class ına inheritance olarak alındı ve Person clas ından oluşturulan bir nesne
            //değişkenine Customer classından oluşturulan bir obje değişkeni atanabilir çünkü Person class ının tüm özelliklerine
            //Customer class ı ulaşabiliyor Customer class ı Person class ını inheritance yaptığı için ancak tam tersini yapamayız
            //yani Customer classından oluşturulmuş bir nesne değişkenine tutup da Person classından oluşturulmuş bir değişken atayamayız!!!!!
            //Base class lara(inheritance alınan Person gibi) referans alan class lardan oluşturulan değişken lerin referansını
            //yani adresini atayabiliriz. Person class ini Customer class inin altinda bir class gibi düşünebiiriz
            //yani Person class ından oluşan bir değişkene Customer classından oluşturulmuş bir nesne değişkeni atayabiliriz
            //ama customer classında oluşturulmuş bir değişkene Person class ından oluşturulmuş bir değişken atayamayız
            Person person3 = new Person();
            person3 = customer;
            Person person4 = employee;
            Customer customer8 = new Customer();
            //customer8 = person3; Bu yanlış bunu atayamayız

            Customer customer1 = new Customer();
           
            customer.LastName = "Selim";
            Console.WriteLine("person3LastName "+person3.LastName);

            //Normalde Person class ı base class dır yani inheritance alınmış bir class dır bundan dolayı
            //biz noramlde Customer class ı Person class ını inheritaance aldı dolayısı ile artık Customer classından
            //olşturulan herhangi bir nesne üzerinden biz Person class ı içerisinddeki tüm method,fonksiyolaara
            //ve değişkenlere ulaşabiliriz. Ancak biz Person class ı üzerinden oluşturulmuş bir nesne değişkeni
            //üzerinden Customer içinde oluşturulmuş method ve functions lara ulaşamıyoruz normalde ama biz Person
            //class ından oluşturulmuş bir değişkene onu inheritance alan class ı boxing yaparak o class ın içindeki
            //methodlara da erişebiliirz
            customer.CreditCartNumber = 123456789;
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!111
            //BOXING METHODU İLE KENDİSNİ BASE CLASS TAN ONU INHERITANCE ALAN CLASS METHODLARINA ULAŞMA
            //Kendisini inheritance alan classın methodlarına boxing ile ulaşma
            //Burda Customer int gibi, string gibi bir tiptir class tipidir
            //Bu çok önemlidir çünkü biz PersonManager adlı class oluşturduğumuz zaman kişilerle ilgili operasyonel
            //işlemleri yürütmek için yazdığımız class içerisinde parametreye biz Customer veya Employeer verirsek
            //o zaman sadece onların verileri ile ilgili çalışabiliriz ancak eğer biz Person class ını parametreye verirsek
            //işte o zaman Person ı inheritance almış Employee ve Customer class nın metholdarına da Person class ı üzerinden(boxing ile)
            //ulaştığımız için aslında bir işle bir çok işi halletmiş oluyoruz class larla ve inheritance ve boxin g yöntemi ile
            //Ayrıca özellikle operasyonel class larda biz parametre olarak genellikle varlıklar, entities şeklinde
            //class ları class ın Adı ve yanına o class tan oluşturacağiımız bir nesne adını yazarız ki ordaki mantık
            //şudur C# ta parametreler tipleri ile birlikte yazılır işte bizim yazacağımız değişkenin de tipi class olduğuu
            //için Person person şeklinde yazarız
            //Bir de şu konuya dikkat edilmeli, burda Employee ve Customer class ları oluşturulmakla beraber her iki Class
            //içinde ortak olacak özellikler ise Person adı verilen ayrı bir class ta oluşturulmuştur işte bu çok önemlli bir
            //prensiptir class larla çlaışırken mümkün olduğunca her class bir iş yapsın SOLID prensiplerinden single responsibility
            //ilk prensip ona göre

         
            Console.WriteLine(((Customer)person3).CreditCartNumber);


            // GÖRÜLDÜĞÜ ÜZERE BİZ CLASS IMIZIN İÇERİSİNDE DİĞER TÜM CLASS LARI KULLANABİLDİK BURASI ÇOK HAYATİ
            //Verilerini kullanmak istediğimiz Employee ve Customer classlarının ın ortak özellikleri olan bir Person
            //class ını bu iki class için Base class yani onların inheritancesi yapıyoruz ve biz PersonManager class ı ile
            //bir kişi üzerinde operasyonlar yapmak istiyoruz ama o class ta hangi tür kişi olursa olsun ya da sonradan projeye
            //eklenebilecek farklı tür isimler için de sistemimi hazır tutmak için de PersonManager class içerisine yazdğımız
            //Add adlı method a parametre olarak biz Person veririz Employee veya Customer yerine çünkü Person veridğimiz zaman
            //biz hem Customer hem de Employeeye boxing yöntemi ile ulaşabilidiğimiz gibi sonradan projeye eklenebilecek farklı
            //kişi türü class ları için hazır bir sistem kurmuş oluruz çünkü Person class ı eklenebilecek tüm kişilerde olması gereken zorunlu
            //ortak özellikleri barındırıyor olacak
            //BİZE AYNI KODU FARKLI NESNELER İÇİN ÇALIŞTIRABİLMEMİZİ SAĞLIYOR
            PersonManager personManager = new PersonManager();
            personManager.Add(person1);
            personManager.Add(customer1);
            personManager.Add(employee);

            //Nasıl customer gönderebildik aşağıda Add methodu normalde Person yazdık ama parametreye hem customer hem de
            //employee yazabiliyoruz çünkü Person bu iki class ın da inheritance aldığı yani base class ıdır burda yaptığımız
            //şey aslında person classında oluşturduğumuz bir nesne değişkenine biz Employee classından oluşturulmuş olan bir
            //nesne veya Customer classından oluşturlmuş olan bir obje atayabilimemiz ile burada Person atanan bir parametreye
            //aynı zamanda Employee ve Customer da atayabilmemiz aynı şeydir
            //Biz PersonManager classında Add methoduna Person person class ını adres olarak verince aslında biz Person adresini yani referansını vermiş oluyoruz dolayısı ile de 







        }
    }
}

class Person //Biz property oluşturacağımız elemanlarımızda öncelikle tüm entities lerde ortak olacak bir class belirleriz ki sonradan eklenecek
             //yeni entities lerde biz direk projeye dahil edebilelim
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

//Base class Person dır.
class Customer : Person
{//Customer ayni zamanda bir Person dir burda Person class ının inheritancesini alıyor
 //Customer bundan dolayı biz artık Customer classından oluşturacağımız bir obje veya nesne
 //üzerinden Person içinde oluşturulmuş olan method veya fonksiyonlara ulaşabiliriz
    public int CreditCartNumber { get; set; }
}

class Employee : Person //Employee de ayni zamanda bir person dir burda da inheritance yapiyoruz ve
                        //dolayısı ile artık biz Employee class ı ile oluşturdğumuz herhangi bir obje
                        //veya nesne üzerinden Person classsının method veya fonksiyonlarına erişebiliriz
{
    public int EmployeeNumber { get; set; }
}

class PersonManager
{
    public void Add(Person person)//Parametreye Customer gönderirsek sadece Customer üzerindeen işlem  yaparız ,
                     //buraya Employee class ını verirsek sadece Employee ile ilgili işlem yaparız
                     //ama biz Person class ını hem Customer a hem de Employee classında inheritance
                     //olarak alır daha sonra da Person class ından boxing methodu ile hem Customer
                     //hem de Employee class ının methodlarna ulaşırsam o zaman işte ben burda parametreye Person
                     //vererek aynı anda istediğimiz kadar farklı class la veya sonradan karşımıza çıkacak
                     //senaryolarda da rahatça ayak uyduarabiliriz
    {
       Console.WriteLine(((Employee)person).EmployeeNumber);
        //Boxing=> ((Employee)person) biz Person classı tipindeki person değişkeninin arkasına onu inherit alan claass lardan birini bu şekilde yaptıktan
        //sonra . dersek o zaman onu inherite alan class ın methodlarına ulaşabiliyoruz
        //((Employee)person).EmployeeNumber
    }
}