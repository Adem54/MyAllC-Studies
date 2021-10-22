using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //ProductValidator un bir Validator olabilmesi icin FluentValidaton dan gelen AbstractValidator den
    //inherit edilmesi gerekiyor
    //FluentValidaton paketini nugetpackages den yukleriz...
    //FluentValidaton pektini nasil kullaniriz konusunda dokumentasyonundan da gidebiliriz...
    //Dokumantasyon okumaya alismaliyiz...
    //FluentValidation i bir constructor vasitasi ile devreye sokabiliyoruz...
   public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            // RuleFor(p => p.ProductName).NotEmpty().Length(2, 30);//Bos olamaz ve en az 2 karakter
            //en fazla da 30 karakter olsun diyoruz
            //Biz boyle de yazabiliriz ama bizim single responsibility prensibimize ters oldugu
            //icin biz ayri ayri yazmayi tercih ederiz NotEmpty yi bir satirda Length(2,30) alt satir
            //da yazmayi tercih ederiz
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("ProductName musn't be empty");
            RuleFor(p => p.ProductName).Length(2,30);
            //Biz bu yazdigimiz kurallarin ardina istersek kendimize ozel bir hata mesaji yazariz
            //Istersek de birsey yazmayiz FluentValidation kendi icinde default olan mesajini kullanirizi
            //Iste NotEmpty ile Length i yanyana yazmama sebebimiz de bunun gibi seyler yani
            //ikisini yanyna yazarsak her ikisinin mesajini birden mi yazacagiz dolaysii ile 
            //SOLID e ters oluyor.Single Responsibility
            //Tabi bu arada kendimiz direk string mesej yazmak tehlikelidir magic string dedigimiz
            //sey olur ondan kurtulmak icinde bizim bir tane Constant klasorumuzde Messages larimizi
            //yazdigimiz yer vardi oraya gideriz orda Producct a ozel bir Validation mesajlari yazabiliriz

            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
            //Fiyat 1 den kucuk olmasin yani fiyat yazilmali
            //When burda sart durumudur
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 2);
            //Kategorisi 2 olan urunun fiyati en az 10 olsun diyoruz
            //Icecek kategorisindeki bir urunun fiyati minimum 10 dur diyoruz...
            //10 un altinda fiyat yazilirsa burdan mesaj default olark verir istersek de biz gireriz fiyati 
            //Exclusivebetween(2,5) 2 ve 5 in disinda olsun
            //Inclusivebetween(3,10) 3 ile 10 arasi olsun

            //Mesela kendimize ozel kurallar koymak istersek ornegin bir seyehat firmasi 
            //sisteme kaydolurken basina 2 tane 00 koymamizi isteyebilir..bunlar olan seyler
            RuleFor(p => p.ProductName).Must(StartWithWithA);//Aslinda bir delege gonderiyoruz
                //Method delegasyonudur bu C# da
        }

        private bool StartWithWithA(string arg)
        {
            return arg.StartsWith("A");//arg bizim parametremizdir ve string i temsil ediyor
            //string icinde var olan StartsWith methodu ile A ile baslamali diyoruz...
        }
    }
}
//Burda suna cok dikkat Business kurali yazmamaliyiz!!!!
//Burda veritabanina baglanmaya calisip da Business kodu yazmayalim burasi kendine ait isi yapacak
