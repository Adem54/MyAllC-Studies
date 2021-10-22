using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateNewList
{
     class MyList1<T>
    {
        T[] items;
        public MyList1()
        {
            items = new T[0];//class olustugu anda 0 elemanli bir dizi olusturmasini istiyoruz.Cunku generic list ler o sekildedir
        }

        public void Add(T item)
        {
            T[] tempArray = items;
            items = new T[items.Length + 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                items[i] = tempArray[i];
            }
            items[items.Length - 1] = item;
        }

        public int Length
        {
            get { return items.Length; }
        }

        public T[] GetItems
        {
            get { return items; }
        }
    }
      
}
