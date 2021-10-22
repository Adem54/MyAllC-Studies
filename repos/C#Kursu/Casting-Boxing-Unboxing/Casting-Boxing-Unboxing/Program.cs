using System;

namespace Casting_Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            byte sayi1 = 244;
            int sayi2 = sayi1;//byte en kucuk sayisal degerleri atayabildigimiz bir degisken turu old ve int e gore daha
            //az sayisal degere hitap ettigi icin byte in aldigi tum degerleri int alabilir ama int in aldigi tum degerleri
            //byte alamaz ondan dolayi biz byte ile tanimlana bir degiskene int ile tanimlanan degiskene atadgimiz zaman
            //C# onun disardsa deger birakmamasi icin bizi koruyarak casting yapmamizi istiyor...
            //Ama tam tersi durumda herhangi bir sknti yasanmiyor yani int ile tanimlanan bir degere byte ile tanimlanan bir
            //degeri rahatlikla atyaabiliriz
            Console.WriteLine("sayi2:  " + sayi2);
            sayi2 = 566;
            sayi1 = (byte)sayi2;//Explicit Casting ile parantez operatoru icersine tur donusumu yapacagimiz turu yazariz...


            //Implicit-Explicist
            //C#’ta bilinçli ve bilinçsiz olmak üzere iki tür veri dönüşümü söz konusudur. 
            //    Bilinçsiz olarak yapılan tür dönüşümü Implicit Conversion şeklinde tarif edilirken,
            //    bilinçli dönüşüme ise Explicit Conversion diye nitelendirilmektedir. Hatta biliyorsunuz ki, 
            //    Implicit Conversion’da herhangi bir operatör yahut ek bir syntax kullanmazken, 
            //    Explicist Conversion’da “()” – Cast operatörü kullanılmaktadır.

            sayi2 = sayi1;//Casting

            Console.WriteLine("sayi1="+sayi1);

            //Impicit(dahili,dolayli,ustu kapali,imali)
            //region Implicit Conversion-Bilincsiz olarak yapilan tur donusumu
            int x = 135;
            long y = x;

            //Explicit Conversation-Explicit(direk,acikca)
            long a = 1000;
            int b = (int)a;

            //BOXING DEDIGIMIZ OLAY DA ASLINDA BIR EXPLICIT CASTING ISLEMIDIR HEMEN ASAGIDA CLASS LAR ARASINDA
            //BU DURUMU INCELEYELIM.....
            //Canli class imiz bir base class tir ve Insan classi tarafindan inherit edilmistir...
            //Biz Canli klassindan olusturdugumuz bir degiskene onu inherit eden tum class lardan olusan instanceleri
            //atayabiliriz...O hepsinin referansini tutar.Ayni zamanda Base class i inherit eden class lar icerisinde
            //kendilerine has operasyonlar veya properties ler olabilir normalde buna base class erisemez daha dogrusu
            //biz base class intstancemizden onlara erisemeyiz ama Explict casting ile yani boxing ile ona da erisebiliriz..

            Canli canli1 = new Canli();
            Canli canli2 = new Insan();
            Insan insan = new Insan();

            //Normalde beklenen insan nesnesinden hem kendi propertiesi hem de inherit ettigi Canli class indaki 
            //properties e ulasmasi bekleniyor...
            string name=insan.Name;
            int number2 = insan.Number;
            //BOXING-EXPLICIT CASTING
            int number = ((Insan)canli1).Number;

            //BURAYA COK DIKKAT!!!
            //“Aralarında kalıtımsal ilişki olmayan sınıflar arasında her iki dönüşümde yaptığımız işlemleri yapmaya
            //çalışırsak ne olur?”
            //            Eğer ki aralarında ilişki olmayan sınıflar arasında Implicit ve Explicit Conversion yapmak 
            //                istiyorsanız bu sınıfların dönüşüm antlaşmalarını oluşturmanız gerekecektir.Yani demek 
            //                istediğim custom(özel) conversion tanımlamanız gerekecektir.Yani daha da açıklayıcı konuşmamız 
            //                gerekirse Implicit ve Explicit operatörlerinin aşırı yüklenmesinden bahsediyorum.

            //Eğer ki aralarında ilişki olmayan sınıfların Implicit Conversion yapmasını istiyorsak eğer implicit
            //            keywordünü(implicit operator), yok eğer Explicit Conversion yapmasını istiyorsakta explicit 
            //            keywordünü(explicit operator) kullanarak birazdan teknik olarak ele alacağımız şekilde çalışma
            //            yapmamız gerekecektir.

            //Asagidaki ornekleri inceleyecek olursak eger 
            //Koordinat sınıfını Lokasyon’a implicit çevirdikten sonraki kulllanimimiz
            //Lokasyon l = new Koordinat();

            //Koordinat sınıfını Lokasyon’a explicit çevirdikten sonraki kullanimimiz
            Lokasyon l = (Lokasyon)new Koordinat();

            //Lokasyon sınıfını hem Koorinat’a hem de double tipine implicit çevirdikten sonraki kullanimimiz
            //Koordinat k = new Lokasyon();
            //double i = new Lokasyon();

            //Lokasyon sınıfını hem Koorinat’a hem de double tipine explicit çevir
            Koordinat k = (Koordinat)new Lokasyon();
            double i = (double)new Lokasyon();

            //Bunlarin haricinde biz Koordinat ve Lokasyon siniflarini sırasıyla double ve bool türlerine implicit
            //ve explicit çevirebiliriz ve asagidaki gibi de kullanabiliriz.
            //Implicit
            //double d = new Koordinat();
            //bool b = new Lokasyon();
            //Explicit
            //double d = (double)new Koordinat();
            //bool b = (bool)new Lokasyon();

            //Bunun dışında implicit ve explicit metotlar struct yapıları içinde geçerlidir.

            MyStruct2 m1 = new MyStruct();
            MyClass m2 = (MyClass)new MyStruct();
            int p = (int)new MyStruct();
            MyStruct m3 = (MyStruct)3;
        }
    }

    //KAYNKAK:https://www.gencayyildiz.com/blog/cta-implicit-ve-explicit-operatorlerinin-asiri-yuklenmesi/

    struct MyStruct
    {
        public static implicit operator MyStruct2(MyStruct m)
        {
            return new MyStruct();
        }
        public static explicit operator MyClass(MyStruct m)
        {
            return new MyClass();
        }
        public static implicit operator int(MyStruct m)
        {
            return 0;
        }
        public static explicit operator MyStruct(int p)
        {
            return new MyStruct();
        }
    }
    struct MyStruct2 { }
    class MyClass { }

    //Koordinat ve Lokasyon sınıflarını sırasıyla double ve bool türlerine implicit çevir
    //class Koordinat
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    public static implicit operator double(Koordinat k)
    //    {
    //        return k.X * k.Y;
    //    }
    //}

    //class Lokasyon
    //{
    //    public double X { get; set; }
    //    public double Y { get; set; }
    //    public static implicit operator bool(Lokasyon l)
    //    {
    //        return true;
    //    }
    //}


    //Koordinat ve Lokasyon sınıflarını sırasıyla double ve bool türlerine explicit çevir
    //class Koordinat
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    public static explicit operator double(Koordinat k)
    //    {
    //        return k.X * k.Y;
    //    }
    //}

    //class Lokasyon
    //{
    //    public double X { get; set; }
    //    public double Y { get; set; }
    //    public static explicit operator bool(Lokasyon l)
    //    {
    //        return true;
    //    }
    //}



    //class Koordinat
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //}

    //class Lokasyon
    //{
    //    public double X { get; set; }
    //    public double Y { get; set; }
    //}





    //Koordinat sınıfını Lokasyon’a implicit çevir,
    //class Koordinat
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    public static implicit operator Lokasyon(Koordinat k)
    //    {
    //        return new Lokasyon { X = k.X, Y = k.Y };
    //    }
    //}

    //Koordinat sınıfını Lokasyon’a explicit çevir,
    class Koordinat
    {
        public int X { get; set; }
        public int Y { get; set; }
        public static explicit operator Lokasyon(Koordinat k)
        {
            return new Lokasyon { X = k.X, Y = k.Y };
        }
    }

    //  Lokasyon sınıfını hem Koorinat’a hem de double tipine implicit çevir,

    //class Lokasyon
    //{
    //    public double X { get; set; }
    //    public double Y { get; set; }
    //    public static implicit operator Koordinat(Lokasyon l)
    //    {
    //        return new Koordinat { X = (int)l.X, Y = (int)l.Y };
    //    }
    //    public static implicit operator double(Lokasyon l)
    //    {
    //        return l.X;
    //    }
    //}

    //Lokasyon sınıfını hem Koorinat’a hem de double tipine explicit çevir


    class Lokasyon
    {
        public double X { get; set; }
        public double Y { get; set; }
        public static explicit operator Koordinat(Lokasyon l)
        {
            return new Koordinat { X = (int)l.X, Y = (int)l.Y };
        }
        public static explicit operator double(Lokasyon l)
        {
            return l.X;
        }
    }

    public class Canli {
        public string Name { get; set; }

    }
    public class Insan:Canli
    {
        public int Number { get; set; }
    }
}
