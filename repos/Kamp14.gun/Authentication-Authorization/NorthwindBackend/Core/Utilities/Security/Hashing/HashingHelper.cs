using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
  public  class HashingHelper
    {//bir helper yani gelen passwordun hashlanmis halini bize verecek..
        //Biz aslinda istersek bu 3 parametreyi bir nesnenin icerisine de koyabiliriz..
        //Birde biz out keywordunu kullanmak istiyoruz
        //parametrede onune out keywordu koydugumuz parametre artik o parametre referans tip olur
        // ve mehtodu icinde yapacagimiz degisklik disariya da yansir..
        //Siz parametreyi gonderdiginizde degisen nesne ayni zamanda bizim byte[] arrayimize de
        //aktarilacak
        public static void CreatePasswordHash(string password, out byte[] passwordHash,
           out byte[] passwordSalt)
        
            //Bunu using disposabel patterni ile yaziyoruz kendi dokumantasyonunda da boyle zaten
            //Yani kullandiktan sonra garbage collector u beklemeden siler ve bosuna yer kaplama
            //sina izin vermez. birkerelik kullanip atilacak manasinda
            //Bu hash algoritmasi ondan dolayi ismi hmac tir ve bu hmac algoritmasi standarttir
            //bu yontemle yapilir
            
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {//iki tane parametremiz var birisi passwordSalt
                passwordSalt = hmac.Key;//Ilgili kullandigimiz algoritmaninn o an olusturdugu
                //key degeridir.Her kullanici icin baska bir key degeri olusturur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //ComputeHash icerisine bytearray istiyor stringi	
                //kabul etmiyor o da godnerilen password degerinin byte degerini almamiz anlamina	
                //geliyor onu da encoding icerisnde bir stringin byte karsiligini alan yontemi	
                //kullanarak yapariz	
                //Kisacasi bu yazdigimiz kod verdiginiz bir password degerinin salt ve hash degerini 
                //olusturmaya calisir
            }

        }
        //Artik elimizde CreatePasswordHash mevcuttur
        //Bir operasyon daha yazariz bu da hash passwordhashini dogrulama operasyonudur
        //Sadece verify yapacagimiz icin burda bir out a ihtiyacimiz yok...
        //Parametreler yine ustteki CreatePasswordHash parametreleri ile aynidir
        public static bool VerifyPasswordHash(string password, byte[] passwordHash,
            byte[] passwordSalt)
        {//Yine ayni mantkla disposabel  pattern ile using kullancagiz..
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //computed-hesaplanmis  hash
                //Kullanici daha once olusan password u gonderirse o zaman bu yukardaki ile ayni
                //islemlerden geciyor zaten dolasyi ile birbirleri ile ortusecekler
                //Ama ayni sifreyi yazmaz sa o zaman baska bir hash olusur ve o hash 
                //daha once olusturulan hash ile birbirini tutmaz...
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //Bir dongu ile de hash i karsilastiralimm..
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])//passwordHash veritabanindan gelen hash
                        //computedHash kullanicidan gelen hash ve kendi hesapladigim
                        //hash
                    {//esit olmama durumuda direk false dondur ve bitir diyoruz
                        return false;//ayni blokta return de islem biter bir alt bloga geecer...
                    }
                }
                //Ama fark yoksa o zaman true don diyoruz yani hash ler de ayni cikarsa
                return true;
            }
            //Artik HashingHelper imiz hazir olduguna gore AuthManager dan devam edebiilirz
            //AuthManager da bu nesneimizi kullanacagiz..
        }
    }
}
//Burda hemen bir tavsiye verelim ayni seyi iki kez kulandik ve kendimizi tekrar ettik biz
//boyle durumlarda aslinda 
//var hmac = new System.Security.Cryptography.HMACSHA512() buna bir methoda atip o methodu
//her iki yerde de kullanabiliriz....
