using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    //Biz bu hata yonetimimizi constructor uzerinden yonetmek istiyoruz yani
    //kullanici bunu sadece class olustururkken verebilsin kendisi veriyi set edemesin
    //diye sadece get readonly yaptik ama get ile veri atanabilen tek istisna constructor dir
    public class Result : IResult
    {
        //Hem mesaj hem de islem basarili veya basarisiz olma durumu ve de mesaj ile birlikte
        public Result(bool success,string message):this(success)
        {
         
            Message = message;
        }
        //Sadece sonucu donsun... isteyebilriiz mesaj vermeden..
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
