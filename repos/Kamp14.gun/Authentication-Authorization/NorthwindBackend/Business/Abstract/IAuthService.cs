using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using Core.Utilities.Security.jwt;
using Entities.Concrete.Dtos;

namespace Business.Abstract
{
   public interface IAuthService
    {
        //Burda artik herseyi birlestirecegiz
        //Bir tane userForRegister nesnesi yani icinde firstName,LastName,Email,Password olan bir
        //nesne isteyecegiz bir de UserForRegisterDto nesnesi ile beraber passord istiyoruz
        IDataResult<UserTest> Register(UserForRegisterDto userForRegister, string password);
        IDataResult<UserTest> Login(UserForLoginDto userForLoginDto);
        //Birde kullanici var mi bunu kontrol edecegiz.
        //Daha onceden kayit olmus bir kullanici bir daha kayit olmaya calisirsa ona
        //uyari verecegiz sen zaten kayitlisin login e gece diyecegiz..
        IResult UserExist(string email);
        //Bunun disinda bir de bir tane AccessToken uretmek istiyorum
        IDataResult<AccessToken> CreateAccessToken(UserTest user);
        //Burasi Authentication olayidi ondan dolayi burda biz Register,Login,UserExist ve birde
        //kullaniciya token olusturma operasyonlarini yapariz....
        //Kullanici login oldugunda ona bir token vermemiz lazm

    }
}
