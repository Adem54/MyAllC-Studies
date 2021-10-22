using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        //Login yapmaya calisan kullanici once kayitli mi diye kontrol edilir...
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
