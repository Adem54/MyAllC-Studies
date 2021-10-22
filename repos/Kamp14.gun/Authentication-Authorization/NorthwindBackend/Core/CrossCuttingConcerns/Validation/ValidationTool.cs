using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
 public  static class ValidationTool
    {//Yazdigimiz validation islemini yerine getiren arac gorevi gorecektir!!!!
     
     //Bu bizim icin bir arac olacagi icin onu static hale ceviririz...
     public static void Validate(IValidator validator,object entity)
        //IValidator validator ProductValidator i temsil ediyor...
        //biz object entity deriz cunkku burda entity sadece entities  temsil etmiyor ayni zamanda
        //Dto lari da temsil ediyor!!!!O zaman daha gelen bir tip olan object veririz
        //Sadece Entity lere ozel olsa idi o zaman IEntity entity de yazabilirdik!!!!!
        //IValidator validator yerine islem calisacagi zaman  new ProductValidator(); seklinde 
        //hangi validator ise o new lenecektir.Iste biz bu newleme islemini Aspect araciligi ile
        //yapariz(reflection araciligi ile calisma aninda) burasi cok hayati.....Yani Add methodu calistgii anda once
        //Validation aspectimiz 
        //calisir ve bizim hangi nesne tipini dogrulayacaksa hemen ondan bir tane nesne new leyecek

        {
            //ValidationContext<> using FluentValidation dan geliyor
            //Bu biz bir validation yapacagimiz zaman standart kodumuzdur aynen entityframework gibi
            //Burdaki context ilgili bir thread i anlatir
            //var context ile baslayan satirda diyoruz ki biz  entity icin dogrualama yapacagiz diyoruz ve
            //tip olarak object veririz ve prametre olarakda yukardaki parametreden gelen entity i veririz
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            //Validate bize ValidationResult tipinde donuyor ayni bizm SuccessResult vs gibi
            //Ve onun da icinde IsValid propertisi ve onun gibi properties ler mevcut
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}

//BU MANTIGA DIKKAT..ISIN PUF NOKTALARINDAN BIRI BU TARZ ISLERDIR
//DISARDAN BIR NESNEYI BASKA BIRYERDE KULLANRIRKEN DEPENDENCYINJECTION DISINDA KULLANABILECEGIMIZ
//MUTHIS BIR YONTEM DAHA!!!!
//Ben burda gelip de ProductValidator yazamam cunku burasi Core tarafi global
//O zaman ne yapacagiz bir tane interface bulmamiz gerkiyor bizim sadece isimizi gorecek bir
//interface yazariz ki her turlu ProductValidatoin,CategoryValidation ve Dto validation lar
//yararlansin
//Biz ornegin alttaki gibi kod yazdik ama burda ne yapmak istiyoruz Validator adli bir
//tool da .Validate degimiz zaman parametreye de product olsun veya cateogry veya 
//bir Dto olsun o zaman aklimiza hemen bir interface gelmeli bize bir interface lazm ProductValidator 
//umuzun interfacei olacak peki biz sunuu biluyoruz ki ProductValidator umuz bir AbstractValidator<>
//inherit ediyor o zaman o AbstractValidator<> un icine gidersek onun implement ettigi interface ler
//var iste o interface hem AbstractVAlidator un hem de ProductValidator un referansini tutar dolayisi ile
//Sen gelip de Product product nesnesi koyulabilecek birr yere IValidator yazdigin zaman ProductValidator
//gibi her turlu entity ve Dto validatorleri de AbstractValidator<> u inherit edeceginden dolayi
//O zaman hepsi ayni zamanda IValidator referansinda olur ve biz IValidator yazdiggimiz zaman
//bu araci hepsinde de kullanabilirz demektir!!!!!!
//Bu demek oluyor ki biz Core tarafina da FluentValidation paketini kurariz cunku IValidator 
//FluentValidaton dan geliyor



//BUSINESS E BUNU YAZDIK ONCE AMA ORDA YAZILMAZ BU KOD!!!
//ProductValidator productValidator = new ProductValidator();
//var result = productValidator.Validate(product);
////Validate bize ValidationResult tipinde donuyor ayni bizm SuccessResult vs gibi
////Ve onun da icinde IsValid propertisi ve onun gibi properties ler mevcut
//if (!result.IsValid)
//{
//    throw new ValidationException(result.Errors);
//}
//Peki bunu ilk basta bu sekilde yazmak fikri nerden geldi.ProductValidator u n inherit ettigi
//AbstractValidaor un icine gidersek orda bir Validator oldugnu gorebilirz.ProductValidator AbstractValidatoru
//inherit edincew onu da kullanabiliyor ki o ise bir ResultValidator tipindedir ve onun icerisnde
//bizim kullanabilecgimz cok kullanisli propertiesler mevcuttur biz yine o Validator u kullanacagiz ama
//nerde kendi static Validator tool umuzun icinde kullanacagiz...