using Business.Abstract;
using Entities.Concrete.Dtos;
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
    {//Burda herzaman yaptiimiz gibi IAuthService yi dependency injection almamiz gerekiyor
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]//Post olacak cunku kullanici bize bir bilgi gonderecek ve biz o bilgi vasitasiyla
                  //kayit islemi yapacagiz

        public IActionResult Login(UserForLoginDto userForLoginDto)
        {//Once kullaniciyi kontrol edelim..kullaniciyi login etmeye calisiyoruz
            //Once maili kontrol ediyor problem varsa error,sonra sifreyi kontrol ediyor onda da
            //hata yoksa 
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)//Basarili degilse yani email veya passwordu bulamazsa
            {
                return BadRequest(userToLogin.Message);
            }
            //Eger buraya geldi ise demekki login olmus
            //Islem basarili ise bize bir userToCheck veri olarak user donuyordu
            //yani userToCheck.Data bir userdir
           var result= _authService.CreateAccessToken(userToLogin.Data);
            //CreateAccessToken icerisine bir user verince bize bir accessToken donuyordu
            //yani result bir accessToken oalrak donecek..
            //Simdi de bu islem basarili mi ona bakalim...
            if (result.Success)
            {
                return Ok(result.Data);//Success ise problem yok kullanicya accesstoken i ver...
            }
            return BadRequest(result.Message);
            //Biz AuthManager da basarisiz olma durumunda birsey yazmamisiz ama onu da zamanla
            //gelistirme isini dusunmeliyiz...
        }

        //----Login operasyonumuzu yadik sirada ise register olayi var....
        [HttpPost("register")]

        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            //Once kayit olma durumudna kullanici var mi diye onu kontrol et...
            var userExist = _authService.UserExist(userForRegisterDto.Email);
            if (!userExist.Success)//!userExist.Success kullanici var kayit olamaz demek
            {//Amacimz gelen sonuca gore request in ne oldugunu gostermeye calismak
                //Yani api tarafinda nasil bir sonuc donecegimize karar veriyoruz ve burda api kodu
                //yaziyoruz yoksa burda business kodu yazmiyoruz....
                return BadRequest(userExist.Message);
            }
            //Demekki kullanici kaytli degil  buraya geldi ise kod..
            var registerResult = _authService.Register(userForRegisterDto,userForRegisterDto.Password);
            //Kullanici Register ettik simdide bir tane accesstoken uretmek istiyorum...
            //Register sonunda da yine veri olarak bir user donmusuz buna dikkat edelimm..
            //Yani registerResult.Data bir user dir
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);//Token i veriyoruz bur da da
            }
            return BadRequest(result.Message);

        }

    }
}
