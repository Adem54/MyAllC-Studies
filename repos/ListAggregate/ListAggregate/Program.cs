using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListAggregate
{
    class Program
    {
        static void Main(string[] args)
        {

            var collection1 = new int[] { 2, 4, 8, 16, 32 };

            var sum = 0;
            foreach (var x in collection1)
                sum += x;

            Console.WriteLine(sum); //62

            var collection = new int[] { 2, 4, 8, 16, 32 };

            var result = collection.Aggregate((sum, x) => sum + x); //((((2 + 4) + 8) + 16) + 32)
            //Burda ilk parametrede sum 2 x 4 tur soonra ikisi 6 oluyr ve bunu suma atiyor sonra 6 sum, 8 x olur ve 6+8=14 olur ve
            //14 sum, 16 x olur sonra 30 olur ve 39 sum olur 32 ise x olur...Yani kisacasi bu aggregate bir onceki foreach te yapilan
            //islemin aynisini yapiyor...
            //Degisken isimleri hem ilk ornekteki foreach te hem de aggregate deki sum ismi tam olarak ayni islevi yapar sum, deger 
            //biriktirren bir degiskendir, x ise toplama ogesidir...DIKKAT EDELIM sum deger birktirir dikkat edelimm...
            //ornegimizde sum her adimda uzerine ala ala gider ayni yukardaki gibi..
            //UNUTMAYALIM 1.PARAMETRE AKUMULATOR TOPLAYICI, 2.PARAMTRE ENUMERATOR 
            var result4 = collection.Aggregate((sum, x) => sum + x);

            Console.WriteLine(result); //62
            Console.WriteLine("------------------------------------------------");

            //intEnumerable<int>.Aggregate<int>(Func<int,int,int>func)
            var result1 = collection.Aggregate((sum, x) =>
            {
                Console.WriteLine($"Sum: {sum}");
                Console.WriteLine($"X: {x}");
                return sum + x;
            });
            /* Sum: 2  X: 4  Sum: 6   X: 8  Sum: 14 X: 16 Sum: 30  X: 32     */

            //Bu aşırı yüklemede, seed adında yeni bir parametremiz var ve jenerikler biraz farklı
            //(dönüş tipi ve func parametresi ve dönüş tipi). Yeni parametre, daha önce tanıtılan
            //akümülatörden başka bir şey değildir, bu yüzden şimdi böyle bir şey yapabiliriz.
            /////////////////////
            //  public static TAccumulate Aggregate<TSource, TAccumulate>(
            //this IEnumerable<TSource> source, TAccumulate seed,Func<TAccumulate, TSource, TAccumulate> func)

            var collection2 = new int[] { 2, 4, 8, 16, 32 };

            var sum2 = 0;
            
           var result2 = collection2.Aggregate(sum2, (accumulator, x) =>accumulator+x
         );
            //Burda accumulator de toplaniyor tum elemanlar yine ayni yukardaki sum gibi...
            Console.WriteLine("sum2: " + sum2);

            Console.WriteLine(result); //62

            Console.WriteLine("StringBuilder!!!!!!!!");

           var collection3 = new string[] { "Aggregate", " ", "is", " ", "fun", "!" };

            StringBuilder myStrings = new StringBuilder();

            var result3 = collection3.Aggregate(myStrings, (sbAccumulator, x) => sbAccumulator.Append(x));
           //
            Console.WriteLine("myStrings: "+ myStrings); //myStrings: Aggregate is fun!
            Console.WriteLine(result3); //result3: Aggregate is fun!
                                        //




            //public static TResult Aggregate<TSource, TAccumulate, TResult>(
            //    this IEnumerable<TSource> source,
            //    TAccumulate seed,
            //    Func<TAccumulate, TSource, TAccumulate> func,
            //    Func<TAccumulate, TResult> resultSelector


            //
            //)

            Console.WriteLine("*********************************************************************");
            var listOfLists = new List<List<int>>
        {
            new List<int> {1, 2, 3, 4},
            new List<int> {5, 6, 7, 8},
            new List<int> {9, 10}
        };

            Console.WriteLine("listOfLists:  " + listOfLists);

            IEnumerable<int> combined = new List<int>();
           //ASAGIDAKI ACIKLAMAYI OKU!!!!OLAYIN EN MANTIKI COZUMU ORDA!!!!!!!
            combined = listOfLists.Aggregate(combined, (current, list) => current.Concat(list)).ToList();

           
            foreach (var item in combined)
            {
                Console.WriteLine("item "+ item);
            }




            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");

            //SIMDI COZDUM BU AGGREGATE ZIKKIMINI.......
            //BaslancigBakiyesi Aggreagate nin parametrelerinden ilki bu parametre ilk baslarken baslangic degeri olarak
            //SonBakiye ye aktariyor kendini SonBakiye ise akumulator dur yani yapilan islem sonrasi gelen her sonuc son bakiyedir
            //liste deki siradaki  eleman ise siradakiTutardir 
            //Orneklendirelim sirayla islem nasil gidiyor yazalim...
            //Aggregate(100(basBakiyesi),(100(SonBakiye),20(listenin ilk elemani)
            //100-20=80 bu 80 son eleman(bakiye) olur sirakitutar da listenin 2.elemani olur..yani 10
            //80-10=70 simdi de son eleman 70 siradaki eleman 40 dir
            //70-40=30 sonEleman 30 siradakiEleman 50 
            //sart saglanmyacak 30<50 o yuzden direk sonEleman i al diyor yine sonEleman 30 olacak ve  siradakiEleman 10 olacak
            //30-10=20 SonEleman ve siradakiEleman 70 olacak 20<70 old icin sonEleman 20 sirdsaki Eleman 30 ve
            //20<30 old icin sonEleman 20 dir sirada Eleman da kalmadigi icin sonuc yani Bakiye=20 dir 

            //Elemanlarin son degerlerine bakalim, BaslangiBakiyesi diye verdigmiz degisken icerde sadece baslangic degeri olarak
            //sonBakiyeye aktarir ve SonBakiye orda baslangic degeri old icin o degerle baslar eger baslangic degeri olmasa idi
            //parametrede sadece 2 tane olsa idi o zaman sonBakiye CekilmekIstenenler listesindeki ilk degerden baslayacakti....

            //Bu arada sunu farkedelim burda bir dongu meydana geliyor!!!!!!!!tek tek liste icindeki elemanlar geziliyor ve isleme
            //tabi tutuluyor.....

            double BaslangicBakiyesi = 100.0;

            int[] CekilmekIstenenler = { 20, 10, 40, 50, 10, 70, 30 };
           

            double Bakiye =
                            CekilmekIstenenler.Aggregate(BaslangicBakiyesi,
                                                         (SonBakiye, SiradakiTutar) =>
                                                                (
                                                                 (SiradakiTutar <= SonBakiye) ?
                                                                 (SonBakiye - SiradakiTutar) :
                                                                  SonBakiye
                                                                )
                                                        );

            Console.WriteLine("BaslangicBakiyesi " + BaslangicBakiyesi);
            Console.WriteLine("Son kalan: {0}", Bakiye);
            Console.ReadLine();
        }


       


    }
}
