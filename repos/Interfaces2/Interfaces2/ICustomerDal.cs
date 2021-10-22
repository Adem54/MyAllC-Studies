using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces2
{
    interface ICustomerDal
    {
        void Add();
        void Delete();
        void Update();
    }
    //Örneğin biz bir proje yapıyoruz ve projemiz birden fazla veritabanını destekliyor ya da biz önce bir
    //sql veritabanı ile çalışmaya başladık sonra müşterimiz bize verilerinin bir kısmının Oracle veritabanından
    //olduğunu söyledi yani biz sadece bir sql veritabanı ile çalıştığımız zaman ona bağımlı oluyorz yani ona
    //bağlımlılığımız oluyor işte interface ler bizi bağımlılıktan kurtarıyor istediği kadar farklı veritabanı
    //
    //olsun biz illaki biri ile çalışmak zorunda değiliz aynı anda birden fazla veritabanı ile çalışabiliriz
    class SqlServerCustomerDal : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("SqlServer Added");
        }

        public void Delete()
        {
            Console.WriteLine("SqlServer Deleted");
        }

        public void Update()
        {
            Console.WriteLine("SqlServer Updated");
        }
    }

    class OracleServerCustomerDall : ICustomerDal
    {
        public void Add()
        {
            Console.WriteLine("OracleServer Added");
        }

        public void Delete()
        {
            Console.WriteLine("OracleServer Deleted");
        }

        public void Update()
        {
            Console.WriteLine("OracleServer Updated");
        }
    }


    //Mesela biz Customer verilerini ekleyeceğiz hangi veritabanına göre yapaccağız direk birine
    //göre yaparsak o veritabanına bağımlı olmuş oluruz ki o zamanda diğer veri tabanındaki verilerle
    //çalışmak zorunda kalırsak ne yapacağız mecburen bizim serverımız sadece sql server ı destekiyor mu diyeceğiz 
    //İşte biz CustomerManager içinde yapacağım operasyonlarda Interface tipini ve inerface değişkenini paremetre olarak
    //verirsek o zaman diğer tüm veritabanlarına ve onların method ve özelliklerine erişebiilirim
    //Ve customerDal parametresini kullanarak Add methoduna erişebiliriz
    class CustomerManager {
       public void Add(ICustomerDal customerDal)//Paramtreye interface verdiğimiz zaman istedğimiz veritabanı class ına göre
                                                //işlemlerimizi yapabilriz bağımlılık olmadan
        {
            customerDal.Add();//Biz parametreye hangi class ı verirsek onun Add işlemini yerine getirecektir
        }
    
    }
    //     CustomerManager customerManager = new CustomerManager();
    //İşte interface ler biz hangi server ile veri eklemek istersek o server ile veri ekleyebilmemizi sağlıyor
    //customerManager.Add(new SqlServerCustomerDal());
      //      customerManager.Add(new OracleServerCustomerDall());
}//Gerçek hayatta interface ler katmanlar arası geçişte yoğun birşekilde kullanılıyor
//Burdaki amaç uygulamanın bağımlılıklarını minimize etmektir
