using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Base olan Result un constructor lari old icin burda 
    public class DataResult<T> : Result, IDataResult<T>
    {

        public DataResult(T data, bool success,string message):base(success,message)
        {
            Data = data;
        }

        //Constructor lar i da overriding yapmis oluyoruz burda
        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }

       
        public T Data {get;}
    }
}
