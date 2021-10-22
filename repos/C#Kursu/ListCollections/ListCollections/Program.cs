using System;
using System.Collections.Generic;

namespace ListCollections
{
    class Program
    {
        private static void Println(string s)
        {
            Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            List<Book> bookList = new List<Book>()
            {
                new Book("Les Miserables", "Victor Hugo", 1862),
                new Book("L'Etranger", "Albert Camus", 1942),
                new Book("Le Tour du monde en quatre-vingts jours", "Jules Verne", 1869),
                new Book("Madame Bovary", "Gustave Flaubert", 1857),
                new Book("Le Comte de Monte-Cristo", "Alexandre Dumas", 1844),
                new Book("Vingt mille lieues sous les mers", "Jules Verne", 1872),
                new Book("Les Trois Mousquetaires", "Alexandre Dumas", 1844),
                new Book("Candide", "Voltaire", 1759),
                new Book("Notre-Dame de Paris", "Victor Hugo", 1831),
                new Book("Voyage au centre de la Terre", "Jules Verne", 1864)
            };

            bookList.ForEach(p => p.SalePrice = 14.99);

            foreach (var book in bookList)
            {
                Console.WriteLine(book.SalePrice);
            }

            Console.WriteLine("####################################################################################");
           
            List<String> names = new List<String>();
            names.Add("Table");
            names.Add("Lion");
            names.Add("River");
            names.Add("Banana");

            // //Using of C# List ForEach with delegate
            names.ForEach(delegate (String name)
            {
                Console.WriteLine(name);
            });


            Console.WriteLine("Using of C# List ForEach with Custom Method");
            names.ForEach(Println);///ForEach i biz names listesi nde yazdik ve names listesi icinde string donuyor dolayisi ile biz parametre
            //olarak string alan ve void olan bir methodu direk icinde calistirabiliriz....


            //: Simple List ForEach example
            List<int> numbers = new List<int>() { 10, 20, 30, 40, 50, 60, 70 };

            numbers.ForEach(x => Console.WriteLine(x));

            //Using of C# List ForEach with Lambda
            names.ForEach(x => { Console.WriteLine(x); });

            // Using with Action
            Console.WriteLine("Using with Action");
            List<Action> actions = new List<Action>();

            List<int> Mynumbers = new List<int>() { 10, 20, 30, 40, 50, 60, 70 };
            //Burda actions listesi icerisine isimsiz action fonksiyonu atiyor ve o action fonksiyonu ise isimisiz return olmayan action dir 
            //Ve o action fonkksiyonu her bir sayinin sirasi ile numbers icindeki sayilari gosteren fonks yaziyoruz....
            numbers.ForEach(number =>
                actions.Add(() => Console.WriteLine(number)));

            foreach (Action action in actions)
                action();

            //New Example
            Console.WriteLine("New Example");
            List<MyBook> MyBooks = new List<MyBook>()
            {
                new MyBook("Broken hearts","Romance",12),
                new MyBook("Nothing in my life","Guide",2),
                new MyBook("Love for love", "Romance", 10),
                new MyBook("Spain", "Travel", 8),
                new MyBook("Fruits", "Cookbooks", 25)
            };
            //Delege burda parametresi MyBook property nesnesi olan 


            MyBooks.ForEach(delegate (MyBook b) {
                Console.WriteLine("Name:{0}", b.Title);
                Console.WriteLine("Genre:{0}", b.Genre);
                Console.WriteLine("Price:{0}", b.Price);
                Console.WriteLine();
            });
            //Burda delegate ile yazilan da bir anonim methoddur....Suslu parantezden ititbaren o anonim methodun parantezidir...
            MyBooks.ForEach(delegate (MyBook x) {

                if (x.Genre == "Romance")
                {
                    x.Title = "Drama";
                }
            });

            MyBooks.ForEach(delegate (MyBook b) {
                Console.WriteLine("Name:{0}", b.Title);
                Console.WriteLine("Genre:{0}", b.Genre);
                Console.WriteLine("Price:{0}", b.Price);
                Console.WriteLine();
            });







            Console.ReadLine();

            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%");


            string[] sehirler = new string[] { "Oslo", "Trondheim", "Stavenger" };
            Console.WriteLine(sehirler.Length);
            string sehir = "Skien";

            string[] yeniSehirler = new string[0];
            Console.WriteLine("yeniSehirler dizi uzunlugu: "+yeniSehirler.Length);
            yeniSehirler = sehirler;

            
            Console.WriteLine("yeniSehirler dizi uzunlugu: " + yeniSehirler.Length);

            sehirler = new string[4];

            for (int i = 0; i < yeniSehirler.Length; i++)
            {
                sehirler[i]= yeniSehirler[i];
            }
            sehirler[sehirler.Length - 1] = sehir;

            foreach (var item in sehirler)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Listeler");

            List<int> sayilar = new List<int>();
            Console.WriteLine(sayilar.Count);
            //Listeler ilk olugunda 0 elemanli olarak olusuyor...
            //Listeler arka planda bir dizi olarak calisiyor...

     List<string> sehirler2 = new List<string>() {"Berlin","Duseldorf","Leipzig" };

            sehirler2.Add("Hamburg");

            foreach (var item in sehirler2)
            {
                Console.WriteLine(item);
            }
            sehirler2.RemoveAt(0);

            sehirler2.RemoveAll(p => p.StartsWith("L"));
            Console.WriteLine("---------------");
            foreach (var item in sehirler2)
            {
                Console.WriteLine(item);
            }

            if (sehirler2.Contains("Hamburg"))
            {
                Console.WriteLine("Hamburg sehri listede bulunmaktadir");
            }
            //Girdigimiz eleman in indexini ogrenebiliriz
            Console.WriteLine(sehirler2.BinarySearch("Hamburg"));
            sehirler2.Add("Munih");
            sehirler2.Add("Dortmunt");

            Console.WriteLine("...........................................");
            sehirler2.ForEach(Console.WriteLine);
            Console.WriteLine("...........................................");
            sehirler2.ForEach(Console.Write);
            Console.WriteLine("...........................................");
            sehirler2.ForEach(sehir => Console.WriteLine(sehir+"mmmmmm"));
            Console.WriteLine("...........................................");
            List<string> myNames = new List<string>();

                        Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            sehirler2.ForEach(sehir => Console.WriteLine(sehir=sehir+"mmmmmmmm"));
            sehirler2.ForEach(sehir => sehir = "mmmmmmmm");//sehir bir alyasdir deger atanamaz...Ama mesela sehir bir nesne instancesi olsa idi
            //o instancenin herhangi bir properties ine deger atayabilirdik tabii  ki de.....
            



            foreach (var item in sehirler2)
            {
                Console.WriteLine(item);
            }


            //    public delegate void Action<in T>(T obj);
            //T tipinde parametre alan yani herhangi bir tipte parametre alan sonrasinda da void donus yapan methodu isaret ediyor



            /////
            ///


           

        }
    }


    public class Book
    {//title, author, and publication date 

        public Book(string title,string author,int publication)
        {
            Title = title;
            Author = author;
            Publication = publication;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Publication { get; set; }
        public double SalePrice { get; set; }
    }



    class MyBook
    {
        string title;
        string genre;
        int price;

        public string Title { get => title; set => title = value; }
        public string Genre { get => genre; set => genre = value; }
        public int Price { get => price; set => price = value; }

        public MyBook(string t, string g, int p)
        {
            title = t;
            genre = g;
            price = p;
        }
    }
}
