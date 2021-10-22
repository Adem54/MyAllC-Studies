using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class MyList<T>
    {
        T[] _array;
        T[] _tempArray;
        public MyList()
        {
            _array = new T[0];
        }

        public void Add(T item)
        {
            _tempArray = _array;
            _array = new T[_array.Length + 1];
            for (int i = 0; i < _tempArray.Length; i++)
            {
                _array[i] = _tempArray[i];
            }
            _array[_array.Length - 1] = item;
        }
        public int Count
        {

            get { return _array.Length; }
            //Count burda dikkat edelim readonly oluyor neden cunku count Add ile her yeni elemen eklendiginde
            //surekli artiyor eleman eklenmesine gore dolayisi ile count a biz mudahele edilmesini istemiyoruz
            //Yani setter yazarsak mudahele edilebilir ama setter i da kaldirirsak artik Count a dokunamazlar...
            //Biz kendisinin otomatik artmasini istiyoruz....disardan mudahele olmadan
        }

        public T[]  GetItem
        {
             get {return _array; }
        }


        //MyList class imiza bir indexer olusturma
        //sayilar[0] = 24;//Set islemi
        //Console.WriteLine(sayilar[0]) //Get islemi

        //LISTEMIZDE INDEXLEME OLAYI DA BU SEKILDE GERCEKLESIYOR!!!!!!
        //Bunun new lenip de kullanilan haline biz this diye tarif ederiz burda.......!!!!!!!
        public T this[int index]
        {
            get { return _array[index];  }
            set { _array[index] = value; }
        }

    }
}
