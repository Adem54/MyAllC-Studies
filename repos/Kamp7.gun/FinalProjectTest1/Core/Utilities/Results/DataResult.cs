using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public DataResult(T data, bool success, string message):base(success,message)
        {
            Data = data;//Bu constructor calisinca alttaki 2 parametreli versiyonu da calistiramadigim icin
            //mecbur Data=data; yi her iki constructor a da yazdim...
        }

        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }

        //sadece success olan parametreli constructor i sadece birsey denemek icin yazdim proje ile alakasi yok!!
        public DataResult(bool success):base(success)
        {

        }
        
        public T Data { get; }
    }
}
