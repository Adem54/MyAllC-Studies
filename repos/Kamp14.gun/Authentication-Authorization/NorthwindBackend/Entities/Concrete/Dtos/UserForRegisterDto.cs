using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Dtos
{//Herhangi bir kullanici register olmak istedigi zmaan bu verilerle gelecek bize....
   public class UserForRegisterDto:IDto
    {  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}
//Biz passwordu byte array diye degil PasswordhHash ve PasswordSalt ta oldugu gibi,
//string diye tutuyoruz burda cunku password u biz kullanicidan string olarak alacagiz
//Biz onu hasha cevirip bir de tuzlayip veritabani ile kontrol edecegiz....
//Veritabaninda boyle bir password
//geldigi gibi tutmak guvenli olmadigi icin zaten biz gelen veri tabanini oldugu gibi
//tutmuyoruz veritabaninda...ONEMLI!!!!!
//Password bizim herhang bir property nesnelerimizde mevcut degil..
//Bizim password e ihtiyacimiz var o zaman bu sekilde aliriz..
//Ama password un kullanicidan geldigi gibi veritabaninda olmamasi lazm
//NEDEN DTO OLUSTURURUZ
//Dolayisi ile biz Dto yu ornegin elde etmek istedigimiz belli properties ler var ama
//ornegin istedigimiz properties lerden biri diyelim ki bir tablo da digeri baska tabloda 
//bu durumlarda da dto olustururuz ve join ile hallederiz ya da aradgimiz propertieslerden
//biri bir tablo da ama digeri hicbir tabloda yok onu da Dto property nesnesinde olustururuz