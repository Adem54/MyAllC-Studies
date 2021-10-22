using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    //ClaimPrincipalExtensions bizim mevcut kullanicimiza karsilik gelir
   public static  class ClaimsPrincipalExtensions
    {//Ben burda asil amacim rollere ,claim lere ulasmak ama ilerde ne our ne olmaz ben mevcut
        //kullanicinin id si veya diger ozelliklerine de ulasmam gerekebilir veya dier claim lere 
        //erismek gibi.Ondan dolayi o altyapiya gore gidecegiz direk veya sadece rol uzerinden
        //gitmeyecegiz..Ana noktamiz tabi ki rol olacak ama yine de diger ozelliklere de ulsmaya calisacagiz

//Oncelikle Claims leri filtreleyebilmek istiyorum.Neyi extend ediyoruz ClaimsPrincipal i extend ede
//cegiz yani ekleyecegiz...
//ClaimsPrincipal System.Security.Claims den gelen bir nesnedir ve biz onu extend ediyoruz
//Yani biz onu artik ClaimsPrincipal.Claims(ClaimTypes.) yazacak hale getirmek istiyoruz...
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal,string claimType)
        {
            //Burda thernari ile var mi diyecegiz cunku hic sisteme login olmamis olabilir
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            //Eger varsa bul diyoruz neyi bizden claim in tipini ister, claimType i yazinca
            //yine sorguluyor calimType da varsa yani kullanicinn claimType her zaman olmaya
            //bilir onun icin boyle sorgulayarak gideriz!!!ClaimType da var sa artik Secect ile
            //al ve x icin yani liste oldugu icin sira ile x icin valuesini al ,
            //claimType in Key-Value si vardiya Postman de yazarken de oyle yazmistik , 
            //Ve sonunda da ToList() ile degerini okuyacagiz...
            //Postmanda Authorization yaparken Key,Value olarak Key:Auhtorization value de
            //Bearum Token yaziyorduk
            return result;
            //Biz bununla artik istedigimiz claim Type a erisebilirim.Hemen altta bunu ornekleyelim
            //Ayni zamanda rolleri de cekebilirim
        }

        //Artik claimsPrincipal.Claims(ClaimTypes.Role) seklinde kullanabilirz cunku claimPrincipal 
        //i extend ettik!!!!!!!!!

        //Burda rolleri dondurecegiz..Yani rolleri dondurecegimiz bir methodu ClaimPrincipal a 
        //extent ediyoruz...
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            //ClaimTypes System.Security.Claims den geliyor
            //Claims i biz yine  System.Security.Claims den gelen claimsPrincipal nesnesine extend 
            //etmistik bir ustte ayni burda ekledigimiz ClaimRoles gibi
            return claimsPrincipal?.Claims(ClaimTypes.Role);
            //Kisacasi artik bizim kullanicimiz ClaimsPrincipal.ClaimRoles dediginde artik bizim
            //icin kullaniici rolleri tek bir satirda gelecektir!!!!!

        }
    }
}

//OZETLEYECEK OLURSAK!!
//claimPrinsible bize istek gonderen kullanicimizdir ve biz yazdigimiz extensio da diyoruz ki
//claimsPrincipal?(Eger claimsPrincipa varsa yani sisteme login olmus bir kullanicimiz varsa...
//claimsPrincipal?.FindAll(claimType)?=>(claimType lari var sa eger onlari bul) 
//Ve bunlari dondur ve her birinin values sini bul yani key-value olarak bulunuyordu
//Values sini yani degerini bul getir ve son olarak da listele
//Yani ozetle biz burda ClaimsPrincipal nesnesi gelen kullanicimiza ait bilgilere ulasmamizi saglayan
//bir nesnedir .Net Core ile gelen...
//Biz ise bu nesneye ekledigimiz Claims methodu ile  ClaimsPrincipal.Claims(ClaimTypes.) seklinde
//kullanarak ClaimRoles methodu icinde dogrudan Claim Rollerimize ulasmis oluruz...
//claimPrincipal.ClaimRoles ile claim rollerimize erisebiliriz artik!!!!
//Biz tek satir da kullanicimizin yetkilerine rollerine ulasacak extension yazmis olduk...