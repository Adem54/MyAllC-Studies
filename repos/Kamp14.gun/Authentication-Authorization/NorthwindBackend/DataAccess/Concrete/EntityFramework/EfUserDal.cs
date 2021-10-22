using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Linq;

using System.Collections.Generic;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepostoryBase<UserTest, NorthwindContext>, IUserDal
    {
        //Kullanicinin rolleri icin bizim useroperationclaim lerin ismini cekecegiz..
        //Yani kullaniciyi hem kullanici bilgileri hem de kullanici rolleri ile
        //beraber ayni tablo da getirecegiz yani join atacagiz...
        //Biz diger tablolari da kullanicinin icinde toplayacagiz
        public List<OperationClaimTest> GetClaims(UserTest userTest)
        {//OperationCalim tablosu ile UserOperationClaim tablosunu join etmem gerekiyor
            using (var context=new NorthwindContext())
            {
                //Gonderilen bir kullanicinin rollerini almak istiyorsun ama senin OperationClaimsTest
                //ile UsersTest arasinda foreign key yok yani 3. bir tablo var ve bu tabloda
                //hem UserId hem de OperationClaimId roll Id leri var iste biz bu tablo araciligi
                //ile gonderilen kullanici uzerinden o kullanicinin rollerini cekecegiz!!!!
                //Burda yaptigimiz gonderilen kullanici uzerinden kullanicinin rollerini cekmek


                var result = from oCT in context.OperationClaimsTest
                             join uOCT in context.UserOperationClaimsTest
                             on oCT.Id equals uOCT.OperationClaimId
                             where uOCT.UserId == userTest.Id
                             select new OperationClaimTest
                             {
                                 Id = oCT.Id,
                                 Name = oCT.Name
                             };
                return result.ToList();//result Iquareble doner ve listeye ceviririz

            }
        }
    }
}
//Gonderilen user in claimlerini bir join operasyonu vasitasiyla cekiyoruz...
//Kullanici giris yapar UsersTest tablosuna bilgileri gelir
//Sonra roller tablosu da dolar simdi bize ne lazm olacak gonderilen kullanicinin rolu lazm dolayisi
//ile gonderilen kullanicinin herhangi bir rolu var mi onu cek et tablodan 
//Onu nasil kontrol edersin tabi ki UserOperationClaims yani kullanicirol operasyonundan
//userOperationClaims ile OperationCalims i join etmek demek su demektir claimid
//yani rolid si sende var mi diye soruyoruz userOperationClaim tablosuna 
//Zaten sunu unutma users tablosundaki userId ve OperationCalims tablosundaki Id ler girildikten sonra
//bu Id lere bakarak userOperationClaims tablsoundaki userId,claimId doldurulur burda
//soyle degisik bir durum 1 tablo da 2 foreign key ve biz hem userid si uysun sana hem de 
//claimid si uysun sana seklinde bir sorgu gibi birseyyapiyoruz aslind....
