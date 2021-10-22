using System;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            //Set
            product.Id = 1;//set ediyoruz...setter calisiyor...
            //Bir propertye deger atadigimiz zaman setter calisir yani onu set etmis oluruz..
            //Get islemi yapiyoruz okuma dedigimizde
            Console.WriteLine(product.Id);

            product.City = "Skien";

            Console.WriteLine("City: "+product.City);
            //Set edildi
            product.UnitsInStock = 50;
            //Get edildi
            Console.WriteLine(product.UnitsInStock);
            //Bir cok programlama dilinde getter setter lar yoktur...direk field lar vardir yani direk degisken 
            //tanimlanir
            //Biz usstte UnistInStock a tanimlarken { get; set; } vermememize ragmen hem set edebildik hem de get
            //ile okuyabildik o zaman neden { get; set; } kullaniyoruz...
            //Ornegin biz UnitPrice i set ediyoruz mesela
            product.UnitPrice = 500;
            Console.WriteLine(product.UnitPrice);
            //Projede UnitPrice i okudugumuz yerde bize mesela 500 un KDV li fiyatini vermemiz gerekirse
            //ve projede her yerde okurken 500+KDV olarak okumak isterseniz yani biz setter yapalim ve
            //okurken ise KDV ile beraber okumak istersek eger o zaman gidip de class imizin properties inin get
            //ine mudahele edebiliriz...
           

        }
    }

    public class Product
    {
       private decimal _unitPrice;//Private old icin bunu nesne instancesinden okuyamayiz...
        //Dolayisi ile biz buna get icinde okuruz
        public decimal UnitPrice
        {
            //get birseyi okumak old icin yani get birsey dondurmesi gerekir yani return olmalidir...
            //Biz propertieslerde icerde bir field vardir onu yonetiriz...
            //Get ederken KDV yi de heryerde okunabilmesini sagliyoruz....
            get { return _unitPrice + _unitPrice * 18 / 100; }
            //set ile ne deger girilirse _unitPrice a onu atayacak ve okurken ise KDV ile birlikte okuyacak heryerde
            set { _unitPrice = value; }
        }

        //Bizim getter ve setter larimizin arka planda calisma sekli aynen City properties i ve _city field inda 
        //oldugu gibidir...
        //Bizim bir tane private string _city seklinde yazilmis olan field adi verilemn alanimiz var..
        //Bu field City properties e karsilik gelen degerimizi yonettigimiz yerdir ama disardan ulasilamiyor sadece icerde
        //ulasilabiliyor
        //get te return _city diyerek bu alani bana ver diyoruz...set te ise yine bu  _city yi set ediyoruz... 
        //Kisacasi biz product.City = "Skien"; deyince bize set { _city = value; } burasi calisiyor value nedir
        //value kullanicinin girdigi degerdir C# onu oyle anliyor biz ona deger girdgimiz zaman
        //o valueye karsilik geliyor.... product.City="Skien" demek ise _city="Skien" dir aslinda..
        //Console.WriteLine(product.UnitPrice); burda okuyoruz okudugumuz icinde  get { return _city; } calisir
        //Iste tam burda su mudaheleyi yapabiliyoruz ben bu _field daki _city degerini okurken ornegin basina birsey
        //eklemek istiyorum veya iste ayni UnitPrice get ornegindeki gibi KDV ile beraber okumak istiyorum  o zamanda 
        //geliriz ve onu get { return _unitPrice + _unitPrice * 18 / 100; } boyle okuruz...
        //Iste getter ve setter in kullanimi bu sekildedir
        //Peki biz tutup da setteri kaldirirsak ve sadece get kismini  yazarsak o zaman ne olur
        //O zaman da diyoruz buna deger set edilmesin bu sadece okunabilsin
        //Simdide aklimiza su soru gelecek iyi de deger girilemeyen, deger set edilemeyn bir field in nesini okuyalim ki
        //Burda da bir puf nokta var o da cok kritik iste o zaman da biz deger i constructor uzerinden vermeye calisiriz iste
        //Yani biz zaten sadece getter varken deger atayabilecegimiz tek yer constructor parametresi kaliyor....
        private string _city;
        public Product(string city)
        {
            _city = city;
           
        }

       
        public string City
        {
            get { return _city; }
          //  set { _city = value; }
        }

        //Burda da bu sekilde sadece okunsun ve deger de saddece constructor uzerunden atansin demis oluyoruz....
        //Iste burda kullaniciyi biz bu sekilde kullanilmasina izin veriyoruz sadece....
        public Product(int year)
        {
            Year=year;
        }
        public int Year { get; }

        //READ ONLY
        //Hem get hem de set i olan propertye Auto implemented property ve bunlari sadece readonly 
        //yani ya public int Id { get; set; } ya da public int Id { get;} boyle yazabiliyoruz
        //Ama birde writeonly var o da sadece yazabiliyoruz
        //O zaman da su sekildde yazariz...

        //WRITE ONLY
        string _productMark;//Bu da write only olur....
        public string ProductMark
        {
            set
            {
                _productMark = value;
            }
        }

        //----WRITE ONLY OLUYOR BU SEKILDE DE
        public int Id { get; set; }

        public string ProductName { get; set; }


        public decimal UnitsInStock;

    }
}
