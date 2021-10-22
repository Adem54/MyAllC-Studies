using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProject
{
    class Program
    {//Linq-Languageintegreated-query-Dilegömülü sorgulama-
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Bir kategori listesi oluşturalım. Category miz bir class tır yani bir class tipidir onun için bu şekilde yazarız
            List<Category> categories = new List<Category>
            {
                new Category {CategoryId=1, CategoryName="Bilgisayar"},
                new Category{CategoryId=2, CategoryName="Telefon"},
            };

            //Product listesi de oluşturuyoruz bu şekilde
            List<Product> products = new List<Product>
            {
                new Product {ProductId=1, CategoryId=1, ProductName="Asus Laptop", QuantityPerUnit="32 GB RAM", UnitPrice=10000, UnitsInStock=12},
                new Product {ProductId=2, CategoryId=1, ProductName="Acer Laptop", QuantityPerUnit="16 GB RAM", UnitPrice=8000, UnitsInStock=10},
                new Product {ProductId=3, CategoryId=1, ProductName="Lenovo Laptop", QuantityPerUnit="8 GB RAM", UnitPrice=6000, UnitsInStock=4},
                new Product {ProductId=4, CategoryId=2, ProductName="Samsung Telefon", QuantityPerUnit="64 GB RAM", UnitPrice=7000, UnitsInStock=9},
                new Product {ProductId=5, CategoryId=2, ProductName="LG Telefon", QuantityPerUnit="32 GB RAM", UnitPrice=5500, UnitsInStock=7},
                new Product {ProductId=6, CategoryId=2, ProductName="IPhone Telefıon", QuantityPerUnit="16 GB RAM", UnitPrice=11000, UnitsInStock=5
                },
            };//Biz burda Category ve Product listesi oluşturduk ama bu listeler normalde veritabanlarından gelecek gerçek sistemlerde

            //Ürünlerimizi ekrana yazdıralım...

            //   foreach (var product in products) {Console.WriteLine(product.ProductName);}//Ürünleri getirmek için burayı kullanırız

            //fiyatı 7000 den büyük olan ürünleri getir diyelim

            //foreach (var product in products) if(product.UnitPrice>7000) {Console.WriteLine("UnitPrice ı 7000 den büyük olan ürün isimleri:   "+product.ProductName);}

            //Hem fiyatı 7000 den büyük olan hem de stokta 5 tane den fazla olanları getir diyelim
            Console.WriteLine("Algoritmik.......................................");
            foreach (var product in products)
            {
                if(product.UnitPrice>7000 && product.UnitsInStock > 5)
                {
                    Console.WriteLine("Fiyat > 7000 VE UnitsInStock>5: " + product.ProductName);
                }
            }

            Console.WriteLine("Linq..........................................");

            var result = products.Where(p => p.UnitPrice > 7000 && p.UnitsInStock > 5);
            //p burda product değişkeni gibi arka planda bir döngü çalışıyor biz de bu tarafta o döngü her döndüğünde
            //elemanları tutacak değişken p oluyor bu isimlendirme mantığında normalde biz product diye isim veriyoruz
            //o zamaan onun başharfini veririrz, eğer 2 isimden oluşan bir isim olsa idi o zamanda her iki ismin başharflerini veririrdik
            //Burdaki result sonucumuz bir dizi, liste şeklinde bir sonuçtur dolayısı ile gelen veriyi okumak için döngüden geçirmemiz gerekir
            foreach (var product in result)
            {
                Console.WriteLine(product.ProductName);
            }

            GetProducts(products);//List<Product> products=new List<Product>{}



        }//Birde biz ismin yanına kategori ismini de getirtmek istersek o zaman yine baya bir kod yazmamız gerekecektir



        //Bir method yazarak işlemimizi yapalım
        //static ana class ımızın içinde yazdığımız methodu main de çalıştırabilmek için static olmak zorundadır
       //LINQ OLMADIĞI DURUMDA YAZACAĞIMIZ KOD BU GetProducts methdou olacaktı
        static List<Product> GetProducts(List<Product> products)//parametre olarak products listesini vermeliyiz tabi tipi ile
                                                               //birlikte vereceğiz
                                                               //Burda biz işlemimizi List<Product> class ı ve değişken adı
                                                               //products üzerinden listemizi ooluşturacağıjmız
                                                               //oluşturduğumuz için bu şekilde yazarız
                                                               //Biz her bir filtreli ürünü listeye eklememiz lazım normal hayatta çalışırken bu şekilde çalışırız
                                                               //Bu GetProduct methodunuz biz Linq olmasa idi ne yapmamız gerekiyordu onu anlatmak için yapıyoruz
                                                               //Bir liste ooluştururuz çünkü dönen filtrelenen elemanları listeye atmamamız gerekiyor
        
       {
            List<Product> filteredProducts = new List<Product>();
            foreach (var product in products)
            {
                if (product.UnitPrice > 7000 && product.UnitsInStock > 5)
                {
                    //Şarta uyanların hepsini  önce bir listeye eklememiz gerekiyor
                    filteredProducts.Add(product);//Her bir döngüde şarta uyan listeleri ekliyoruz
                    Console.WriteLine("Fiyat > 7000 VE UnitsInStock>5: " + product.ProductName);
                }
            }
            //Döngü bittikten sonra oluşan listeyi çağırıyoruz
            return filteredProducts;

        }

        //AYNI İŞLEMİ LINQ İLE İSE AŞAĞIDAKİ TEK SATIR KOD İLE YAPABİLİYORUZ
        static List<Product> GetProductsLinq(List<Product> products)
        {
            //Linq deki where foreach i sağlıyor bize ve ayrıca arka planda yeni bir liste oluşturup dönen verileri
            //ona ekliyor yani bizim tekrardan bir listeye veri eklememize ihtiyaç bırakmıyor ve çok daha pratik hem
            //arka tarafta döngü yapıyor hem de liste oluşturup her döngüden dönen veriyi listeye otomatik ekleyerek
            //bizim işimizi çok daha kolaylaştırıyor ve tek satırda tüm işlemi yapabilmemizi sağlıyor
          return  products.Where(p => p.UnitPrice > 7000 && p.UnitsInStock > 5).ToList();
            //Linq de sonucu itere edilebilir imerable dönüyor biz ona ToList() dersek sonuna listeye çevirecektir
            //where methodu hem arkada döngü oluşturuyor ve bizim verdiğimiz şarta göre dönen elemanları da bir
            //liste oluşturup o listeye atıyor ve bize o listeyi dönüyor
            //Bizim verdiimiz listeyi tek tek geziyor dolaşıyor ve bizim verdğimiz şartları kontrol ediyor ve
            //uyanları yeni bir liste oluşturuyor en başta ve şartlara uyanları o listeye atıyor
            //Özetle eğer elimizde bir listemiz var ve bu listemizde filtreleme yapılacaksa o zaman kesinlikle Linq
            //kullanırız ki C# projelerinde filtrelemeniin olmadığı proje nerde ise yokk gibi ve Linq onun
            //için çok hayatdi öneme sahiptir projeler için
        }


    }
        
    //Ürün özelliklerimizi barındıran bir class yazalım. Property class ı yazalım

    class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }//ilişkisel bir sistem kurarrız buraya id verip bu id yi gidip diğer tarafta kullanırız
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
    //Bir ürünün hangi kategoride olduğunu anlamak için Product class ına bir de categoriname ekemeyi düşünebiliriz ancak
    //onun şöyle bir handikapı vardır biz her ürüne bir de kategori ismi vereceğiz ayrı ayrı ancak yarın öbürggün
    //biz diyelimki teknoloji şirketinde bilgisayar kategorisini bilişim olarak değiştirmek gerekirse o zaman gidip
    //tek tek tüm ürünlerdeki bilgisayar kategoriName ini değiştirmek zorunda kalırız.Bu yüzden bu tür durumlarda biz ilişkisel çalışırız
    //yani categoriye bir id veririz ve o kategori id sini gidip diğer tarafta kullanırız. Şöyle düşünelim bir kadın
    //evlendiğinde soyadı değişiyor ve sistemd soyadının kayıtlı olduğu heryerde soyadını gidip tek tek değiştirmezler
    //ne yaparlar soyadını tc ile ilişkilendirmişlerdir ve tc sinin tutulduğu yerde adı soyadı değişince heryerde
    //otomatik olarak değişir aynen bu mantık
    //

    class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
//Gerçek hayatta doğrudan gidip ana sayfaya kod yazma vs şeklinde şeyler olmaz gerçek hayatta methodlar
//yazılır fonksiyonlar yazılır ve onlar döndürülür ana kod ları çalıştıracağımız yerlerde tamamen sistematik
//çalışılması gerekir