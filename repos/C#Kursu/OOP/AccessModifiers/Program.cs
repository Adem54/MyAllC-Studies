using System;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            House house = new House();

           
            
            Console.WriteLine("Hello World!");
            //Erisim bildirgecleri yazdiginiz bir field,property,method veya class i kullanma ile ilgilidir
            //Yani ona ulasabilmek ile ilgilidir...
            //Biz bir tane House adinda class olusturduk bu proje icinde ve basina hicbir access modifier koymadik
            //Ama hem su an icinde bulundgumuz class ta hem de asagidaki Customer class i icinde House yazinca 
            //kendisi otomatik gelirken ayni solution icersindeki diger projelerde House class i gozukmuyor..
            //INTERNAL
            //Bir class in defaultu internal dir bunu unutmayalimm.....!!!!!!!!!!!!!!!!!1
            //internal demek sadece ve sadece namespace AccessModifiers de gecerli demektir.
            //Yani namespace AccessModifiers demek de AccessModifiers projesi altinda ki tum class lardan erisilebilir demektir
            //Diger projerde biz su an ki projemiz olan AccessModifiers in icinde  internal olarak olusturdgumuz class lara
            //erisemeyiz.Pekii biz bu projemizdeki class larimiza diger projelerden de erismek istersek eger once
            //ornegin projemizdeki House class imiz diyelim public House class {} yaparsak eger, ornek olarak
            //AccessModifiersTest projesi icinde House class ini kullanmak istersek eger o zaman biz House yazinca hemen
            //bir tane ampul gelecektir ve orda Add Reference To AccesModifiers diye bir secenek gelecektir yani diyorki
            //AccessModifiers projesine bir referans birakayim mi diyor onun bir class ini  kullanacagim ona bir refrans
            //birakayimmi diyor, bunu o sekilde yapmanin yanin da birde AccessModifiersTest class ina saga tiklayarak
            //Add Reference deddikten sonra da gelip AccessModifiers secerek de yapabiliriz...Biz bunu yapinca artik
            //bu projemizde  public olarak belirledigimiz class larimizi gidip AccessModifiersTest projesinde kullanabiliriz
            //Ve biz bu projemizin referansini AccessModifiers a ekleyince zaten o projede using AccessModifiers;
            //en ustte using de bu sekilde bu proje ismi gelecektir
            //PUBLIC VE REFERANS OLARAK VERME!
            //Demekki biz baska projedeki basks isim uzayi,namespace altindaki bir class i kullanmak istiyorsak onu
            //referans olarak eklememiz gerekiyor.Az once yaptigimiz AccessModifierTest projesinde biz AccessModifier
            //projesinde olan bir class  i kullanmak istedik ve ne yaptik AccessModifiersTest e AccessModifiers projesini
            //namespacesini referans olarak ekledik....
            //Biz bir projede baska bir projeye ait bir class i kullanabilmemiz icin oncelikle kullanmak istedigimiz 
            //class in public olmasi gerekir ve sonra da biz projemizde baska bir projedeki class i kullanabilmek icin
            //projemize saga tiklariz Add deriz ve Add Project deriz sonra da hangi projeye ati bir class ise onu seceriz
            //Ve o projeyi referans vermis oluruz.Ve baska projeye ait bir classs i kullanmdigimiz icinde bizim projemizin 
            //altinda ki dependencies altinda projemizin hangi projelere ait class lari kullandigi gelir yani bu da demektir
            //ki AccessModifiersTest  projesi bizim AccessModifiers projesine bagimlidir...
            //using e birseyi eklemek demek bir namespace i eklemek demek referans vermek demek degildir bu demektir ki
            //referans olarak olusturugumuz bir projeyi kullanacagiz demektir
            //BIR CLASS IN DEFAULT U INTERNALDIR(AYNI PROJE ICINDEN AYNI NAMESPACE ALTINDAN ERISILEBILIR)
            //BIR PROPERTY NIN DEFAULT U PRIVATE DIR.HICBIRSEY VERMEZSEK PRIVATE OLUR VE BIZ AYNI PROJE ALTINDA BILE
            //AYNI NAMESPACE ALTINDA BILE ERISEMEYIZ, EGER HICBIRSEY VERMEZSEK
            //private demek sadece ilgili class ta gecerli demektir..
            //Ama properties i defaulttan internal yaparsak o zaman da yine ayni mantikli sadece ayni proje icinde yani
            //ayni namespace altinda erisebilirim...
            //EGER BIZ HERYERDE KULLANILMASINI ISTERSEK O ZAMAN HEPSINI PUBLIC YAPMALIYIZ CLASS,PROPERTY
            //ISIMLENDIRME GENEL KURALI:
            //Eger birseyi public verirsek isimlendirmeyi PascalCase yazilmalidir...
            //private sadece ve sadece kendi class i icersinde gecerlidir
            //PROTECTED
            //Sadece ve sadece kendi class inda gecerli ve birde kendi class ini miras alan,inherit eden class larda 
            //gecerlidir....
        }
    }

 class Customer
    {
        
    }
}
