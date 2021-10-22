using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
  public  class SigningCredentialsHelper
    {//Imzalama operasyonu olacak bu.. ve SigningCredentials tipinde dondurecek veriyi
        //SigninCredentials nesnesi Microsoft.IdentityModel.Tokens dan geliyor
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                //Parametrede bizden securityKey ve bir algoritma istiyor
                //Parametreye securityKey verdik securityKey formatinda cunku SigningCredentials
                //veri dondururken SecurityKey formatinda olmasi gerektigni zaten soyluyor...
                //algoritma olarak da security algoritmalarindan HmacSha256 yi kullaniriz baska
                //algoritmalarda kullanilabilir bu tamamen bizim icin encript edilen datanin
                //nasil encript edildigi ile ilgilidir
                //Bu islemi de yaptiktan sonra yine JsonWebToken imizda jwtHelper.cs te donebiliriz
        }
    }
}
