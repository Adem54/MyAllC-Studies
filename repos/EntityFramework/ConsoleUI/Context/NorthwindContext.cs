
using NortwindEfCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace NortwindEfCodeFirst.Context
{//Context dedigimiz ifade kelime anlamina da uyuyor bir iceriktir.Butun iliskileri tanimlayacagimiz yer olarak
    //dusunebiliriz..Musterilerimiz,urulerimiz,musterilerimizin siparisleri,siparis detaylarimiz gibi herseyi 
    //burada dusunebiliriz..
    //Daha ileri anlamda Context i soyle dusuneilibiriz.Proje ayaga kalktiginda bizim sisteme yuklenmesini
    //bellege yuklenmesini istedigimiz tablolar gibi dusunebiliriz...Entityframwork dedigimiz sey bir ORM old icin
    //bir sayfaya girdiginizde, o sayfada gerekli olan tum iliskilerin yuklenmesi gerekiyor fakat tum veritaba
    //nini yani tum veritabanini tablolarini bellege yuklmeye normalde gerek yoktur, onun yerine ithiyac duydugumuz
    //tablolari yukleyebiliriz..O yuzden iste bu sekilde Context ler olusturarak birden fazla Context olusturarak
    //sadece ihtiyac duydugumuz nesneleri yukleyerek performanstan kazanabiliriz fakat Northwind gibi bir veritaba
    //ninda cok daha bu sekilde bir ayrim yapmaya gerek yoktur cunku burda bizim isimizi tek bir context gorecektir
    //Ama kurumsal gercek projelerde bizim birden fazla contexte ihtiyacimiz olacaktir...
public   class NorthwindContext:DbContext
    {
        //Her bir iliski yi bir prop ile DbSet i kullanarak olusturuyoruz..
        //Kisacasi bizim su an yaptigimiz is entitieslerimizi ORM de kullanilacak haline getirmek
       public DbSet<Customer> Customers { get; set; }
      public  DbSet<Order> Orders { get; set; }
    }
}
//Veritabanini nasil iliskilendirecegiz..
//2 sekilde yapabiliriz..
//1.YONTEM=>, eger sizin halihazirda bir tane veritabaniniz varsa, connection stringden ona iliskilendirma
//yaparak onu ayaga kaldirabiliriz..
//2.YONTEM ISE=>Bunu entityframeworkun kendisinin yapmasini, yani sizin zaten veritabaniniz yoktur,entityframe
//worke git benim icin veritabanini olustur diyebiliyoruz.

//ONEMLI!!!!!
//Biz sadece bu sayfada yaptiklarizi yaptiktan sonra Program.cs ye gidip sadece bu nesenimizden bir 
//instance olusturup foreach ile Customer imizin ContactName ini cagirirsak ORM,entityframework
//bizim icin gidip bir veritabani olusturack ve bizim projemizde olusturdugmuz class,entity nesne
//lerimize karsilik gelen tablolari gidip veritabaninda tablo olarak olusturacaktir
//NortwindEfCodeFirst.Context.NorthwindContext isimli veritabanini bizim icin olusturuyor..
//NorthwindContext class inin oldugu namespace namespace NortwindEfCodeFirst.Context ve NorthwindContext
//ismi ile birlestirip veritabani ismini olusturuyor...
//Ayrica tablolari default olarak, biz isimlerii Id yaptigimiz icin ismini Id yaptiklarimzi kendisi
//direk Primary key yapiyor zaten, ayrica da otomatik artan ozelligi de veriyor kendisi default olarak
//NORMALIZASYON ZAAFIYETLERI1!!!
//Tabi ayrica diger propertylerin kolonlarini olustururken normalizasyon kurallarina gore zaafiyetler
//olabiliyor ne gibi, mesela bizim string olan verilerimiz nvarchar olarak yazmis nvarchar dedigimiz 
//bizim yazdigimiz her bir karakter 2 karakter olarak kabul edecektir gereksiz bir yer kaplama soz
//konusu olacaktir, mecbur kalmadikca kendimiz nvarchar yapmayiz , obur tarafdan da veri sinirlarini
//max yapmis ki buna da ihtiyacimiz yok bu da bos yere  yer kaplamasini saglayacak...Ona da bir ayar 
//vermemiz gerekecek...
//Dikkat edersek de Orders tablosu icinde CustomerId yi foreign key olarak veriyor...