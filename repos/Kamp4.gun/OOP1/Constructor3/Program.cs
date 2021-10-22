using System;

namespace Constructor3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //GETTER ILE VERI ATAMA SADECE CONSTRUCTOR UZERINDEN OLUR VE BU BIZIM VERI TIPLERININ
            //BIZIM ISTEDIGIMIZ TIP TE ATANMASINI SAGLAYARAK KONTROL ALTINA ALIRIZ
            //CONSTRUCTOR DISINDAS GETTER ILE VERI ATAMASI YAPILAMAZ VERI SADECE OKUNUR
            //ORNEK GETTER ILE VERI ATAMA

            Person person1 = new Person("Adem", "Erbas");//Getter ile veri atamasi yaptik
            //Simdi bu verilere propertiesler uzerinden ulasalim!!!!
            Console.WriteLine(person1.FirstName);
            Console.WriteLine(person1.LastName);

            //SIMDI DE SETTER YONTEMI ILE VERI ATAMASI YAPALIM BU ISE KLASIK YONTEMDIR BURDA ISTEDIGMIZ
            //GIBI VERI ATAMASI YAPABILIYORUZ
            //SETTER ILE VERI ATAMA
            //Bu arada eger bir tana parametresi olan constructor olusturursak default olan parametresiz
            //constructor in arka planda calisan yani, default olan constructor in ezilmemesi icin 
            //bir tane default constructor da onde olustururuz!!
            Person person2 = new Person();
            person2.FirstName = "Salih";
            person2.LastName = "Kaya";

            Console.ReadLine();
        }
    }


    public class Person
    {
        public Person()
        {

        }
        public Person(string firstName,string lastName)
        {
            FirstName = firstName;//Class i new lerken class parantezine getter ile propertylerin 
            //verilerini atamis oluyoruz ve orda girdigimiz veriyi properyler uzerinden alabiliriz...
            LastName = lastName;

        }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
