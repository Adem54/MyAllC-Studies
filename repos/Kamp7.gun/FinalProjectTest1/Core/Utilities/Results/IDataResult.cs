using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
  public  interface IDataResult<T>:IResult//T verisi urune gore ve methoddaki getirdigimiz urun veya urunlere
        //gore degisecegi icin biz tur donusum problemimizi cozen geeneric yapi ile calisiriz ve sinirlamada 
        //koymayiz..
    {
       public T Data { get; }
    }
}
//Biz IDataResult ta message,success ve Data dondermek istiyoruz ve message ve success i zaten IResult ta olusturduk
//tekrar bir daha IDataResultta olusturmak yerine IResult interface ini IDataResultta implement ederiz..