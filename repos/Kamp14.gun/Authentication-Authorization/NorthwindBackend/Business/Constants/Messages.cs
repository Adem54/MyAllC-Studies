using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

//Magic String demek dogrudan mesaji string olarak vermek demek bunun yerine biz bu sekilde
//static bir method icine yazariz

namespace Business.Constants
{
  public static  class Messages
    {
        public static string ProductAdded="Urun basari ile eklendi";
        public static string ProductDeleted = "Urun basari ile silindi";
        public static string ProductUpdated = "Urun basari ile guncellendi";
        public static string CategoryAdded = "Kategori eklendi";
        public static string CategoryDeleted="Kategori silindi";
        public static string CategoryUpdated="Kategori guncellendi";
        public static string CategoryDetailListed="Kategori detayi listelendi";
        public static string CategoriesListed="Kategori listelendi";

        public static string UserNotFound="Kullanici bulunamadi";
        public static string PasswordError="Sifre hatali";
        public static string SuccessfullLogin="Sisteme giris basarili";
        public static string UserAlreadyExist="Kullanici zaten mevcut!";
        public static string UserRegistered="Kullanici basari ile kaydedildi";
        public static string AccessTokenCreated="AccessToken olusturuldu!";
        public static string AuthorizationDenied= "Yetkiniz bulunmamaktadir";
        public static string ProductNameAlreadyExist="Urun ismi zaten mevcut";
    }
}
//Burda cok dil destegi de ayarlanabilir ornegin bir property olusturulup get blogunda
//secili dile gore karsiligini veritabanindan getirebiliriz...
//Mesajlari biz gruplarina gore klasorleyebiliriz...
//Bu mesajlar apimizde veya apimzden sonra da front-end tarafinda kullanilabilir istenilirse...