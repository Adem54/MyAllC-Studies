using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
 public class MyList2<T>
    {
        T[] _array;
        T[] _temparray;
        public MyList2()
        {
            _array = new T[0];
        }

        public void Add(T item)
        {
            _temparray = _array;
            _array = new T[_array.Length + 1];
            for (int i = 0; i < _temparray.Length; i++)
            {
                _array[i] = _temparray[i];
            }
            _array[_array.Length-1] = item;
        }
    }
}
