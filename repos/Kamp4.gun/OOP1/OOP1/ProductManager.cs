using System;
using System.Collections.Generic;
using System.Text;

namespace OOP1
{
    class ProductManager
        //Class ları biz properties leri tutmanın dışında operasyonlar için de tutarız işte içerisinde Add,delete,update vs
        //gibi methodları barındırdğımız class ları isimlndirirken genellikle ProductManager veya ProductService gibi isimler kullanılır
    {
        //Parametre olarak Product class tipinde bir o urunden olusturulmus bir instanceyi temsil eden nesne degisken
        //ismi gibi parametgre veririrz. Sen bana Product turunde birrsey gonder ben onu product ismi ile tutuyorum demektir
        public void Add(Product product)//imza yı bu şekilde yazarız. public void Add()=>İmza
            //Add()=>Burasi methodumuzun nasil cagrilacagini anlattigi yerdir
            //Biz bu tür methodlarda neyi ekyleyeceğimizi parametrede veririz ve bu method birden fazla sayfada ve her seferinde
            //farklı bir product ekleyeceği için parametrelerimiz olmazsa olmazdır
            //Add operasyonu icerisine biz olusturdugumuz urun class tipi ile o urunu temsil eden bir parametre veririz ki
            //o urunun tum ozelliklerini bu operasyon icersinde kolayca kullanabilelim. 
            //C# type safe bir dildir yani tip guvenli bir dildir onun icin parametrede yazarken tipi ile yazariz
            //veya bir degisken tanimlarken tipi ile tanimlariz. C# tanimladigimiz degisken veya parametrenin tipini gormek ister 
        {
            // product.ProductName = "Kamera";
            Console.WriteLine($"{product.ProductName}   eklendi!");
        }

        //VOID-INT,STRING VS ILE TANIMLAMA ISLEM YAPMA VEYA  RETURN YAPMA
        //Void tanimlama=>Eger islem sonucunu gormek istemiyor ve sadece emir verip git bir islemi yap ve sonlandir ve
        //bana bir sonuc dondermene gerek yok diyorsak o zaman methodu void ile yapariz
        //Ama eger biz bir sonucu return etmek istersek sonucunda bir veri dondeermek istersek o zaman void yerine
        //dondurmek istedigimiz verinin tipini yazariz 
        //Eger biz yazdigimiz methodunun sonucunda ortaya cikan sonucu baska bir yerde de kullanmak istiyorsak ona ihtiyacimiz varsa
        //bu tur durumlarda biz return ile veriyi dondururu ve o veriyi elde ederiz ve bir degiskene atayarak artik onu kullanabiliriz
        //Iste eger boyle bir methoda ithiyacim varsa o zaman ben o methodu void ile degil dondurmek istedigimi veri tipi ile tanimlarim
        public void Update(Product product)
        {
            Console.WriteLine($"{product.ProductName}   guncellendi!");
        }

        public int Topla(int number1, int number2)
        {
            return (number1+number2);
        }

     //Deger tipler-int,float,double,bool
        //public void Test(int number1)
        //{
        //    number1 = 20;
            
        //}
    }
}
