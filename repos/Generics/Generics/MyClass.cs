using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
  public  class MyClass<T>
    {
        T[]  _array;
        T[] _tempArray;
        public MyClass()
        {
            _array = new T[0];
        }

        public void Add(T item)
        {
            _tempArray = _array;
            _array = new T[_array.Length+1];
            for (int i = 0; i < _array.Length; i++)
            {
                if (i==(_array.Length-1))
                {
                    _array[i] = item;
                }
                else
                {
                    _array[i] = _tempArray[i];
                }
               
              
            }
        }

        public int Count
        {
            get { return _array.Length; }
        }
    }
}
