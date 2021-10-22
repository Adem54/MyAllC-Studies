using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {  
            // List<string> cities = new List<string>();
            //List bir class tir

           //Generic class lar sayesinde istedigimiz turde generic listeler collector ler olusturabiliriz
           //Elimizdeki mevcut bir listeye o liste elemanlarini kaybetmeden yeni eleman ekleyebiliyoruz

            //Dizilerde Eksik Olan Ne idi
            //1-Biz yeni eleman eklemek istedigimiz zaaman diziyi yeniden new leyip eleman sayisini bir arttirip sonra tekrardan eski 
            //elemanlari yeni olusturdugmuz diziye aktarmak zorunda kaliyorduk cunku new leme olunca yeni bir alan, adres tutmaya basliyor
            //Elimizdeki diziyi buyutemiyoruz elemanlari keybetmeden buyutmeyiyoruz

            MyList<string> cities = new MyList<string>();
            List<int> numbers = new List<int>();
            Console.WriteLine($"numbers eleman sayisi baslangicta {numbers.Count}");
            Console.WriteLine(numbers.Count);//Count bir propery dir ve sadece read only get ile calisacaktir
            // Count property si sadece  get{} ile calisacaktir yani sadece okunarak calisacak ve dikkat edelim herhangi bir
            // method degil bir property dir yani numbers.Count diye yazilir, numbers.Count() bu sekilde degil bu yanlis 
            //DIKKAT numbers.count bir propery dir nerden anliyoruz cunku parantez onunde acilip kapanarak calismiyor
            //yani bir method degildir veya bir operasyon degildir
            numbers.Add(1);
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(6);

            foreach (var number in numbers)
            {
                Console.WriteLine("Number: "+number);
            }


            Console.WriteLine("numbers[2]=  " + numbers[2]);
            //Listelere diziler gibi index uzerinden ulasabiliyoruz

            cities.Add("Skien");
            Console.WriteLine(cities.Length);
            cities.Add("Oslo");
            Console.WriteLine(cities.Length);

            foreach (var item in cities.GetItems)
            {
                Console.WriteLine(item);
            }

            
            Console.ReadLine();

           
        }
    }
}
