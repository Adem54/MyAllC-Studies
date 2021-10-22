using System;

namespace StructYapilar
{
    class Program
    {
        static void Main(string[] args)
        {
            //C#’ta Struct Yapıları ve Kullanım Durumları
            //Programlama dillerinde en mühim OOP(Object Oriented Programing) yapılarından olan class
            //yapısına göre daha basit düzeyde işlemler gerçekleştirmemizi sağlayan ve belirli bir
            //takım kısıtlamaları yanında barındıran struct yapısını C# diline özel ele alacağız.

            //Şimdi düşünün ki, bir yapı oluşturacaksınız ve bu yapı birbirleriyle ilişkili verileri barındıracaktır. 
            //    Haliyle bunu bir class olarak belirleyebilir ve o classtan üretilen nesne üzerinde işlemlerimizi 
            //icra edebiliriz.Amma velakin bu yapımız class kadar kompleks işlemler için tasarlanmış bir yapı
            //gerektirmiyorsa ve tutulacak verileri enkapsüle etmek yetiyorsa işte bu tarz durumlarda struct yapısını
            //tercih edebiliriz.

            //Unutmayınız ki, classlar bir Referans Tipli(Reference Types) özellik gösterirken struct yapıları bir
            //Değer Tipli(Value Types) değişken özelliği göstermektedir.
            //Yani anlayacağınız “int” gibi, “bool” gibi değer tipli bir değişken oluşturmak istiyorsanız
            //struct yapısını tercih edebilirsiniz.

            //Bu demek oluyor ki, gerçekleştireceğimiz işlevselliğin yapısal olarak bir nesne yahut değer tipli 
            //    bir değişken yapısında gerçekleştirilmesini tercih edebilir ve birazdan bahsedeceğim olumlu 
            //    olumsuz yanlarıda hesaba katarak projenizde performansı daha maliyetli bir hale getirebilirsiniz.

            //            Şimdi struct yapısını C# perspektifinden adım adım değerlendirelim;

            //Yazımızın yukarıdaki satırlarında da bahsettiğimiz gibi struct C#’ta value type yaratabileceğimiz yapıdır.
            //struct yapıları, herhangi bir struct yahut class’tan kalıtım alamazlar
            //Benzer şekilde bir class yapısıda struct yapısından miras alamamaktadır.
            //struct yapıları, interface yapılarını uygulayabilmektedirler=>Asagidaki ornegi incele

            //            struct yapılar new keywordüyle örneklendirilebilmektedir.Burada iki durum söz konusudur.
            //Eğer new operatörüyle örneklendirirsek ne olur?
            //Bildiğiniz gibi new operatörü classlarda kullanıldığı zaman ilgili classtan bir nesne talep edilmekte ve üretilen 
            //            nesne belleğin Heap kısmında muhafaza edilmektedir.Ee söz gelimi struct yapısında da new
            //            operatörünü kullanırsak eğer evet ilgili yapıdan bir nesne üretilecektir ama struct bir değer 
            //            tipli değişken yapısında olduğundan dolayı o nesne belleğin Stack kısmında muhafaza edilecektir.

            //Bu yapıya kadar oluşturduğumuz tüm nesnelerin Heap kısmında olduğunu söylemiştik. Halbuki Stack
            //kısmında struct yapısında nesneleri tutabilmekteyiz.

            //Ayriyetten struct içerisindeki fieldlara default değerleri atanmış olacaktır.

            MyStruct ms = new MyStruct();
            Console.WriteLine(("x= "+ms.x + " y= " + ms.y + "z= " + ms.z));//0 ve false gelir

            //Eğer new operatörü kullanmazsak ne olur?
            //Haliyle classlardaki gibi nesne mecburiyeti yoktur. Yani new operatörü ile struct yapıdan bir
            //nesne üretmeden de o struct’ı kullanabilmekteyiz.
            MyStruct2 myStruct2;
            myStruct2.x = 12;
            myStruct2.y = true;
            myStruct2.z = "Hello";
            Console.WriteLine(myStruct2.y+myStruct2.z+ myStruct2.x);
            // Yukarıda da gördüğünüz gibi nesnesiz structları kullanabilmekteyiz kullanmasına ama içerisindeki verilerin ilk değerleri atanmayacağından dolayı hata alınacaktır.
            //İşte böyle bir durumda ilk değerleri atayarak kullanmak gerekecektir.

            //Anlayacağınız class yapıları new keywordü ile belleğe fiziksel olarak çıkabilmekte ve kullanılabilmektedir.
            //Aksi taktirde belleğe çıkamamaktadırlar.Struct’larda ise new ile belleğe çıkma zorunluluğu yoktur
            //lakin içerisindeki elemanların ilk değerleri mecburi verilmek zorundadır.
            //struct yapılar içerilerinde metod, property veya field barındabilirler
            //Haliyle bu elemanlardan metodları kullanabilmek için struct değişkenine new operatörüyle bir nesne bağlama zorunluluğumuz yoktur.
            //Ama property yapılarını kullanabilmek için struct’tan bir nesneye ihtiyacımız vardır.

            MyStruct3 myStruct3 = new MyStruct3();
            myStruct3.x = 3;
            myStruct3.y = true;
            myStruct3.z = "3";
            Console.WriteLine(myStruct3.x + " " + myStruct3.y + " " + myStruct3.z + " " + myStruct3.Islem());

            //struct yapılar içlerinde static alanlar barındırabilirler
            //ve bu static yapılara normal bildiğiniz yapı ismi üzerinden .(nokta) diyerek ulaşabilmekteyiz.
            MyStruct4.Islem().ToString();
            //Ve son olarak struct yapılar içerisinde class, class içerisinde de struct yapılar tanımlanabilir.

            //Evet, gördüğünüz gibi struct dediğimiz aslen yapısal ve içerik(implicit) olarak bir sealed class‘tır
            //diyebiliriz. Bunun yanında daha hafif(lightweight) bir class yapısı olduğu söylenebilir.
            //İçeriğimizden de anlaşılacağına göre Tip Tanımlama(Type Definition) yaparken kullanabiliriz.

            // İçerikte bahsedildiği gibi referans değil, değer tipli bir yapı göstermesinin sebebini aşağıdaki
            // örnekten de anlayabiliriz.
            MyStruct5 myStruct5 = new MyStruct5();
            myStruct5.sayi1 = 5;
            myStruct5.sayi2 = 6;
            MyStruct5 myStruct6 = myStruct5;
            myStruct6.sayi1 = 12;
            myStruct6.sayi2 = 18;
            Console.WriteLine(" myStruct5.sayi1= " + myStruct5.sayi1 + " myStruct5.sayi2= " + myStruct5.sayi2 +
                " myStruct6.sayi1= " + myStruct6.sayi1 + " myStruct6.sayi1= " + myStruct6.sayi2);
            //Sonuc 5-6-12-18
            //Burada dikkat ederseniz eğer myStruct5.sayi1 ve myStruct5.sayi2 değişmeyeceğinden dolayı bir Deep Copy söz konusudur.
            //Eğer referans tipli yapılar olsalardı aşağıdaki gibi bir sonuç elde edilecekti ve Shallow Copy söz konusu olacaktı.
            //Sonuc 5-6-12-18
            //Sonuc 5-6-12-18

            //struct yapılar, kendilerini this keywordünü kullanarak değiştirebilen yapılardır.
        //    struct MyStruct6
        //{
        //    public int sayi1;
        //    public int sayi2;

        //    public void Yeni()
        //    {
        //        this = new MyStruct6();
        //    }
        //}
        //  Aslında bu tarz bir işleme class yapısı izin vermediğinden dolayı ilginç bir özelliktir.
    }



    }


    }

struct MyStruct6
{
    public int sayi1;
    public int sayi2;

    public void Yeni()
    {
        this = new MyStruct6();
    }
}
struct MyStruct5
{
    public int sayi1;
    public int sayi2;
}

struct MyStruct4
{
    public int x;

    static public double Islem()
    {
        return -1;
    }
}
struct MyStruct3
    {
        public int x;
        public bool y;
        public string z { get; set; }

        public double Islem()
        {
            if (y)
            {
                return x * int.Parse(z);
            }

            return -1;
        }
    }

    struct MyStruct1 : IInterface
    {
        int x;
        bool y;
        public void A()
        {
            throw new NotImplementedException();
        }
        public void B(bool c)
        {
            throw new NotImplementedException();
        }
    }

    interface IInterface
    {
        void A();
        void B(bool c);
    }


    struct MyStruct
    {
        public int x;
        public bool y;
        public string z;
    }
    struct MyStruct2
    {
        public int x;
        public bool y;
        public string z;
    }

