using System;

namespace DifferentDictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            DifferentDictionary<int, string, string> differentDictionary = new DifferentDictionary<int, string, string>();
            differentDictionary.Add(24, "Hulya", "Yaliz");
            differentDictionary.Add(35, "Kaya", "Jale");
            differentDictionary.Add(45, "Sara", "Zafer");

            Console.WriteLine(differentDictionary.KeyLength);
            Console.WriteLine(differentDictionary.ValueLength);
            Console.WriteLine(differentDictionary.NameLength);

            Console.ReadLine();
        }
    }


    class DifferentDictionary<T1, T2, T3>
    {
        T1[] keys;
        T2[] values;
        T3[] names;

        public DifferentDictionary()
        {
            keys = new T1[0];
            values = new T2[0];
            names = new T3[0];
        }

        public void Add(T1 key,T2 value,T3 name)
        {
            T1[] tempKeys = keys;
            T2[] tempValues = values;
            T3[] tempNames = names;

            keys = new T1[keys.Length + 1];
            values = new T2[values.Length + 1];
            names = new T3[names.Length + 1];


            for (int i = 0; i < tempKeys.Length; i++)
            {
                keys[i] = tempKeys[i];
            }
            for (int i = 0; i < tempValues.Length; i++)
            {
                values[i] = tempValues[i];
            }
            for (int i = 0; i < tempNames.Length; i++)
            {
                names[i] = tempNames[i];
            }

            keys[keys.Length - 1] = key;
            values[values.Length - 1] = value;
            names[names.Length - 1] = name;

        }

        public int KeyLength
        {
            get { return keys.Length; }
        }
        public int ValueLength
        {
            get { return values.Length; }
        }
        public int NameLength
        {
            get { return names.Length; }
        }
    }
}
