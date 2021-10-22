using System;

namespace OutRefKeywords
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            int sayi1 = 10;
            int sayi2;
            myClass.Hesapla1(ref sayi1);

            Console.WriteLine("Hesapla1 isleminden sonra sayi1=" + sayi1);

            myClass.Hesapla2(out sayi2);
            Console.WriteLine("Hesapla2 isleminden sonra sayi2=" + sayi2);


            Console.ReadLine();
        }
    }

    public class MyClass
    {

        public void Hesapla1(ref int sayi1)
        {
            Console.WriteLine("sayi1= " + sayi1);
            sayi1 = 24;

        }

        public void Hesapla2(out int sayi2)
        {

            sayi2 = 36;
            Console.WriteLine("sayi2= " + sayi2);

        }


    }
}
