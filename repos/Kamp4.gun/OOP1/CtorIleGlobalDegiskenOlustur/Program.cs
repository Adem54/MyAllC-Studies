using System;

namespace CtorIleGlobalDegiskenOlustur
{
  public  class Program
    {
        static void Main(string[] args)
        {
            DortIslem dortislem = new DortIslem(5, 3);
            //Biz DortIslem class ini parametre ile new lemek zorundayim cunku olusturdugum constructor
            //ile default olan parametresiz constructor i override ettim ama eger paramtresiz de new leye
            //bilelim dersek class imizi o zaman gideriz 1 tane de paramtresiz constroctor olustururuz
            Console.WriteLine(dortislem.Topla(5, 8));//Ekstra parametre istiyor kullanicidan
            Console.WriteLine(dortislem.Topla2());//kullanicidan gelen degerleri kullaniyor dogrudan
            //Kullaniciya alternatif sunuyoruz ister toplama icn ekstra parametre versin istersede dogrudan
            //constructor dan gelen degerlerle toplama islemleri yapilabilir


            Console.ReadLine();
        }
    }

    public class DortIslem
    {  //Kullanicidan deger alabilmek icin
        private int _sayi1;//field olusturuyoruz
        private int _sayi2;
        public DortIslem(int sayi1, int sayi2)//Constructor da verilen degerler kullanici tarafindan class
            // new lenirken class in new DorIslem(3,5) parantezine verilir.Ama constructor in parametresinde
            //olan bu degerler dogrudan disarida kullanilamaz C# da(javascripte kullanilir).Ondan dolayi
            //bizde once ustte int tipinde 2 tane degisken olusturup onlara parametredeki degerleri aktararak
            //constructor parametresindeki degerlerin global olarak Dortislem nesnesi icerisinde olusturacagimiz
            //tum methodlarda kullanilabilmesini sagliyoruz
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public DortIslem()
        {

        }
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
    }
}
//Disardan deger constroctor uzerinden alinir yani kullanicidna deger bir nesneden constroctor uzerinden
// ve istersen disardan aldigin o degerleri dogrudan methodlarinda kullanabilirsin istersende 
//methodlarinda ayrica parametre de isteyebilirsin kullanicidan