using System;
using System.Collections.Generic;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Genericleri kullanmamız için biz List yazınca zaten altını çizer ve yukarıya using System.Collections.Generics i eklememiz için uyarır
            //List yazısının rengine dikkat edelim class ismimiz ile aynı renktir dolayısı ile List de demekki bir class tır    
            List<string> cities = new List<string>();
            //List class ının içinde kendi methodları vardır kendi operasyonları vardır ve biz Generic List i hangi
            //tipte verirsek içindek operasyonlar o tipte çalışır yani biz de ona göre genericList operasyonlarını kullanırken
            //hangi tipte oluşturdu isek o tipte elemanlar vermeliyiz
            cities.Add("Oslo");
            Console.WriteLine("cities: "+cities.Count + cities[0]);
            //Dikkat edelim burda Count bir method değildir nerden anladık çünkü methodlar fonksiyondur ve parantezle
            //birlkte çalışır o zaman Count nedir Count property dir ve sadece get ile alabiliriz onu ama biz bu Count tan
            //şunu anlıyoruz ki biz hiç eleman ekklemediğimiz zaman eleman sayısı Count un 0 olarak geliyor yani bu Count
            //ile ayarlanmış şimdi bizde bunun aynısını MyList generic class ımıza uygulayalım
            List<int> numbers = new List<int>();
            numbers.Add(12);
            Console.WriteLine("numbers: "+ numbers.Count + numbers[0]);
            //Generic class ın özelliği hangi tiple çalışacağını söylemelisin ki generic list yani class lar harika çalışıyor
            //çünkü tip dönüşüm le biz uğraşmıyoruz o zaten tipe göre çalışıyor bize ne lazım sa ona göre tip verererk kullanabiliriz
           
            //////////////////////////////////////////////////////////////////////////////
            MyList<string> names = new MyList<string>();
            names.Add("Ahmet");
            MyList<int> scores = new MyList<int>();
            
            scores.Add(78);
            scores.Add(84);
            scores.Add(84);
            scores.Add(84);
            scores.Add(84);
            scores.Add(84);
            scores.Add(84);
            Console.WriteLine("MyListCount= " + scores.Count);
            //Yukarda yazdığımız gibi biz MyClass generic class ımızı yazarken hem class yanına class MyList<T> yazmamız
            //hem de generic class içerisinde oluşturduğmuz operasyondaki parametreye  public void Add(T item) verdiğimiz
            //için artık bu generic class oluştururken biz tipi ne verirsek ona göre tipte eleman ekleme yapacaktır

            ///////////////////////////////////////////////////////////////////////////////////////
            //Generic Listeler arka planda array bazlıdır bunu unutmayalım
            Console.WriteLine("MyClass listemizi cek edelim....");
            MyClass<string> countries = new MyClass<string>();
            countries.Add("Norway");
            countries.Add("England");
            Console.WriteLine(countries.Count);

        }
    }

    //Kendimiz generic class yapmaya çalışarak generic class mantığını anlayalım

    class MyList<T>//Biz kendi olşturduğmz class ın da generic class gibi çalışması için type ı temsil eden <T> yi ve o <T> yi yazacağımız herhangi
                   //bir methodda parametre olarak(T item) şeklinde verirsek kodumuz
                   //onun generic olduğunu anlayacaktır ve artık bu generic class ını new leyerek oluşturacağımız
                   //nesnelerimiz üzerinden kullanacağımız method, veya operasyonlarda tip sorun olmaktan çıkacaktır
    {
        

        T[] _array;//_array adında bir değişken oluşturduk generic olarak
        T[] _tempArray;//aşağıda add kısmında eski listemizin kopyasını almak için verdiğimiz değişken ismi

            //Bir tane constructor yazalım 
            //Yukardaki normal bir generic listede Count propertisi ile eleman sayısı 0 geliyor ama normal arraylerde eleman sayısını newledikten sonra vermek zorundasınız
            public MyList()
        {    //0 elemanlı bir array oluşturmuş olduk
            _array = new T[0];//Constructor içerisine eleman sayısı 0 ile başlasın diye bu şekilde yazıyoruz ki new leyince ilk olarak constructor ımız çalışacaktır
        }
        
        
        
        
        //Bizde generic List veya class ımıza method ekleyelim mesella Add methodunu ekleyelim
        public void Add(T item)
        {
            _tempArray = _array;//tempArray e _arrayi atayarak _array in kopyasını oluşturmuş olduk
                                //Kopyasını alıyoruz çünkü _array değişkenine new ile 4 elemanlı mesela bir liste oluştur diyoruz o zaman _array değişkeni
                                //eski tuttuğu 3 elemanlı listenin adresini bırakıyor ve artık yeni 4 elemanlı adresi tutmaya başlıyor ve ne oluyor eski
                                //tuttuğu 3 elemanlı biz bir kopya almazsak yani onu başka bir değişkene atamazsak o zaman _array in eski tuttuğu elimizden
                                //gitmiş oluyor işte bundan dolayı biz bir kopyasını alırız. Devamında ise bizim yapacağımız iş _tempArray in verilerini
                                //yeniden 4 elemanlı olarak oluşturduğmuz _array e aktarmak sırası uygun olacak şekilde

            _array = new T[_array.Length + 1];//Her eleman ekledğinde 1 artırsın diye bunu yazdık ama burda dikkat etmemiz gereken
                                              //önemli birşey var nedir o biz her new ledğimizde yeni bir instance oluşuyor ve adres
                                              //satırında yeni bir adres tutuyr du yani mesela 3 elemanlı bir dizi iken new leyince
                                              //eleman sayısı 4 e çıkıyor ama o elemanları yeni oluşan objede göremeyiz çünkü 4 elemanlı
                                              //boş bir listeyinin adres satırını tutuyor biz de bu işi çözmemiz için öncelikli
                                              //bir önceki 3 elemanlı listenin kopyasını alırız 
                                              //Son olarak da parametreye hangi elemanı verirsek onu _array a son eleman olarak eklettirelim

            for (int i = 0; i < _tempArray.Length; i++)
            {
                _array[i] = _tempArray[i];//Bu yöntemle _tempArray deki elemanları sırasına göre yeni oluşturduğumuz _array a aktarmış oluruz
            }
           

            _array[_array.Length - 1] = item;//parametreye verilen elemanı _array dizisine son elemanı olarak ekliyoruz. 1 çıkarırız çünkü
                                             //dizilerde elemanlar 0 dan sayılmaya başlar son elemanı bulurken eleman sayısının bir eksilğini almamız gerekir
        }
        //property eklerken propfull deyip tab a 2 kez basarsak default olarak hazır kod gelecektir
        //count işlemi old için tipi int dir

        public int Count
        {
            get { return _array.Length; }
            //set { _count = value; }//set işlmei yapmayacağız şu anda
        }


    }
}
//Çok önemli karşımıza yeni bir syntax geldiği zaman onun yapısal olarak neye karşılık geldiini merak etmeliyiz ve anlamalıyız aksi takdirde ezber olacaktır
