using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)

           

        {

            string kurs1 = "C# kursu";
            string kurs2 = "Java kursu";
            string kurs3 = "Python kursu";
            string kurs4 = "React Kursu";

            string[] kurslar = new string[] { kurs1, kurs2, kurs3,kurs4 };

            for (int i = 0; i <kurslar.Length; i++)//index ile beraber bir bir diziyi listeliyoruz
            {
                Console.WriteLine(kurslar[i]);
            }

            Console.WriteLine("Kurslar listelendi");

            string[] yazilimKurslari = new string[] { "Pascal", "Visual Basic", " Dart" };
            //Gerçek hayatta bu veriler yani kurslar verileri bir fonksiyondan geliyor bunlar veri olduğu için bu veriler bir fonksiyondan geliyor

            //Index ile vs uğraşmadan doğrudan dizi içindeki elemanları foreach ile listeleyebiliiriz
            foreach (var kurs in yazilimKurslari)
            {
                Console.WriteLine(kurs);
                
            }


            foreach (var kurs in kurslar)
            {
                Console.WriteLine(kurs);
            }
            
            //Döngüler birbirine benzeyen işleri tekrar etmek için kullanılıyor

            for (int i = 0; i < 10; i+=2)
            {
                Console.WriteLine(i);
            }

            string[] friends = new string[4];
            friends[0] = "Kerem";
            friends[1] = "Sema";
            friends[2] = "Ahmet";
            friends[3] = "Sercan";

            for (int i = 0; i < friends.Length; i++)
            {
                Console.WriteLine(friends[i]);
            }

            //C# da ki süslü parantezlerin arasındaki kısım bloktur
            Console.ReadLine();
        }
    }
}
