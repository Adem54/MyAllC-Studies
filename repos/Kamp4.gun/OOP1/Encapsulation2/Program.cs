using System;

namespace Encapsulation2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person person = new Person();
            //Private
        }
    }

    public class Person
    {
        private string _firstName;
     

        public string FirstName
        {
            get { return "Mr"+ _firstName; }

            set
            {
                if (_firstName is null)
                {
                    _firstName = "Adem";
                } 
                
                _firstName = value; }
        }

      



    }
}
//Encapsulation, private olarak tanimladigimiz degiskenleri public hale getirmemizi ve istedigimiz sekilde
//kullanabilmemizi saglayan islemdir.Ancak private olan degiskenimiz hala private olacak.
//Yani bir degiskenimiz hem private, hem public olacak.Bu sayede de rastgele veri atanmasinin
//onune gecebilecegiz
//Burda dikkat edilmesi gereken husus sudur ki degiskenimiz private ancak properties yani ozelligimiz
//publictir
//Kisacasi disardan direk erisilemeyen ve rastgele deger girilmesini engelleyebildigimiz bir yontemdir