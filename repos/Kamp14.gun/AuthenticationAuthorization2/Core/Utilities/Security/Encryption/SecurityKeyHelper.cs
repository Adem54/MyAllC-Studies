using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{//Microsoft
   public class SecurityKeyHelper
    {//SecurityKey tipinde olacak ve bu Microsoft.IdentityModel.Tokens paketinden gelir...
        //Algoritmali ,kriptolu(encryption) sifreli bir securityKey elde ediyoruz burda
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            byte[] encodedBytes = Encoding.UTF8.GetBytes(securityKey);
            return new SymmetricSecurityKey(encodedBytes);
        }
        //SymetricSecurityKey nesnesi IdentityModel.Tokens paketinden geliyor ve bize bir tane
        //kriptolu securityKey uretiyor bizden de bir tane byte turunde securityKey parametresi istiyor
        //bizim verdigimiz securityKey imiz string old icin biz onu byte[] turune cevirerek onun
        //paremtresine veriyoruz

        //Bir stringi byte veri tipine cevirme
        //byte[] encodedBytes = Encoding.UTF8.GetBytes(securityKey);
        //Ornek string=mymagicstring   encodedBytes=6d 79 6d 61 67 69 63 73 74 72 69 6e 67
        //Bir byte veri tipini stringe cevirme
        //String decodeString=Encoding.UTF8.GetString(encodedBytes)
    }
}
