using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    //Class larin iki ozelligi vardi.
    //1-Properties tutarlar.
    //2-Operasyon, method tutarlardi
    // Property tuttugumuz yerde operasyon veya metod tutmuyoruz, method tuttugumuz yerde de proeprty tutamayiz
    //Bir musteri nin id,musteri no,ad,soyad, vergi, sirket adi
    
    //Biz genellikle bazi sayisal karsiligi olan property leri eger uzerinde matematiksel islem yapmayacaksak string olarak 
    //tanimlamamiz farkli sistemlerle calisirken daha iyi sonuclar almamizi saglayacaktir.Veri uyumsuzluguna yol acabiliyor cunku 
    //matematiksel ifadeler bazi sistemlerde farkli anlamlara gelebiliyor ama long la da yaparsak yanlis diyemeyiz illaki
    
   //BURASII COOOOOOOK ONEMLIIIIIIIIII!!!!!!!!!!!!!!
    //ENTITIES YANI PROPERTIES LERI TUTACAGIMIZ ALANA GELIRIZ VE ONCE CUSTOMER GIBI ORTAK PROPERTY LERI BIR YERDE TUTARIZ
    //DAHA SONRA DA INDIVIDUALCUSTOMER VE CORPORATECUSTOMER GIBI CLASS LARA SADECE ONLARA OZEL PROPERTYLER KOYARIZ
    //DAHA SONRA ORTAK OZELLIKLERIN OLDUGU CUSTOMER CLASS INI INDIVIDUALCUSTOMER VE CORPORATECUSTOMER INHERIT EDERLER VE
    //BU SEKILDE ARTIK INDIVIDUALCUST VE CORPORATECUST CLASS LARI CUSTOMER CLASS ININ TUM OZELLIKLERINE ULASABILIRLER
    //CUSTOMER CLASS ONLARIN BABALARI OLMUS OLUR BIR NEVI
    //CUSTOMER CLASS I IISE ONLARDAKI ONLARA OZEL OZELLIKLER BOXING YONTEMI ILE ULASIR (Individual)customer.....)
    //Bu sekilde ayrica biz su problemi cozuyoruz biz bu entities lerimizi yani property class larimizin hepsini istediimiz gibi
    //operasyonlarimizda kullanabilmek iicin operasyonlarimia parametre olarak veriyorduk, ama elimizde 3 farkli classimiz olursa 
    //nasil hepsini de kullanabiliriz yani biz bir class verebiliyoruz parametreye ama hepsini  de kullanmak istiyoruz o zaman
    //ne yapariz o zaman biz Customer class ini yani inheritance alinan class i parametreye verirsek artik digerlerini de onun yerine 
    //kullanabiliriz bu nasil oldu bu su sekilde oldu:
    //Biz normalde herhangi bir class tan olusturdugmuz bir instance veya nesne degiskenin baska bir class instancesine atayamayiz
    //Bu isin istisnasi inheritance alinan Customer class indan olusan bir degiskene IndividualCustomer veya CorporateCustomer
    //class instancesini atayabiliyoruz iste bu sebepten biz parametreye Customer verince diger property class larimizdan customer
    //gibi parametrede kullanilabilmis oluyor ve bu bize cok sey sagliyor, yazilimda devamlilik, surdurulebilirlik gibi bizim isimizi
    //cok kolaylastiriyor
   // BASE SINIF-TEMEL SINIF- INHERIT ALINAN SINIF-DIGER CLASS LARIN INHERITE ETTIGI SINIF
    class Customer//Property class i burasi ve parantez almaz buna dikkat!!!!!!!!
    {
      //
        public int Id { get; set; }
        public string CustomerNumber { get; set; }
    }
   
    //ONEMMLI!!!!!!!!
    //GERCEK MUSTERI ILE TUZEL MUSTERI BIRBIRININ YERINE KULLANILAMAZLAR
    //SIRF BIRBIRINE BENZIYOR DIYE BIRBIRININ YERINE KULLANMA 
    //SOLID PRENSIPLERINDEN GELIYOR BUNLAR
    //ONUN ICIN IKISIDE BIRBIRINE BENZIYOR DIYE IKISINI TUTUP DA TEK CLASS DIYE DUSUNMEK COK YAYGIN BIR HATADIR SONRA BIRCOK SEY
    //BIRBIRINE KARISABILIR
}
//Bir bankada en cok yapilan isler Musteriyi yonetmek, personeli yonetmek, kredileri yonetmek, subeleri yonetmek
//Bir bankada musteriler i dusunelim musteriler iki ye ayrilir, 1-gercek musteriler(normal vatandaslar),
//2-tuzel musteriler (sirketler)
//Onun icin musteri yonetim sistemii  kurmaya calisiyoruz ondan dolayi class imiza customer diyoruz