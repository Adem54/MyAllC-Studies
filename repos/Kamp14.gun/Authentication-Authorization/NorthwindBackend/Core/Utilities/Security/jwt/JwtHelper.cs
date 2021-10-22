using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.jwt
{
    public class JwtHelper : ITokenHelper
    {//Burda yapacagimiz islem tokenoptions u okumak olacak konfigurasyon dosyasindan 
        //yani webApi deki appsetting dosyasindan tokenoptions olari burda
        //okumasini saglayacagiz
        //Konfiurasyon dosyasini  okuyacagiz
        //Konfigurasyon dosyasi icin gerekli olan altyapiyi web-api tarafinda gerceklestirecegiz
        //appsettings de
        //IConfiguration Microsoft.Extensions.Configuration  yani ben yarin oburgun web api icin
        //degil baska bir ortam icinde ayni konfigurasyon altyapisini kullanabiliyor olacagim..
        public IConfiguration Configuration { get; }
        //Biz token options i burdaki nesnemiz uzerinden okuyacagiz onun icin burasi
        //readonly olacak!!!
        //property dependency injection olacak burda cunku dosya okuyacagiz...
        //Configuration vasitasiyla tokenoptions a gelen bilgileri okuyacagiz..
        //webAPI deki appsetting deki bilgiyi biz configuration yapisi ile okuyacagiz...
        //Dolayisi ile bize bir tane tokenoptions lazim onu da yine dependency injection
        //yontemi ile alirz
        //appsetting de ki bizim TokenOptions alanimizi biz TokenOptoins nesnesine aktaracagiz
        private TokenOptions _tokenOptions;
        private DateTime accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)//Biz bu IConfiguration kullanimini
                                                      //Startup.cs de konfigurasyonunu yapacgiz...unutmayalim
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            
            //minutes cinsindden int ile verdigimiz AccessTokenExpiration i tarih tipine ceviriyoruz
            //Konfigurasyondan yani appsetting den section lardan TokenOptions adli 
            //bolumu oku ve .Get nesnesi ile <TokenOptions> nesnesine bind et diyoruz yani ona aktar
            //Otomatikmen .net appsettings dekin TokenOptions bolumundeki bilgileri alip
            //<TokenOptions> nesnesine bind ediyor dolayisi ile artik elimizde appsetting deki
            //TokenOptions bilgilerini iceren bir nesne elde etmis oluyoruz burda...
            //Burda .Get in de gelmesi icn Microsoft.Extensions.Configuration.Binder i kurmammiz gerekir
            //Yani burda tek tek GetSection.Audience,GetSection.Issues demek yerine bir kerede 
            //bu yontemle tum json blogunu TokenOptions nesnesine bind ediyoruz
            //Artik CreateToken islemini yapacagiz bundan sonra...
            //---------------------------------------------------------
        }
        public AccessToken CreateToken(UserTest user, List<OperationClaimTest> operationClaimsTest)
        {//Token olusturuken bize cesitli bilgiler lazm olacak bunlardan bir tanesi securityKeydir
         //SecurityKey su anlama geliyor biz bir algoritma kullanarak kendimize bir tane token olusturacagiz
         //sifreli bir token olusturacagiz yani encript edecegiz.O token i encript ederken bir tane anahtara 
         //ihtiyacimiz var kendi bildigmiz ozel bir anahtara ihtiyacimiz var ondan dolayi bir tane security key
         //olusturacagiz..
         //Bu noktada bize bir tane daha paket lazim Microsoft.IdentityModel.Tokens adli onun sayesinde
         //securityKey i olusturabilecegiz...
         //Iste token olusturma olayimiz Microsoft.IdentityModel.Tokens adli paket ile biz algoritmali token i olusturuz

            accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            //_tokenOptions daki SecurityKey i kullanarak bana bir tane securityKey oolustur
            //demis oluyoruz yani token olusturma islemini bu sekilde yapiyoruz....
            //Bunu herseferimde projelerimde kullanabilirim cunku cok genel bir yapi
            //Onun icin Security klasoru altina bir tane de Encription adli bir klasor ekleriz
            //Encryption icerisine SecurityKeyHelper adli bir nesne olusturacagiz..
            //Encryption da yazdigimiz SecurityKeyHelper dan once su sekilde yazmistik...
            //new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            //Ama bunu artik biz SecurityKeyHelper da yazdik ve buraya ordan cagirdik...
            //-------------------------------------------------------------------

            //Artik bir sonraki asamaya gecelim.Bir sonraki asama jsonwebtoken da SigningCredential
            //nesnesi yazacagiz onu da burda yazabilirz normalde ama biz projemizi kurumsal ve
            //global tum projelerde kullanilmasini istiyoruz onun icin onu da yine Encryption altina
            //yazacagiz...
            //SigningCredentialsHelper nesnesi ile signinCredentials algoritmali imza islemimizi
            //de ayri bir nesne haline getirdigimize gore artik burda devam ediyoruz...
            var signingCredentails = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            //---Bir alttaki JwtSecurityToken tipinde CreateJwtSecurityToken operasyonu ile
            //token uretme methodunu nu da bitirdikten sonra devam ediyoruz
            //Cunku bizim simdi yapacagimiz islemde CreateJwtSecurityToken ile yapacagiz
            //CreateToken a devam ediyoruz
            //CreateJwtSecurityToken=>Bize jsonwebtoken uretiyor
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentails, operationClaimsTest);
            //CreateJwtSecurityToken in parametrelerini yolladiktan sonra artik CreateJwtSecurityTokenin
            //donderdigi bir jsonwebtoken imiz mevcuttur
            //Elimizde token mevcut ama bu tokeni bizim bir handler vasitasi ile elimizdeki bilgilere
            //gore yaziyor olmamiz gerekkiyor
            //IdentityModel dan gelen JwtSecurityTokenHandler vasitasi ile bu isi yapacagiz
            //JwtSecurityTokenHandler nesnesini kullanarak elimizdeki token bilgisini yazdiracagiz..
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            //Elimizdeki token nesnesini biz WriteToken ile stringe cevirdik....
            //Burasi da tamam oldu artik bizim bir tane accesstoken dondurmemiz gerekiyor
            return new AccessToken()
            {//Token imiz stringe cevirdigimiz token 
                Token = token,
                Expiration = accessTokenExpiration
            };
            //Bu sekilde biz bir accesstoken uretecek operasyonu da yazmis olduk.....
            //-------------------------------------------------
        }
        //------------------------------------------------------------------------------------
        //Yeni bir asamaya geciyoruz
        //Simdi biz elimizdeki bilgileri kullanarak TokenOptions bilgileri _tokenOptions dan 
        //alabilriz artik,kullanci bilgilerini yani user bilgileri,signincredentials bilgilerine ve birde kullanicinin
        //claims leri yani rollerine ihtiyacimiz var.Bunlari kullanarak bir adet token olusturmak
        //istiyoruz...Yani kisacasi hangi token bilgileri,hangi kullanici icin,
        //hangi signinCredentials ile ve hangi rolleri iceriyorsa bunlari parametre olarak verip
        //bir adet token uretiyor olacagiz...
        //Zaten biz jwtHelper ,tokenHelper icindeyiz bu operasyonu da burya yazabiliriz...
        //JwtSecurityToken donduren bir operasyon yazacagiz...bu System.IdentityMode.Tokens.jwt
        //paketinden gelecektir ondan dolayi bu paketi Core altinda kurariz..
        //Bu parametrelerle operasyonumuzu yazacagız..
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, UserTest user,
            SigningCredentials signingCredentials, List<OperationClaimTest> operationClaimTests)
        {
            //JwtSecurityToken=>System.IdentityModel.Tokens.Jwt dan gelir
            //JwtSecurityToken uzerine gelirsek bizden neler istedigini ve ne amacla kullanildignini
            //anlayabiliriz..
            //Uzerine gelirsek bizden parametre olarak audience,issuer ..istedgini gorebiliriz..
            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                // expires: _tokenOptions.AccessTokenExpiration,//Bu dakika cinsinden old icin
                //bunu tarih cinsine yukarda donusturduk..
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                //Token in expiration bilgisi su andan once ise gecerli
                //degil diyoruz sartimiz o
                claims: SetClaims(user, operationClaimTests),
                //claims uzerine gelirsek bize bunlarin IEnumerable<Claim> turunde olmasi gerektigini soyluyor
                //ama bizim turumuz kendi urettigimiz operationClaimTest turudur
                //Burda IEnumerable<Claim> turunde kullanicinin rolu claim ini istiyor 
                //Biz de alt tarafta IEnumerable<Claim> turunde SetClaims adinda bir operasyon yazariz...
                //IEnumerable Claim dondurmemmizi bekliyor bizden claim..uzerine gelince goruruz
                signingCredentials: signingCredentials
                 );
            return jwt;
            //Bunlar jsonwebtoken in bize lazim olan kismlaridir
            //Burda biz accesstokenexpiration i token larda dakika olarak tutmustuk int ile
            //Bizim AccessTokenExpiration i tarih tipini cevirmemiz gerekiyor
            //Bu islemi de en usste methodlarin ustunde olustururuz ve constructor da
            //geceriz ki ki bircok yerde kullanabilelim
            //diye private Datetime accessTokenExpiration
            // private DateTime accessTokenExpiration;
            //  accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        //Bu operasyonu biz yukardaki JwtSecurityToken olustururken claims uzerinde bize 
        //IEnumerable<Claim> donecek diyor 
        //Claim security.claims den gelir ordan cozeriz..
        private IEnumerable<Claim> SetClaims(UserTest user, List<OperationClaimTest> operationClaims)
        {
            var claims = new List<Claim>();
            //Simdi claim leri ekleyelim
            //Burda Email eklemek istiyoruz claims.AddEmail sklinde ama biz asagidaki gibi de 
            //yapabiliriz normalde ama herseferinde o sekilde yapmak istemiyoruz onun icin
            //biz eklyecegimiz AddEmail gibi seyleri extend edecegiz yani extention yazacagiz
            //bir .Net nesnesi
            //icerisine normalde asagidaki gibi de yazabiliriz ama her seferinde bu sekilde yazmak
            //istemiyoruz.Asagidaki gibi yazmak bizi ilerde skntiya sokar cunku magic string yazi
            //yoruz
            //claims.Add(new Claim("email", user.Email)); bu sekilde yapmak istemiyoruz
            //CLAIM NESNESINI EXTEND ETMEK-EXTENSION EKLEMEK
            //Claim nesnesini extend edecegiz
            //Elimizde bir Claim kolleksiyonu var biz ona yeni methodlar ekleyebilriz
            //Burda bir acidan da amac aslinda bizim zor kaldigimiz veya cok ihtiyac duydyugumuz
            //durumlarda extension yazabilmeyi ogrenmek cok onemlidir bu kismi cok iyi ogrenmeliyiz
            //Bu seviye cok ileri C# tekniklerindendir...
            //Core tarafinda geliriz Core tarafinda bir tane Extensions adinda klasoru olustururuz
            //Extend edecegimiz nesneleri bunun icine koyacagiz.Extend etmek demek bir class i
            //genisletmek demektir.Elimizde hali hazir da bir tane Claim nesnesii var biz onu
            //gelistirecegiz
            //Extensions klasoru icerisine ClaimExtensions adli bir nesne ekleriz...ve tum
            //extensions lari bunun icerisine koyazir..
            //Bunun extension olmasi icin static olusturuyoruz
            //-------------------------Eklentilerimizi olusturduktan sonra devam edelim-----
            //using e Extensions klasorundeki ClaimExtensions.cs yi eklersek artik eklentilerimiizi
            //claims den alabiliiriz
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName}{user.LastName}");
            //Rol olarak bir stringarray yollamam gerekiyor ama elimde operationclaimtest var
            //operationClaim de zaten collection, generic collecton list o zaman 

            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            //Bu bir liste collection,Icollection
             //onun icin en son da arraya ceviririz ToArray() ile
            return claims;

            //SetClaims islemimizde bittigine gore biz bu SetClaim islemini CreateJwtToken icindeki
            //claims icin yapmistik simdi artik claims:karsinia SetClaims imizi yazabiliriz
        }

    }
}
