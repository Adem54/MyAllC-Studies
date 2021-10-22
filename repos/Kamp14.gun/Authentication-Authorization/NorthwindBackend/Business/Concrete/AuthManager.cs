using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.jwt;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {//Nelere ihtiyacimiz var soyle dusunleim bize IAuthService den gelen operasyonlarin parametrele
        //rine de bakacak olursak o zaman ne lazm bize bir kere IUserService ye ihtiyacimiz var
        //Cunku kullaniciyi bizim kontrol etmemiz gerekiyor mesela veri tabaninda var mi
        //Biz IUserService de kullanicin emailini getirme,kullanicin rollerini getirme ve
        //kullanici ekleme olaylarini yapiyorduk dolayisi ile bize ozellikle kullanici emaili
        //ve kullanici claim lerini getirme operasyonlari burda gerekli!!!!!!
        //Birde bizim ITokenHelper a yani jwtHelper a ihtiyacimiz var cunku token urtme isini
        //biz burda yapmistik dolayisi ile burdaki token verme olayinda bize ITokenHelper lazm...

        //Dependency injection  ile IUserService ye ulasabilriz

        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        //Birde token uretecektik kullanici login oldugunda ona token verecektik
        //Bu da bizim token ureten nesnemiz olan JwtHelper in implement ettigi ITokenHelper interface
        //ni dependency injection ile buraya alacagiz...


        //Simdide AccessToken islemini yapalim
        //Front-end te kayitli olan kisinin login yani kayit oolduktan sonra bizden bir token
        //alacak ve artik islemlerini o token araciligi ile yapacak!!!
        //Bu token i biz _tokenHelper dan alacagiz...
        //------------------ONEMLI-----------------------------------
        //Ezbere kod yazmayalim kullancagimiz gerek hazir nesneler olur gerekse kendi yazdik
        //larimiz olur onlarin once bi ustune maus ile gidip okumaya calisalim ne gibi
        //mesajlar dis tarafa geliyor ve parametre de ne istiyor veri turu nedir
        //gibi kontrolleri yapip nesne ile konusmaya calisalim
        //
        public IDataResult<AccessToken> CreateAccessToken(UserTest user)
        {
          var claims=_userService.GetClaims(user);
          var accessToken=  _tokenHelper.CreateToken(user, claims);
            //accessToken i olusturduk simdi dondurelimmm
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<UserTest> Login(UserForLoginDto userForLoginDto)
        {
            //Login isleminde oncelikle bu kullanici var mi veritabanindan kontrol ederiz..
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            //userToCheck bir user dir user email i degil yani userToCheck userinden passworde de
            //o user in email ine de erisebilirixz...
            //userForLoginDto dan gelen email su an login olmak isteyen kullanicinin emailidir
            //Biz bu emaili eger _userService.GetByEmail e verirsek o zaman bu zaten ne yapiyordu
            //gidip veritabaninda bu email var mi onu kontrol edip o email e sahip olan 
            //user in detayli bilgilerini bize getirmeye yariyordu yani biz bu yazdimigiz olay ile
            //login yapmak isteyen kullaniciyi kontrol etmis oluyoruz...
            //Burda da direk null mi degil mi onu da kontrol edebiiliriz veya Any ile de var ligi
            //kontrol edilebilir
            if (userToCheck==null)//Boyle bir kullanici yok ise
            {
                return new ErrorDataResult<UserTest>(Messages.UserNotFound);
            }
            //----------------------Burayi gecerse kullanici var demektir!!!!!!!!-----------
            //Ikinci asamada buraya geliyorsak kullanici var demektir.Kullanici bize password u 
            //buraya acik acik gonderiyor biz ise bu kullanicinin gonderdigi passwordu daha once
            //onun icin olusturdugumuz hash ve salt vasitasyla gelen passwordun hash i ile
            //veritabanndaki hash ayni mi bunu kontrol edecegiz..
            //Gonderilen sifreyi  hash ile beraber kontrol eden biroperasyon yapalim....
            //Simdi biz burda gelen passwordu direk hashleyip ve salt layip islemimizi yapabiliriz
            //Ama bunu yapmak yerine biz daha kurumsal olmasi icin bir tane hashhelper yazalim
            //Ve hashhelper i ne zaman bir passwordun hash ini bulacaksak o zaman kullanabiliriz
            //Ve artik tum projelerimizde de kullanabilriz
            //Neye ne zaman ihtiyacimi varsa o zaman yaziyoruz ezbere yapmiyoruz
            //Buna intentional programmering-niyet ederek kod yazma
            //Core altinda Utilities altinddaki Security altina Hashing adli bir klasor olustururuz
            //Ve hashing klasorumuzun altina da bir adet HashingHelper.cs adli nesne olustururuz
            //Sonra da onu burda direk o nesneden alip kullanacgiz....
            //----------------HashingHelper nesnemizi hazirladik ve devam ediyoruz------
            //userToCheck artik kullanici cek edilmis ve veritabaninda verileri var olan
            //kullancii nesnesi demektir yani biz artik kullanicya ait tim propertieslere 
            //ulasiyoruz bu userToCheck tarafindan demektir ve ondan dolayi biz
            //userToCheck.PasswordHash e ulasabiliriz...
            //--------userToCheck demek bir user detayi demektir yani bir UserTest nesnesinin
            //bir instancesidir yani bir user dir yani kullanicinin email ve passwordu veritabaninda
            //kontrol edildikten sonra bize kullanici bilgilerini userToCheck adi ile donuyor...
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,
                userToCheck.PasswordHash, userToCheck.PasswordSalt))//Bu eslesmiyor ise...
            {
                return new ErrorDataResult<UserTest>(Messages.PasswordError);
            }
            //----Burayi gecerse de sifresi de dogru demektir--------------------------

            //Kullaniciya biz peki mail in bulunamadigini donduruyoruz direk yani 
            //yani kotuye kullanmak isteyen birisi mailin hatali oldugunu gorecek direk
            //Ama back-end in gorevi degil o back-end in gorevi ne olduysa onu dondurmek...
            //Arayuz gelistiricisi front-end ci bu mesaj geldiginde bunlara ortak bir mesaj 
            //gosterebilir...Bu front-end cinin yapacagi calismadir
            //Biz apiden ona gecek sonucu vermek zorundayiz...
            //Business de olay hakkaten ne olduysa onu gormektir bu belki api de tekrar 
            //degerlendirilebilir ama business da bu boyle olmalidr
            //-----Hem kullanici var , hemde sifresi dogru ise o zaman kullaniciyi dondur-----
            return new SuccessDataResult<UserTest>(userToCheck, Messages.SuccessfullLogin);
            //Data olarak userToCheck demek bir user nesnesi demektir yani kullanicinin bilgileridir
            //userToCheck


        }//Login islemimiz tamamdir su anda!!!!!!!


        //Login islemini bitirdik simdi ise Register islemini de gerceklestirelim
        //Islemi bitirdikten sonra elimizde zaten 1 tane passwordHash ve passwordSalt olusacak
     //Zaten daha once biz HashingHelper vasitasiyla gonderdigimiz bir sifrenin hash ve salt inin
     //bize donmesini bekliyoruz...
     //Burda passwordu ayrica gondermemize gerek yokmus aslinda onu bir daha dusunelim cunku
     //userForRegisterDto nun icinden de direk kulllanabilriz...
        public IDataResult<UserTest> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            //Kullanici kayit olurken bize firstName,LastName,Email ve sifre gonderiyor
            //Kullanici tarafindan kayit esnasinda gonderilen sifrenin biz passwordHash ve 
            //passwordSalt diye bize HashingHelper vasitasyla dondurulmesini bekliyoruz.
            //Biz onu out keywordu ile yazmistik!!!!
            //passwordHash ve passwordSalt bizim icin birer byte array dir unutmauyalimmm..

            //ONEMLI HARIKA BIR ORNEK...OUT KULLANIMINA!!!!
            //out burda ne yapiyor hemen gorelim...biz passwordHash,passwordSalt i bos gonderiyoruz
            //Ama onlar HashingHelper.CreatePassword icinde yeni deger aliyorlar...ve 
            //out ile onlari biz referans turune cevirdgimiz icin dogal oalrak bu ilk basta
            //degisken olarak atadigimiz byte array ler ama deger atamadiklarimiz da
            //method icinde hangi deger verildiyse ona esit oluyor cunku referanslari ayni....
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            //HashingHelper.CreatePasswordHash ile passwordHash ve passwordSalt olusmus oluyor

            //bu noktada bizim userService vasitasi ile ekleme islemine ihtiyacimiz var...
            //user in verilerini atiyoruz burda bu ornegi cok iyi mantigina yatir cunku biz resim ekleme islemleirnide yaparken
            //Businesss conrete icinde property nesnesinin verilerini atamistik!!!!Dikkat bu onemli!!Hersey boyle ezbere 
            //gibi yapilmaz.Isin mantigi kavranmali!!!
            //Bos bir tane user olusturup icine kayit olmaya calisan kullanicidan Email,FirstName,LastName
            var user = new UserTest
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true//Biz kayit oldugu icin status u true veririz ancak bu status sizin olaya bakis aciniz ve mantiginiza
                //gore degisebilir ornegin ilk etapta false verip email den dogrulama istersiniz dogrulayinca status true yaparsiniz
                //Veya birinin manuel olarak onaylamasi gerekir onu bir calisan veya yonetici manuel olarak onaylar ve true
                //haline getirir biz burdan false verirsek o zamanda true yaparlar bu orneklerdeki gibi sistemlerde mevcuttur...

            };
            _userService.Add(user);
            return new SuccessDataResult<UserTest>(user, Messages.UserRegistered);
           
        }

        //Kullanicinin emaili veritabanimizda, sistemimizde olup olmadigini kontrol edelim...
        //email kisilere ozgu old icin biz kullanicinin gelen emailinden sorgulayip varsa
        //o kullaniciyi donruyordu. Eger kullanici varsa error, yoksa success don diyoruz
      
        public IResult UserExist(string email)
        {
            if (_userService.GetByEmail(email)!=null)//Boyle bir kullanici varsa 
                //hata mesaji doneceegiz sen zaten kayitlisin diye....
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();//Birsey donmeye gerek yok...
        }
    }
}
