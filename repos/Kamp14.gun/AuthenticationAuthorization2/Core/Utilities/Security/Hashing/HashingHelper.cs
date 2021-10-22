using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash,
            out byte[] passwordSalt)
        {//Burda bizim elimizde kullanicidan gelen password var sadece onunla beraber parametreye 
            //yazdigimiz passwordHash ve passwordSalt i biz parametreye verdik ve burda onlari olusturu
            //yoruz sonra da parametrede out ile verdigimiz passwordHash ve passwordSalt i
            //bu method icindeki gecirildigi islemlerden sonra o hali ile disarda da kullanabilecegiz 
            //veya baska bir method da da kullanabilecegiz out verdgimiiz icin...
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            //HMACSHA512() ayni zamanda bizim icin bir class uretiyor ondan dolayi () yapmaliyiz


            {
                 passwordSalt = hmac.Key;
                //Ilgili kullandigimiz algoritmaninn o an olusturdugu
                //key degeridir.Her kullanici icin baska bir key degeri olusturur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                 //ComputeHash icerisine bytearray istiyor stringi	ondan dolayi kullanicidan gelen
                 //passwordu byte[] e cevirip oyle parametreye koyariz..
            }
        }

        //Bu islem kullanici sistemimizde kayitli oldugu tespit edildikten sonra yapilacak
        //Sistemimizde kayitli olan kullanicinin passwordHash ve passwordSalt i parametreye veriliyor
        //Kullancinin kayitli passwordHash ve passwordSalt i AuthManager da ki userService uzerinden
        // email cek ediliyor ve email i varsa dedikten sonra geriye veritabaninda kayitli olan
        // useri donuyor...Ve o uzer uzerinden veritabanindaki userin passwordHash ve passwordSaltina
        //erisiriz..
        public static bool VerifyPasswordHash(string password, byte[] passwordHash,byte[] passwordSalt)
        {//password=>kullanicidan gelen password
            //passwordHash ve passwordSalt ise o kullaniciya ait veritabanindaki degerler
            //Kullanicidan gelen password uzerinden bir hash uretilirken once salt i kullaniriz
            //Salt i kullandiktan sonra kullanicidan gelen password u de kullanarak bir tane daha
            //hash uretiriz ve simdi de son olarak kullanicidann gelen password ile ve  once veritabanindaki
            //salt i kullaniriz ve sonra da onun uzerinden hash uretiriz kullanicinin passwordu ile
            //Elde ettigimiz computehash ile de veritabanindan gelen passwordHash i for dongusu ile
            //karsilastiririz...
            //Biz hash leme yapabilmemiz icin oncelikle hmac nesnesi olusturmaliyiz ve bunu salt i 
            //kullanarak yapacagiz ki hash olusturma islemi dogru bir process ile ilerlesin
            //var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt)
            using (var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    //computeHash ise veritabanindan gelen computeHash
                    if (computeHash[i]!=passwordHash[i])//passwordHash kullanicinn hashlanmis paswordu
                        //birbirine esit degilse, ayni degilse
                    {
                        return false;
                    }
                  

                }
                return true;

            }
        }
    }
}
