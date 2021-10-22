using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    { //Onun icin Security klasoru altina bir tane de Encription adli bir klasor ekleriz
       //Encryption icerisine SecurityKeyHelper adli bir nesne olusturacagiz..
       //Bir tane static nesne olusturacagiz...
       //Normalde return den sonra ki new kismi JwtHelper.cs de idi ama biz kurumsal kod yazmaya
       //ozen gostermek ve bunu daha da evrensel hale getirmek icin securityKey i ayrica tertemiz birsekilde
       //yaptik
       //tip olarak SecurityKey dondurecek SecurityKey Microsoft.IdentityModel.Tokens dan gelir
       //bir operasyon yaziyoruz...
       public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
        //SymetricSecurityKey nesnei ile bu islem yapiliyor parametre olarak ise
        //string olarak gelen securityKey nesnesi byte tipine cevriliyor...
        //Bir string i byte tipine cevirme:
        //byte[] encodeBytes=Encoding.UTF8.GetBytes(securityKey);
    }
}
