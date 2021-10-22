using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public interface IResult
    {
        public bool Success { get;}//Sadece gettir yapariz ki setter ile nesne propertieslerimize veri atamasi
        //yapilamamasi icin sadece getter ile constructor da veri atamasi yapilabilir bizde bu sistemi
        //constructor larla kontrol etmek istiyoruz
        public string Message { get; }
    }
}
