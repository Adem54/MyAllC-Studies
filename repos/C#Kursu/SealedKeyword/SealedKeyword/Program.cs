using System;

namespace SealedKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //sealed Keyword’ü Nedir? Ne İşe Yarar
            //sealed keywordü bir class ve metod modifier(niteleyici)dır.
            //Eğer bir class sealed komutuyla işaretlenmişse o classtan kalıtım yapılamaz.
            //Yani o class başka bir sınıfın base classı olamaz. Ayriyetten bir metod sealed
            //komutuyla işaretleniyorsa o metodtan türetilen sınıfların ilgili metodu override etmeleri önlenir.

            // Şimdi gelin sırasıyla bu durumları inceleyelim.

            //Öncelikle sealed komutuyla bir sınıfı işaretleyelim.
            //Gördüğünüz gibi sealed komutu sınıflarda kalıtımı engelleyen bir özelliğe sahiptir.



            //Şimdide sealed komutunu metod üzerinde inceleyelim.
            //gördüğünüz örnek sınıflardan MyClass1 içerisinde “X” ve “Y” virtual metodları mevcuttur.
            //Bu sınıf MyClass2 tarafından miras alınarak içerisinde metodlar override edilmiştir.
            //Ayriyetten MyClass3’te MyClass2’yi miras alarak MyClass2’de MyClass1’den ezilmiş olan memberları
            //tekrardan ezmiştir.

            //  İşte böyle bir durumda MyClass2 içerisinde override edilmiş metodları sealed ile işaretleyebiliyor
            //  ve bu sınıftan miras alan diğer sınıflarda bu metodların override edilmesini engelleyebiliyoruz.
            //gördüğünüz gibi MyClass2 içerisinde override edilmiş “Y” metodunu sealed ile işaretleyerek ilgili sınıftan
            //kalıtım alan MyClass3 içerisinde “Y” metodunun override edilmesine mani olmuş olduk. Gördüğünüz
            //gibi “Y” metodu override yazınca gelmemektedir.
            //Ayriyetten bilmenizde fayda vardır ki, mikro seviyede yapılan bir optimizasyonla anlaşıldığı kadarıyla
            //C#’ta bir sınıf sealed ile işaretlendiğinde sealed olmayan bir sınıfa göre ufak çapta bir performans
            //artışı gösterdiği tespit edilmiştir.
        }
    }

    class MyNewClass1: MyNewClass2//Gördüğünüz gibi sealed komutu sınıflarda kalıtımı engelleyen bir özelliğe sahiptir.
    { }

    sealed class MyNewClass2
    {

    }

    class MyClass1
    {
        public virtual void X()
        {
            Console.WriteLine("xxxxx");
        }

        public virtual void Y(string yparam)
        {
            Console.WriteLine(yparam);
        }
    }

    class MyClass2 : MyClass1
    {
        public override void X()
        {
            Console.WriteLine("XXXXX");
        }

       sealed public override void Y(string yparam)
        {
            Console.WriteLine("yyyyyyy" + yparam);
        }
    }

    class MyClass3 : MyClass2
    {
        public override void X()
        {
            Console.WriteLine("XxXxX");
        }


        override  
    }
}
