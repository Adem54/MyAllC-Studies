using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
   public class ErrorDetails
    {
        //Icerisinde 2 tane property olacak birisi kullaniciya gonderecegimiz mesaj
        //Bir digeri de hata kodudur
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
            //Bu nesneyi oldugu gibi yazdirmak istedigimizde nesne ismini degil de serilestirip
            //onu bu sekilde basariz...
        }
    }
}
