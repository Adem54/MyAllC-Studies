using System;

namespace CreateMyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int, string> MyDictionary = new MyDictionary<int, string>();
            MyDictionary.Add(12, "Serkan");
            MyDictionary.Add(14, "Kaan");
            MyDictionary.Add(16, "Musa");

            Console.WriteLine("Key eleman sayisi: "+MyDictionary.LengthKey);
            Console.WriteLine("Value eleman sayisi: "+ MyDictionary.LengthValue);

            Console.ReadLine();
        }
    }


    class MyDictionary<Tkey, Tvalue>
    {//Oncelikle T icerisinde 2 elemani bu sekilde yazarak tip problemini cozuyoruz aslinda
        Tkey[] keys;
        Tvalue[] values;
        public MyDictionary()
        {//Bizim dictionary mizi ilk basladiiginda icerisinde hic eleman olmayan bir dizi olarak baslar ve bu baslama olayi
            //bizim class imiz new lenir new lenmez 0 elemanli dizimiz olusmasi icin biz constructor icerisine yazariz
            keys = new Tkey[0];
            values = new Tvalue[0];
        }

        public void Add(Tkey key,Tvalue value)
        {
            Tkey[] _tempKeys = keys;
            Tvalue[] _tempValues = values;

            keys = new Tkey[_tempKeys.Length + 1];
            values = new Tvalue[_tempValues.Length + 1];

            for (int i = 0; i < _tempKeys.Length; i++)
            {
                keys[i] = _tempKeys[i];
            }

            for (int i = 0; i < _tempValues.Length; i++)
            {
                values[i] = _tempValues[i];
            }

            keys[keys.Length - 1] = key;
            values[values.Length - 1] = value;
        }

        public int LengthKey
        {
            get { return keys.Length; }
        }

        public int LengthValue
        {
            get { return values.Length; }
        }

        
    }
}
