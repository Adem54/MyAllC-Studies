using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class MyList<T> //=>Generci class-generic collectors-Listeler de hangi tipi verirsek onunla calisabilmemizi sagliyor
    {
        T[] items;//Burda bir array degsikeni tanimlariz ki MyList class icersindeki tum methodlarda kullanabilelim
        T[] tempArray;
        public MyList()
        {
            Console.WriteLine("Constructor sadece  class i new ledigimizde calisir methodlar calistiginda degil");
            items = new T[0];//0 elemanli bir dizi olussun biz class i new ledigimizde
        }

        public void Add(T item)
        {
            //Gelen diziyi gecici bir diziye atayalim cunku biz dizi eleman sayisini 1 arttirmak icin yeni bir dizi olusturacagiz
            //O zamanda dizi eski elemanlarini kaybedecektir Heap te yeni bir addrs tutmaya baslayacagi icin, yeni bir ref alacak
            tempArray = items;
            items = new T[items.Length + 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                items[i] = tempArray[i];
            }

            items[items.Length - 1] = item;
        }

        public int Length//Kendi olusturdugumuz genericc class imizin eleman sayisini bulmmak icin yazdigimiz property dir bu Length
            //Cunku List generic class i  ile olusturulan bir nesne de Count dedgimiz zaman count un bir kere method olmadigini
            //parantezleri olmadigindan anliyoruz ama zaten nesneyi nokta yapip count a gelince de onun sadece get i olan bir property
            //oldugunu gorebiliyoruz
            //Yani bir property de oncelikle parametre almaz ve paramtre parantezleri de olmaz, ayrica eger veri gosterilecekse s
            //saedece o zaman get ile ayrica bir de veri uzerinde herhangi bir islem yapilacaksa o zamanda get ve set ile veri alinir
        {
            get { return items.Length; }
        }

        public T[] GetItems
        {
            get { return items; }
        }

    }
}
