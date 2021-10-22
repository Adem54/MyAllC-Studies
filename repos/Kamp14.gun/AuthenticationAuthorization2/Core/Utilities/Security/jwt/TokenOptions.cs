using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.jwt
{
  public  class TokenOptions
    {
        public string Audience { get; set; }//Token in kullanici kitlesidir
        public string Issuer { get; set; }//Imzalayan
        public int AccessTokenExpiration { get; set; }//Dakika cinsinden token gecerlilik suresi
        public string SecurityKey { get; set; }//Guvenlik anahtari,token olustururken kullancamiz
        //parametrelerden biride budur......
    }
}
