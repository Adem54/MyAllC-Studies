
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    //Bu arada ValidationAspect e biz diyoruz ki sen bir MethodInterception  sin diyoruz...
    //MethodInterception ise MethodInterceptionBaseAttribute u implement etmis bir attribute idi
    //Yani ValidationAspect bir attribute dur ayni zamanda..yani Aspect tir...

  public class ValidationAspect:MethodInterception
    {//[ValidationAspect(typeof(ProductValidator))] biz bu ValidatonAspect i bu sekilde 
        //hangi methoddan once calismasini istersek oraya yerlestirecegiz ve bizim birde
        //hangi tip icin yani hangi kurallar icin calistiracagiz bunu simdi burda onu da 
        //attribute lerde biz constructor icinde veriyoruz bir attribute icinde
        //parametre kullanacaksak o yine o attribute un  constructori icinde ayarlaniyor
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //Burda validator un istedigimiz method seklinde gonderilmemesi durumuna gore bir kural yaariz
            //IValidator ProductValidator umuzun tipi idi yani tum validator lerimizin tipi o idi
            //Onu da ValidationTool.cs de gorebiliriz ProductValidator un inherit ettigi AbstractValidator un inherit ettigi bir
            //interface dir IValidator dolayisi ile ProductValidator un referansini tutuyor..
            if (!typeof(IValidator).IsAssignableFrom(validatorType) )
            {//Gonderilen validatorType eger bir IValidator tipinde degilse o zaman sen yanlis bir validator yolluyorsun diyecegiz

                throw new System.Exception(AspectMessages.WrongValidationType);
            }
            //Hata yoksa tamam bunu _valiatorType a atayarak  onu global yaptik ve bu nesne icinde istedigmiz yerlerde kullanabiliriz..
           //validatorType burda ProductValidator u temsil ediyor
            _validatorType = validatorType;
        }

        //Simdi OnBefore icini dolduralim!!!!


        //Ben ValidationAspect te OnBefore u override ettigim anda artik ValidationAspecttin oldugu yerde
        // OnBefore calisacak.Mantik tamamen bunun uzerine 
        // 
        protected override void OnBefore(IInvocation invocation)
        {
            //Bu IValidator tipinde olmasi gerekiyor ki  biz burda tum ProductValidator,CategoryValidator,CustomerValidator
            //tiplerinin hepsinde kullanabilelim.... ait operasyonlari kullanabilmemiz icin
            //(IValidator)Activator.CreateInstance(_validatorType) Casting tip donusumudur
            //Burda biz ne yapiyoruz Reflection yontemi ile calisma aninda bir tane instance uretiyoruz.Hani bizim ProductValidator
            //nesnemizdeki kurallarin calismasi icin ValidationTool da yazdigimiz method icinde new lenmesi gerekiyordu iste bu 
            //new leme olayini reflection araciligi ile bura yapariz....Bellekte bir tane referans olusturuyor,instance uretiyor
            //Burda biz ProductValidator i bellekte new ledik instance olusturduk yani...
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //_validatorType ProductValidator u temsil ediyor ve biz onu hallettik
            // //ValidationTool.Validate(new ProductValidator(), product);
            // public static void Validate(IValidator validator,object entity)
            //Simdide obje turunde hem entity hem de dto tipindeki verileri temsil eden obje nesneimize ulasalim simdide

            //_validatorType ProductValidator dur onun Base type AbstractValidatordur ve onun generic tipine ulasmaya calisiyorum
            //AbstractValidator<Product> AbstractValidator un generic tipi Product tir ona nasil ulasiriz asagidaki gibi
            //ulasabiliriz biz Core icindeyiz dolayisi ile bunu biz tum enitty ve dto lar icin de uygulayabiliriz
            //onun icin biz olabildigince global yontemlerler yapiyoruz ki bu tum projelerde gecerli olan bir nesne olsun
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Bir tane argumani var zaten o yuzden 0. derim

            //Simdide methodun parametrelerini gezecegiz yani Add methodunun mesela parametresi su an sadece Product olabilir ama
            //bu yarin oburgun artabilir sonucta onun icin biz birden fazla olarak degerlendiririz
            //Git methodun argumanlarina, yani parametrelerine bak onlari tek tek gez ve onlari
            //ProductValidator un Base abstract class i olan AbstractValidator<Product> un 
            //generic tipi olan Product ile kiyasla ayni olanlari bir listeye at donder bana
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //Burda bir listeyi gezme sebebimiz Add methodu icinde birden fazla parametre olma
            //durumunu da goz onunde bulundurmak ve o zaman biz Add methodu icindeki hangi 
            //parametre ProductValidator isleminde uygulanacak olan tip olacak onu netlestirmek ve de ValidationTool da 
            //hangi tipi kullanacagimizi netlestirmek
            //Simdi biz ValidationTool umuzu calistirmak icin hazirizi yani ne yaptik ValidationTool u calistirmak icin
            //icindeki ProductValidator ve Product tiplerine global olarak ulasacak kodlari yazdik ve simdi gecelim
            //ValidationTool u calistirmaya
            // Elimizde entities adinda bir Liste var icinde 1 tane veri olsa bile o bir lestedir ancak foreach ile ulasiriz o veriye
            //Mesela eklenecek 1 den fazla tip varsa Add metodunun parametesinde o zaman onlar sira ile gez ve validation kurallarimi
            //onlara uygula gibi birsey diyoruz aslinda
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }

        }
        //Biz simdi sadece OnBefore u doldurduk cunku sadece OnBefore calissin diyoruz yok bize birde mesele Exception lazim olsa
        //idi o zaman bu sayfada Excepion isleminin de icini dolduracaktik
    }
}
