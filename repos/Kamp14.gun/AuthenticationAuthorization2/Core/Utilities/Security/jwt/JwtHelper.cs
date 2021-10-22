using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace Core.Utilities.Security.jwt
{
    public class JwtHelper : ITokenHelper
    {
        IConfiguration Configuration { get; }

        private TokenOptions _tokenOptions;

        //TokenOptions da accessTokenExpiration int veri tipi ile dakika cinsinden yazilmisti
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //GetSection("TokenOptions")=>appsetting.sjon daki "TokenOptions" blogudur
            //Get<TokenOptions>() bu ise bizim olusturudugmuz TokenOptions property nesnemizdir
            //IConfiguration vasitasi ile bu ikisini bind ettik eslestirdik ve verileri _tokenOptions a 
            //aktardik yani nesnemize verileri aktardik artik o verilere _tokenOptions nesne instancemiz uzerinden
            //erisebiliriz.Zaten TokenOptions.cs nesnemizi olusturma sebebimiz de buydu....
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            //TokenOptions icerisinde minutes olarak verilen token gecerlilik suresini AccessTokenExpiration
            //i DateTime a ceviririz...Cunku jwttoken uretirken bize datetime olarak lazm olacak..

        }
        public AccessToken CreateToken(User user,List<OperationClaim> operationClaims)
        {
            //Algoritmali,kriptolu veya sifreli bir securityKey olusturma
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            //Imzalama islemi
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            //public JwtSecurityToken CreateJwtSecurityToken bu operasyonu asagida yazdigmiza gore
            //artik  burda bir jwt uretebiliriz..
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            //Artik elimizde bir JsonWebToken mevcut!!
            //JwtSecurityTokenHandler nesnesini kullanarak elimizdeki token bilgisini yazdiracagiz..
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            //Elimizdeki token nesnesini WriteToken ile stringe cevirdik..
            return new AccessToken()
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }
        //Simdi token uretme operasyonu yazacagiz...
        //JwtSecurityToken turunde olacak bu tur System.IdentityModel.Tokens.Jwt den gelir
        //Bu paketi yukleriz
        //SigningCredentials parametresi Microsoft.IdentityModel.Tokens dan gelir...
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user,
                SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
            {
                var jwt = new JwtSecurityToken(
                    issuer:tokenOptions.Issuer,
                    audience:tokenOptions.Audience,
                    expires:_accessTokenExpiration,
                    notBefore:DateTime.Now,

                    claims:SetClaims(user,operationClaims),
                  //IEnumerable<Claim> turunde claims leri almamiz lazm onun icin asagida bir tane
                  //IEnumerable<Claim> turunde bir SetClaims olustururuz ve parametreye user ve 
                  //OperationClaim koyariz.Bizde sadece operationClaim var o da bizim isimizi tam
                  //olarak gormuyor...
                    signingCredentials:signingCredentials

                    );
                return jwt;
            }
            //Bu System.IdentityModel.Tokens.Jwt den gelen JwtSecurityToken in constructor larindan
            //bir tanesidir ve token uretilirken burayi kullaniriz.....
            //public JwtSecurityToken(string issuer = null, string audience = null,
            //IEnumerable<Claim> claims = null, DateTime? notBefore = null,
            //DateTime? expires = null, SigningCredentials signingCredentials = null);
            //claims uzerine gelince diyorki IEnumerable


            private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
            {
                var claims = new List<Claim>();//Claims lerimizi yazacagiz..
                //Biz claims.AddEmail seklinde yazmak istiyoruz ama claims de o methodlar yok
                //claims bir System.Security.Claims gelen bir Claims nesnesi listesidir
                //Ama bizim istedigimiz nesneler icinde yok.Biz de o zaman bu .net nesnesine 
                //extension yazariz kullanabilmek icin...
                //Claim ekleme yontemidir
                //claims.Add(new Claim("email", user.Email));
                //ClaimExtensions.cs dosyasinda biz ICollection<Claim> claims e ihtiyacimiz olan 
                //methodlari da ekledigimize gore devam edebiliriz....
                //ClaimExtensions.cs extension i ile extend ettigimiz methodlari gormek icin
                //using Core.Extensions; yukari eklemeliyiz.....
            claims.AddNameIdentifier(user.Id.ToString());//claims in  methodunda string hersey
            //ondan dolayi stringe cevirmemiz gerekiyor
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName}{user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            //En son array e cevrilir cunku AddRoles methodunda parametre array turundedir...

            return claims;               
            }


        }
    }

