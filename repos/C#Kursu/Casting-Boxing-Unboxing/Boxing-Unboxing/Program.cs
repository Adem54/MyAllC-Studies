using System;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Not : Net Framework’te value type ve referance type olmak üzere iki tür veri tipi vardır.
            //Değer tipleri (Value type) stack (Yığın)’da Referans tipleri (Reference type) ise
            //Heap (Öbek)’de tutulmaktadır. Referans tipleri : Dynamic, Delegate, Interface, Strings, Object, Class.
            //Value tipleri ise ; int , float , double,char vb. tiplerdir.

            //BOXING

            //  Boxing bir değer tipinin(value type) object yada herhangi bir interface tipine dolaylı(implicit)
            //  olarak dönüştürülme işlemi olarak tanımlanabilir.
            //Örnek bir değer tipinde(value type) değişken tanımı :

            int i = 123;
            //Aşağıdaki atama ifadesine baktığımızda i değişkenine dolaylı(implicitly) olarak boxing işlemi uygulanmaktadır.
               object o = i;
            // Boxing yaparak i değişkeninin değeri o değişkenine kopyalanıyor.
            //Böyle bir boxing işleminden sonra stack(yığın) üzerinde oluşturulan object türünden o değişkenine, 
            //    stack (yığın)’da bulunan i değişkeninin kopyası heap(öbek)’te oluşturulup o değişkenine referans 
            //    eder hale gelmiştir.


            // i değişkeninin değerini değiştiriyoruz.
            i = 456;


            // i değişkenin değerinin değiştirilmesi,
            // o değişkeninde tutulan değişkenin değerini etkilemeyecektir

            //UNBOXING-EXPLICIT-CASTING

            // Unboxing object tipinin direk(explicit) olarak değer tipine(value type) yada interface tipinden
            //bu interface implement eden tiplere dönüştürülme işlemi olarak tanımlanabilir.
            int i1 = 123;      // değer tipi (value type)
            object o1 = i1;     // boxing
            int j = (int)o1;   // unboxing

            //Boxing ve Unboxing Performans

//  Boxing işlemi normal bir atama işleminden 20 kat daha uzun sürmektedir.
//Unboxing işlemi ise yine normal bir atama işleminden 4 kat daha uzun sürmektedir.
//Bu yüzden gerekli olmayan aşırı boxing ve unboxing kullanımı uygulamanızı gözle görülür bir biçimde yavaşlatacaktır.

        }

    }
}
