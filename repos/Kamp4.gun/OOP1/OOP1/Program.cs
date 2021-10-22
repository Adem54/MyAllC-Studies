using System;

namespace OOP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product() { Id = 1, CategoryId = 2, ProductName = "Masa", UnitPrice = 500, UnitsInStock = 3 };
           //NEDEN CATEGORYID VERIRIR VE NEDEN O CATEGORYID YE INT TURUNDEN DEGER ATARIZ
            //Category id yi biz 2 verdik bu veri kaynaginda ornegin mobilya gibi birseye denk gelir biz bu kategoriyyi degistirmek
            //istedigimiiz zaman kodlari degilde arka taraftaki verikaynaginda degisiklik yapariz bunun icin de kategoriye sayi veririz

            Product product2 = new Product();
            product2.Id = 2;
            product2.CategoryId = 5;
            product2.ProductName = "Kalem";
            product2.UnitPrice = 35;
            product2.UnitsInStock = 5;
            //product2 class degiskenimize uzerinden yazdigimiz urunleri sirasini istedigimiz gibi yazabiliriz
            //Burda kendimizin yazdigi verileri bir web uygulamasi ile react,angular biz bunlari kullanicidan aliyor olacagiz
            //BIR CLASS I NEWLEME.....
            //Referans tiplerin heap memory de olusabilmesi icin onu new lememiz gerekiyor
            //ProductManager class turundeki productManager degiskeni heap te yeni bir adress aliyor degisken kismi stack de olusur
            ProductManager productManager = new ProductManager();//Burda biz Class degiskeni tanimlayip ona adres atmaasi yapiyoruz
           //ISIMLENDIRME YONTEMLERI VE ISIMLENDIRMENIN ONEMI
            //Bir ustte class tan degisken olusturma ve adres atama aynen  string isim="Mehmet" gibi birseydir
            //Isimlendirme de suna dikkat edelim Class lar her zaman PascalCase yani ilk harflerin basharfleri buyuk yazilir
            //Ama class degiskenleri ise camelCase ile yani ilk harf kucuk ama sonra gelen kelimeler buyuk harf olur
            //Isimlndirme kurallari bir ise alinip alinmamayi cok ciddi etkileyebilecek bir sebeptir onun icin cok hayatidir
            //mutlaka dikkate alinmalidir
            //C# keycsensitive bir dildir-Buyuk harf kucuk harf duyarlidir
            productManager.Add(product1);
            //Intentional programmering-niyet gudumlu programlama yani parametre sanki varmis gibi once burda ihtuyaca gore
            //yazip daha sonra gidip ProductManager class inda icini doldurmak gibi
            Console.WriteLine($"ProductName=  {product1.ProductName}");
            //REFERENCE TYPES......DAN DOLAYI -array,classes,abstract class,interfaces
            //parametere olarak product1 i Add(product1) yolladiginda Heap memoryde bir adres numarasi veya adres lokasyonu yolladik
            //Burda product1 nesnenimizin ProductName properties i kamera olarak geliyor cunku biz product1 obje degiskenini
            //Product class tipi degiskeni referans tip degiskendir ve biz parametreye atama olarak
            //product1 Product class i degiskenini atiyoruz yani adresini heap teki adres numarasini tuttugu alani artik parametreye 
            //vermis olyoruz parametre bunu napiyor ProductManager da oraya gidip orda bu adreste tutulan ozelliklerden
            //ProductName i degistiriyor , product1 in de tuttugu adres icindeki bir ozelligi degistiriyor dolayisi ile product1
            // in de adresi orasi oldugu icin product1 de bu degisiklikten etkileniyor iste referans tip olmasindan dolayi oluyor bunlar


            //DEGER TIPLER......int,double,bool,float
            //  int number1 = 50;
            // productManager.Test(number1);
            // Console.WriteLine($"Number1=  {number1}");

            //Degeri atar baglantiyi koparir deger tipler, yani degisken le baglantisi degeri kopyaladiktan sonra biter
            //number1 degiskenini parametre oalrak verince number1 int degiskeni degerini parametreye atar ve
            //baska hicbirseyden etkilenmez yani sadece deger aktarimi yapar, productManager icinde parametre Test methodunda 
            //degistirilmis bile olsa o degisiklik burda int ile tanimladigimiz number1 i baglamaz cunku deger tipdir

            //return ettigimiz icin void kullanmadigimiz int ile tanimladigimiz method dan return ettigimiz  veriyi degiskene atayalim


            //////int result1 = productManager.Topla(5, 8);
            ////////Return kullandigimiz icin method bize deger donderiyor
            //////Console.WriteLine($"Toplam sonucumuz: {result1*2}"  );

            Console.ReadLine();
        }
    }
}
