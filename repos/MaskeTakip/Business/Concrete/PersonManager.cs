using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //class ımızı public vermemiz erişim için çok hayati önem taşıyor
    public class PersonManager : IApplicantService //Normalde biz IApplicantService interface ile başlasa idik
                                                   //ve method imzalarımızı orada yazsa idik o zaman interface
                                                   //ismi IApplicantService altı çizilecekti ve biz seçeneklere tıklayınca
                                                   //bizim Interface dosyasındaki method imzalarını n içeriğini burda doldurmamızı isteyecekti
        //Burda biz maske verme işlemini yapacağız
    {
        //Biz buraya Person class ını kullanıyoruz ama import etmediğimiz için Person ın altını çizer biz hemen Person üstün de gelen uyarı
        //simgesinde add reference Person dersek o zaman yukarıya kendisi otomatik dahil yani import edecektir
        // public her taraftan erişilsin diye yazarız
        // return ile bir sonuç döndürmeyen method old belirtir
        //parametreye ise dikkat edelim doğrudan Person class ı ve person nesnesi(objesi) ni veriyoruz ki Person
        //class ı içerisindeki verileri burda kullanabilelim diye
        //Biz doğrudan Person class ının içindeki entities yani varlıkları ApplyForMask parametresinde kullanmış
        //olsa idik ve bu methodu da 20 farklı yerde kullandığımızı varsayalım bize gelen yeni bir talep
        //ile eğer parametreye bir veri daha eklenme talebinde bizim kullandığımız ApplyForMask methodlarını
        //çalıştırdığımız yerlerde hepsindde de method patlar çalışmaz onun için biz parametreye class ismi
        //ve nesnesini veririz ve eğer bir değişiklik olacak sa onu Person classında yaparız
        //İşte parametrede kullanılacak varlık veya verileri alıp bir class a koyma ve o class ve
        //nesnesini parametrede kullanmaya biz encapsulation yani kapsüsseleme diyoruz
        //Encapsulation sayesinde biz Person class ımıza yeni property eklediğimiz zaman gelen talepler
        //doğrultusunda bizim Person class ını kullanarak yazıdğımız methodların hepsi bu değişikliklere
        //uyum sağlayacaktır encapsulation olayı sayesinde
        public void ApplyForMask(Person person)//Burda biz bir method yazıyoruz yani bir fonksiyon yazıyoruz..
        {//Maskeye kim başvuracak person başvuracak yani biz ApplyForMask derken kimin bilgilerini kullanarak bu methodu olşturacağız tabi ki
         //person un e o zaman biz bu konuda da bir public class yazmıştık sürdürebilir olsun diye
         //Biz sıklıkla yapacağımız ve birçok sayfamızda defalarca yapmamız gereken işlemleri class larımız
         //içerisinde method yani fonksiyon yazarak yapıyoruz ki istediğimiz her zaman rahatça kullanmak  için
         //Burda ben kişiyi başvuru yapan kişi eğer daha önceden kaydolmamışsa onu kaydetmek isteyeceğiz,
         //kaydı varsa bundan önce maske
         //almış mı almamış mı onu bulmak istiyorum ayrıca aldı ise kaç tane almış onu da bulamk istiyorum
         //maske almayan kaç kişi kalmış bunları görmek istiyorum

        }

        //Şu ana kadar kimler maske başvurusunda bulunmuş bu verileri almak için de bir method yazalım
        //List<Person> List dediğimzi yapı içerisinde verdiğimiz tipte bir listedir
        //List<Person> derken bana bir liste ver listemin türü Person olsun list of person dön diyoruz onun için burası List<Person>
        public List<Person> GetList()
        {
            return null;//tanımlanmamış olarak dönelim şimdilik referans tipleri tanımlanmamış
                        //olarak bu  şekilde tanımlayalım
        }
        public void NewMethod()
        {
            ApplyForMask(new Person()); //Bu sekılde parametrede doğrudan class dan nesne oluşturarak koyarız kullanırken
        }
        //Eğer gidip PttManager class ında Person class ından new ile yeni bir obje oluşturarak işlem yaparsa
        //Person yani vatandaş  yerine bizim vatandaşımız olmayanlarada maske verilsin diye bir değişiklik olma
        //durumunda o zaman tutup iflerle yönetmeye çalışıyoruz ve buna sipagetti kod diyoruz
        //çünkü biz class mantığını tam doğru işletememiş oluyorz. Birbirinin alternatifi veya
        //birbirinin muadili olan işlemlerde tutup da ifle yönettmeye çalışmak çok mantıklı değğildir
        //ve bir projede ne kadar çok if  o kadar kötü iş demektir
        //bunun için ne yaparız gidip Person class ının muadili olan Foreigners class ı oluşturmamız çok daha mantıklı ve sürdürülebilirdir

        public bool CheckPerson(Person person)//Mernis e bağlanacak ve bu adamın doğru bir adam olup olmadığını kontrol edecek
        {
            return true;//sonucunda return döneceğimiz method veya fonksiyonlarda return yapacağımız veri
                        //tipinin adı method adında kulllanılır ama return yapmayacaksak sadece işlem yapacaksa
                        //o zamanda mehtodu void diyerek oluştururuz
        }
    }
    //Concrete klasörü altına bir class oluştururuz entities ile alakalı yani person verileri ile ilgili işlemler yaparız
    //entities imizin adı person dur
    // Burdaki class a ya PersonManager ya da Servis adını verebiliriz çünkü varlıklarla yani Person ile ilgilidir
    // elimizdeki veriler ile ilgilenir
}
//Biz class ları sadece Person classında olduğu gibi özellik property tutmak için değil aynı zamanda operasyonları
//da tutmak için kullanıyoruz
//Biz class larda ayrı ayrı tutuyoruz verilerimiz çünkü bir sınıfa ya sadece operasyon tutmalıdır
//
//ya da özellik tutumalıdır SOLID prensibinin ilki olan singular responsibility e göre bir class
//ya sadece operasyonel olmalıdır ya da property tutmalıdır
//ÖNEMLİ!!!!!
//Bir class oluşturduğumuz zaman önce olaya abstract klasörü içerisinde interface ile başlanır bunu alışkanlık hale getirmeliyiz