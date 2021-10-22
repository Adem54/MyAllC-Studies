using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.jwt
{
    //Burasi cok onemli biz burayi Startup.cs de ayarlari yaparken de kullanacgiz...
    public class TokenOptions
    {
        public string Audience { get; set; }//Token imizin aslinda kullanici kitlesidir
        public string Issuer { get; set; }//Imzalayan gibi dusunebiliriz
        public int AccessTokenExpiration { get; set; }//dakika cinsinden yazildigi icin int oldu
        public string SecurityKey { get; set; }//Guvenlik anahtari,token olustururken kullancamiz
        //parametrelerden biride budur......


    }
}
//Yarin oburgun buraya yeni datalarda eklenebilir.Biz bu token options lari webAPI mizde
//appsetting s icerisinde bilgi olarak tutuyor olacagiz ama biz onu nesne olarak map edip daha 
//sonra o nesne uzerinden kullanmak istiyoruz.Bu sekilde daha nesnel calismis oluruz
//Bu token options in setting kisminida veriyor olacagiz