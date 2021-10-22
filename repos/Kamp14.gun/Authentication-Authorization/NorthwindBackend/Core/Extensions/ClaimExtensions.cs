using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{  //Bunun extension olmasi icin static olusturuyoruz
    public static  class ClaimExtensions
    {
        //Extension method yaziyoruz
        //claims.AddEmail dedigim zaman AddEmail in gelmesini istiyorum bu yuzden buraya
        //AddEmail extension methodu yazacagiz..
        //Bunu claims de gorebilmek icin soyle bir teknik kullaniyoruz...
        //ICollection turunde claim i extend edecegim
        //this ile baslar method neyi extend edecek o gelir daha sonra gelen string email de
        //parametremiz oluyor
        //AddEmail icin yaptik bunu
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            //aslinda operasyona biz bir eklmee yapacagiz yeni bir claim eklyecegiz.
            //JwtRegisteredClaimNames System.IdentityModel.Tokens.Jwt; den gelir
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
            
        }
        //Simdi de Name icin yapalim

        public static void AddName(this ICollection<Claim> claims,string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims,string nameidentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameidentifier));
        }

        //Bizim  icin cok onemli olan bir kisim var ki oda roles kismidir simdi onu da ekleyelim
        //Bizim buna da cok ihtiyacimiz var... cunku rolleri kullanacagiz.
        //Birden fazla roller olabilecegi icin string array olark aliriz
        public static void AddRoles(this ICollection<Claim> claims,string[] roles)
        {
            //rol bir array olarak gelecegi icin once rolu listeye cevir ve ona bir foreach uygula
            //diyecegiz.. ve her bir rolu git tek tek sisteme ekle diyecegiz..
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

    }
}
//Artik Claims e eklentileri ekledik ve operasyonlari icerisinde artik ekledigimiz bu eklentileri
//gorebilecegiz. claims. deyince karsimiza AddEmail,AddNameIdentifier,AddRoles gelecektir...
//Yani jwtHelper da artik claims de bu eklentileri kullanabilecegiz...
