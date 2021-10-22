using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurDonusumKullcDegrAl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir sayı giriniz");
            //ReadLine ile biz kullanıcıdan değer alırız
            //Readline ile kullanıcıdan alınan değerler default olarak string değerindedir onun için eğer
            //bize int tipinde veri almamız gerekirse o zamn tür dönüşümü yapmalıyız
            int sayi1 = int.Parse(Console.ReadLine());
            Console.WriteLine(sayi1*4);

            //Veri tip dönüşümleri

            int sayi2 = 500;//
            byte sayi3 = (byte)sayi2;//byte veri tipi 0-255 arası değerleri tutar ama biz tutup da 500 ü byte
                                     //dönüştürmeye çalışırsak değer kaybı yaşarız ve byte onu alabileceği
                                     //en üst sayı olarak alarak 244 olarak alacaktır
            Console.WriteLine(sayi3.GetType());
            Console.WriteLine(sayi3);

            string sayi4 = "9";
            string sayi5 = "8";
            Console.WriteLine(sayi4+sayi5);
            int sayi6 = int.Parse(sayi4);
            int sayi7 = int.Parse(sayi5);
            Console.WriteLine(sayi6 + sayi7);


            //String Veri Tipini Int e Çevirme
            //int.Parse() ve Convert.ToString() ile string den int a çevirme işlemi yapabiliriz
            string a3 = "23";
            string a4 = "34";
            int a1 =Convert.ToInt32(a3);
            int a2 =Convert.ToInt32(a4);
            Console.WriteLine(a1 + a2);

            //Integer veri tipini Stringe Dönüştürme

            int b1 = 12;
            int b2 = 10;
            string b3 = b1.ToString();
            string b4 = b2.ToString();
            Console.WriteLine(b3+b4);//stringe çevrildikleri için toplamaz yanyana yazar

            //Değişken tipini bulma GetType
            double number1 = 35.4;
            Console.WriteLine("Number1 in veri tipi: =" +number1.GetType());

            //Double tipinden int e çevirme

            int number2 = Convert.ToInt32(number1);//double tipi int e dönüştürünce küsüratlı kısmı atıyor tam kısmı alıyor
            Console.WriteLine( number2);
            //int.Parse() yöntemi ile double dan inte direk dönüştüremiyoruz önce double ı stringe
            //dönüştürmelyiz ondan sonra bu method kullanılabilir

            int sayi8 = 56;
            Console.WriteLine("Sayı8 in değeri 2 fazlası= "+   sayi8+2);         
            Console.WriteLine(sayi8.GetType());
            //Toplama işlemine soldan başlandığı için ilk önce gelen değer eğer string ise sonra birden fazla
            //int değeri var ve orda toplamaya çalışırsak C# burda hepsini string gibi algılayabiliyor onun için
            //eğer bir string i biz int değerlerle birlikte ve ilk önce string i yazacaksak o zaman diğer işlem
            //yapmak istedğimiz string değerlerin işlemlerini parantez içersiinde yazmalıyız
            Console.WriteLine(8+5+"Merhaba");//13Merhaba
            Console.WriteLine("Merhaba" +8+5);//Merhaba85
            Console.WriteLine("Merhaba"+ (8+5));//Merhaba13


            Console.ReadLine();//Ekrandan çıkmak için bir tuşa basmanı bekliyor    
        }
    }
}
