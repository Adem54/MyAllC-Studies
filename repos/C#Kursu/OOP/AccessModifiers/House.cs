using System;
using System.Collections.Generic;
using System.Text;

namespace AccessModifiers
{
   class House // class in basina hicbirsey vermezsek default olarak internal olur...ve ayni proje altinda herkes 
    {//erisebilir yani ayni namespace
        //altinda
        public int Id { get; set; }
        string Name { get; set; }//property ye hicbirsey vermezsek default olarak private dir ve kimse erisemez
        //private demek sadece ilgili class ta gecerli demektir..
        protected string Suburb { get; set; }
    }

    class HouseTest:House
    {//HouseTest House u inherit ettigi icin House a ait protected olan Suburb a da erisebilecektir ama 
        //House icindeki private olarak yazilmis olan ya da hicbirsey yazilmamis olan(default ta private olur)
        //field a ulasamaz cunku o field sadece o class a ozeldir...
        public HouseTest()
        {
            //Biz bu constructor icerisinde deniyoruz cunku constructor da bir nevi bir methoddur...
            //Birde suna dikkat edelim mesela biz House class i icindeki kendi constructor inda propertieslerine veya
            //fieldlarina dogrudan erisebiliyoruz.Yani bizim tutup da Id property sine erismem icin kendi class i icinde
            //kendi class ini new lememize gerek yok. Iste ayni sey o class i inherit eden class lar icinde gecerlidiir
            //HouseTest() House u inherit ettigi icin House class inin private olan field haric digerlerine kendi constructor
            //indan erisebilecektir dogrudan......
            Suburb = "My place";
            Id = 5;
        }
        
    }
}
