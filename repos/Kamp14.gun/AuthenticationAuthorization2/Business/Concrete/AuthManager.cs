using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper; 
        }
        //Biz burda kullaniciya kayti olduktan sonra ve login olduktan sonra bir token bilgisi verecegiz
        //Ve kullanici o token bilgisi ile belli kaynaklara erisecek
        //Ve biz token olusturma islemlerimizi ITokenHelper i implement eden JwtHelper da yapmistik
      
     //Token olusturma islemini biz hem RegisterApisinde hem de Login apisinde kullanici kayit oldugu
     //ve login oldugu durumlarda kullaniciya bir token vermek icin kullanacagiz...
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);//Veritabaninda OperationClaims tablosundaki
            //claim ler buraya gelecek
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {    //Login isleminde oncelikle bu kullanici var mi veritabanindan kontrol ederiz..
            var userCheck = _userService.GetByEmail(userForLoginDto.Email);

            if (userCheck==null)//Login olmaya calisan kullanici sistemde yok ise demek
                //usesrCheck bir user dir bir kullanicidr ve email ve password onun propertiesleridir
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            //Eger kod buraya gelirse demekki bu kullanici sisteme kayit li o zaman surec devam eder
            //Ve bizim simdi de bu kullanicinn password unu kontrol etmemiz gerekir
            //Biz kullanici paswword lerini hashing ve salting islemlerinden gecirerek veritabanina
            //gonderdik yani veritabaninda sifreler hashlenmis ve saltlanmis sekilde duruyor
            //Dolayisi ile bizim login olmak isteyen kullanicidan gelen sifreyi de hashing ve salting
            //islemlerinden gecirmemiz gerkiyor ki ondan sonra veritabaninda sorgulayabilelim
            //Biz hahsing ve salting islemlerini yine projemizin daha kurumsal ve sistematik olmasi
            //icin Core icinde Utilities de Security altinda Hashing klasoru olusturup icinde de
            // HashingHelper.cs de hashing ve salting islemlerimzi yapariz ve sonra da burda o
            // nesneyi kullaniriiz...
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userCheck.PasswordHash,
                userCheck.PasswordSalt)) 
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            //userCheck veritabaninda var olan kullanicidir ve userCheck.PasswordHash ve
            //uerCheck.PasswordSalt use veritabanimizda sorgulayip buldgumuz login olmak isteyen
            //kullanicinin passwordHash ve passwordSalt idir biz bu VerifyPasswordHash islemi icinde
            //gelen password uzerinden hash leme islemi yaparak gelen password un hashli durmunu aliriz
            //Ama zaten once salt isleminden geciriyoruz sonra da hash islemi yapiyoruz vve bu sekilde
            //biz gelen passwor un hash islemini sonlandiriyoruz ve son ne yapiyoruz
            //Gelen password uzerinden urettigimiz hash(hash zaten salt prosedurunden gectikten sonra)
            //olustugu icin ekstra salt da demiiyoruz zaten hash deyince salt edilmis oldugu anlasilmalidir
            //ile veritabaninda buldugumuz user in hash ine ulasiriz ve ikisni karsilastiririz.... 
            return new SuccessDataResult<User>(userCheck, Messages.SuccesfulLogin);
            //Sonunda user donuyor!!!!!!

        }

        //FirstName,LastName,Email ve password u ile gelen kullancinin passwordunu hashing ve salting
        //islemlerinden gecirdikten sonra kulanicin nesnesinin tum propertieslerii set edecegiz
        //Ardindan da user nesnesinin tum proepertieslerinin atanmis yani set edilmis halini
        //veritabanina kaydedecgiz...
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            //Once Token Olustururuz...
            string password = userForRegisterDto.Password;
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            //-----OUT GERCEK HAYAT KULLANIMI--------------------------
            //------------Iste out kullaniminin gercek  hayat ornegi..Harika!!!
            //Disarda olusturdugun bir degisken parametrede ayni desiken ismi ile basina out yazarak
            //verirsen artik o bir parametre elemani olmanin otesine gecer ve parametre olarak verilen
            //method icinde o parametreler uzerinde yapilacak her turlu degisiklik disarda iken 
            //olusturdugun degiskenlere yansiyacaktir...Iste referans tip olmak boyle birsey
            //out ile biz primativ bir tipi referans tipi yapabiliyoruz ve method bittikten sonra
            //Disarda null olan passwordHash ve passwordSalt CreatePasswordHash methduna parametre
            //olarak girdikten sonra artik yeni bir passwordHash ve passwordSalt oluyorlar
            //Artik null degiller!!!!
           //Sonra User olustururuz ve Veritabanina kaydederiz....
           //Ama elimizde direk veirtabanina kaydedecek sekilde bir user olmadigi icin o zaman
           //ne yapariz gelip kendimiz business da veritabanina kaydedecegimiz sekli ile bir nesne
           //olusturma isini tamamlariz....asagidaki gibi...
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };//BURASI COK DIKKATE DEGER BIZ HERHANGI BIR GELEN KULLANICIYI KAYIT OPERASYONU 
            //DATAACCESS LAYER DE YAZMADIK AMA BU OZEL BIR PROCESS ONDAN YAZMADIK.AMA DIKKAT EDELIM
            //BIZ BUSINESS DE YAZIYORUZ BUNU...VE VERITABANINA ADD IDYE EKLIYROZ.....
            //RESIM EKLEME ISLEMINDE DE BUNA BENZER SEYLER YAPMISTIK HEP.....
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);

        }

        //Bu da kullanicnin varligini sorgulayacagimiz methodumuz burasi
        //Biz kullanici varligini nasil sorguluyorduk once kullanici emaili uzerinden
       //Bunu biz Api tarafinda Register apisinde kullanacagiz...
      
        public IResult UserExist(string email)
        {
            if (_userService.GetByEmail(email)!=null)//Boyle bir kullanici varsa o zaman sen zaten kayit
                //lisin diye hata mesaji gonderecegiz...Bunu biz Api tarafinda register isleminde
                //kayit olmak isteyen kullaniciyi ilk once varligini sorgulayacagiz cunku kayti olmak
                //isteyen kullanici daha onceden zaten kayitli ise sen kayit olamazsin zaten kayitlisin
                //diye mesaj doneriz....
            {
                return new ErrorResult(Messages.UserAlreadyRegistered);
            }
            return new SuccessResult();
        }
    }
}
