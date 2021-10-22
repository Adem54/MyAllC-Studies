using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
      
        [HttpPost("login")]

        public IActionResult Login(UserForLoginDto userForLoginDto)
        {//Login isleminde kullanicinin varliginin cek edilmesi islemi zaten AuthManager daki
            //Login icinde yapildi...
            var userToLogin = _authService.Login(userForLoginDto);
            //userToLogin data olarak login olan kullaniciyi donuyor!!!!
            if (!userToLogin.Success)//Login basarisiz ise yani kullanici daha onceden kayitli degilse
                //yani veritabaninda kullanicinin email ve sifresi tutmuyorsa veya bulunmuyorsa
            {
                return BadRequest(userToLogin.Message);
            }
            //Kod buraya gelirse demekki bu kullanici login olabiliyor demektir o zaman ona bir token 
            //verecegiz
            var user = userToLogin.Data;//bu user veritabaninda var olan user dir buna dikkat edelim
            //Yani icersinde hashPassword,saltPassword ve Status  u da bulunan bir user dir
            

            var result = _authService.CreateAccessToken(user);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExist(userForRegisterDto.Email);
            if (!userExist.Success)//Kullanici var demektir,kayit olamaz demktir
                //UserExist=>Success durumu gecmiste kaydi yok su an kayit olabilir
                //UserExist=>Error durumu ise zaten veritabaninda kaydin var kayit olamazsin
            {
                return BadRequest(userExist.Message);
            }
            //Buraya geldgimize gore demekki bu kullanici kayit olabilir simdi de kayit olsun
            var registerResult = _authService.Register(userForRegisterDto);
            //Register olayinda veritabanina kullaniciyi bizim kaydettigmiz sekli ile doneriz
            //Yani user donuyoruz icinde tabi ki hashPassword,saltPassword ve status u de var
            //Kullanici Register ettik simdide bir tane accesstoken uretmek istiyorum...
            var user = registerResult.Data;
            var tokenResult = _authService.CreateAccessToken(user);
            //Biz kullanicya sadece token donecegiz...
            if (tokenResult.Success)
            {
                return Ok(tokenResult.Data);
            }
            return BadRequest(tokenResult.Message);



        }

    }
}
