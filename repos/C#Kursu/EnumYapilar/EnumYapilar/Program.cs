using System;

namespace EnumYapilar
{
    enum Gun { Pazartesi = 1, Salı = 2, Carsamba = 3, Persembe = 4, Cuma = 5, Cumartesi = 6, Pazar = 7 };
    enum GecmeDurumu { Basarisiz = 0, Gecer = 45, Orta = 60, Iyi = 70, Pekiyi = 80 }
    class Program
    {
        static void Main(string[] args)
        {
            int secilenGun = (int)Gun.Carsamba;

            if (secilenGun == (int)Gun.Cumartesi || secilenGun == (int)Gun.Pazar)
            {
                Console.WriteLine("Hafta sonu seçtiniz.");
            }
            else
            {
                Console.WriteLine("Hafta içi seçtiniz.");
            }


            //Not durumu


            int ogrenci_not = 70;
            GecmeDurumu gd = (GecmeDurumu)ogrenci_not;
           Console.WriteLine(gd.ToString());



            Console.WriteLine("Hello World!");

            Person person = new Person();
            Schools school = Schools.PrimarySchool;



            if (person.school.Equals(Schools.University))
            {
                Console.WriteLine("University");
            }
            else
            {
                Console.WriteLine(school);
            }

        }
    }

    //Enumlar biz string bir degiskeni sayilarla iliskilendirerek kodumuzu daha okunabilir olmasini saglayan ve hata yapmamizi 
    //minimize eden yapilardir
    //Enumlar sayilari anlamli bir sekilde isimlendirerek bizim kullanmamizi sagliyor
    enum Schools
    {
        PrimarySchool=1,HighSchool=2,University=3//Bunlar varsayilan degerlerdir ve baslangic degeri 0 dan baslar 
            //Yani PrimarySchool 0,HighSchool 1, University 2 dir
            //Eger istersek biz de deger atayabiliriz..Mesela biz default olarak baslangic elemani olan PrimarySchool a bir deger
            //atarsak bir int degeri atarsak digerleri de ardisik olarak gelecektir ama istersek de her birisine ayri ayri deger
            //de atayabiliriz...
    }

     class Person
    {
        

        public Person()
        {
            school = Schools.HighSchool;
           
        }

        public Schools school; 
            }
}


//Farklı türlerde enum tanımlama
//       Enum içerisine farklı türlerde de atama yapabiliriz.

//Enumler kendileri bir tipdir yani Enum tipindedir ama icndeki varsayilan degerler int dir

//enum Sonuç : byte { Kaldi, Gecti };
//Enum kullanırken bilinmesi gerekenler
//Enum içerisinde değer vermezsek, değerler 0’dan başlar ve birer birer artar.
//Enum’ların varsayılan değer “int”dir.
//Enumları; byte,sbyte, short,ushort, int, uint,long, ulong türlerin oluşturabiliriz.
//Enum içerisine verdiğimiz değerlerde, değişken isimlendirmede dikkat edilen kurallar geçerlidir. 
//Örneğin sayı ile başlayan veya içerisinde boşluk bulunan isimlendirmeler veremeyiz.