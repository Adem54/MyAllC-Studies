
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
 public  interface IUserService
    {
        void Add(User user);
        User GetByEmail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}
//User ekleme operasyonuna ihtiyacimiz var register yapabilmek icin
//Login olmak isteyen bir user i veritabaninda varligini kontrol etmek icin email ini veritabanindan 
//getirmemiz gerekiyor neden emmail cunku login olayi email ve sifre girilerek yapilir..
//Birde bilgilerini gonderen kullanicinin claims leri yani rolleri nelerdir veya yetkileri nelerdir
//onlara da ihtiyacimiz olacak....Nerde token uretirken parametrede user ve claims ler
//kullaniliyor!!!!!