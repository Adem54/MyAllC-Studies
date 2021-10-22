using System;

namespace VirtualMethods1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();
            MysqlServer mysqlServer = new MysqlServer();
            mysqlServer.Add();



            Console.ReadLine();
        }
    }

    class Database
    {//public ten sonra virtual koyduk Add ve Update methoduna
        public virtual void Add()///Ekleme islemi cogunda ayni ise biz default bir ekleme islemi yapiyorz bu sekilde
        {
            Console.WriteLine("verilerimiz default olarak database eklendi!");
        }

        public virtual void Update()
        {
            Console.WriteLine("Verilerimiz default olarak database de guncellendi");
        }
    }

    class SqlServer:Database
    {
        //Biz default olarak Add metoduna bir kod yazariz Database class i icersinde ama bu default kodlar Sql e uymuyor
        //Yani SqlServer da biz tamamen farkli kodlar yazmamiz gerekiyor
        //biz override dedgimiz zaamn virtual keyword une sahip methodlar ekranimiza gelir sira ile ve orda Add e tiklayinca
        //karsimiza override ile Add methodu gelir karsimiza ve icinde base.Add() base degimiz class inherit alinan classtir
        //Yani Database class idi onun icindeki Add de zaten default olarak ekledgimiz Add idi ama bana SqlServer da
        //ekleme isleri farkli old icin burda farkli sekilde yazmam gerekiyordu Add islemini sqlServer da biz base.Add() yerine
        //baska bir sey ekleyelim
        public override void Add()
        {
            Console.WriteLine("SqlServer ile eklendi..");//Virtual ile override ettigm icin artik Sql in kodu calisiyor
            //Yani SqlServer da Sql kodu ile calisikren Mysql de o virtual i override etmedigim icin temel kod calisir yani
            //temel kod inherite edilen class icindeki kodlar default olarak calisacaktir mysql classinda
            //base.Add();
        }

    }


    class MysqlServer:Database
    {
       
    }
}
//Kisacasi sizin inheritance yaptiginiz ortamda genel bir operasyon var o bircok ortama ayni ise onu inheritance alinan
//class icerisinde default olarak yazariz ama bu bazen degiskenlik gosterebiliyorsa yani cogunlukla default uygulaniyor ama
//bazen degiskenlik gosterme durumu oluyorsa o zaman bu yazdgimiz deefault methodu ezerek o class a ozel olarak 
//tanimladgimiz kodlarin calismasini isteyebiliriz bu ezme isi override etme isidir yani default olan degil artik
//benim yazdigim gecerli olsun demeektir.Yani eger Base class i inherite eden class lardan bir tanesi default olan
//kodlar ona yeterli gelmiyor orda deegisiklik yapmamiz gerekirse o zaman inherit edilen class icerisinde
//o method a virtule veririrz ki eger o default olan methodu ezmemiz gerekirse onu ezip orda bizim ihtiyacimiz olan
//kodlari yazalim diye  
//public virtual void Add()=>Bu demek oluyor ki biz bu methodun icinde bulundugu class diger class lar tarafindan inherite
//ediliyor ve onu inherite eden class lardan bir tanesi Add methodunu default hali ile yani bizim inherit edilen
//class iceriisnde yazzdigimiz sekli iile kullanmayabilir ondan dolayi ben ne olur ne olmaz bu methodu virtual yapayim da 
//Olurda bu methodu ben classlarin birinde ezmek isteersem yani override yapip kendine ozel kodlari yazmak istersem
//bunu yapabileyim diye bu methodu virtual ile yaziyoruz=>public virtual void Add()
//Degisiklik yapmamiz gerektiginde ise degisiklik yapmak istedigimiz class icerisnde
// public override void Add() bu sekilde yazar ve icerisinde istedigimiz kodlari yazabiliriz.....
//Bazen de hem default kodu hemde kendi yazdgimiz kodu calistirmak isteriz o zamanda biz override deyince class icerisinde
//zaten otomaiktmen uzerinde degisiklik yapmak istedigimiz methdoun ismi gelir tiklarsak otomatik base.Add() seklinde
//default olark calisan kod gelir biz koda dokunmayiz bu kod un ustune bu class a ozel kodlarii yazarsak hem kendimize
//ozel kodlari hemde default kodlari calistirmis oluruz....
//ISTE BU TARZ BIR DURUMU BIZ INTERFACE ILE YAPAMAYIZ ONUN ICIN BU TARZ DURUMLARDA INHERITANCE DEN YURUMEMIZ GEREKIR

