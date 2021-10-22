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
  public  class ValidationAspect:MethodInterception
    {
        //Burasi artik methodun uzerine yazacagimiz aspect,attribute yani interception dir
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {//ProductValidator tipi eger yazilana uymuyorsa....ayni tip degilse....
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }
            //Eger tip dogru ise o zaman tamam validatorType i bizim disarda olusturdugumuz Type
            //tipi degiskenine ata ki ben bunu gidip diger mehtodlarda kullanabileyim....
            _validatorType = validatorType;
        }
        //[ValidationAspect(typeof(ProductValidator))] Boyle kullanabilmek icin Type tipi ile
        //constructor da tip gondermeliyim..

        //Simdi ise ben bu Aspect im methodun neresinde calismasini istiyorsam onun override ederimm

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //(IValidator)Activator.CreateInstance(_validatorType) Casting tip donusumudur
            //Burda biz ne yapiyoruz Reflection yontemi ile calisma aninda bir tane instance uretiyoruz.Hani bizim ProductValidator
            //nesnemizdeki kurallarin calismasi icin ValidationTool da yazdigimiz method icinde new lenmesi gerekiyordu iste bu 
            //new leme olayini reflection araciligi ile bura yapariz....Bellekte bir tane referans olusturuyor,instance uretiyor
            //Burda biz ProductValidator i bellekte new ledik instance olusturduk yani...
            //Bir tane ProductValidator nesnesinden instance olustururuz...
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //Burda bir listeyi gezme sebebimiz Add methodu icinde birden fazla parametre olma
            //durumunu da goz onunde bulundurmak ve o zaman biz Add methodu icindeki hangi 
            //parametre ProductValidator isleminde uygulanacak olan tip olacak onu netlestirmek ve de ValidationTool da 
            //hangi tipi kullanacagimizi netlestirmek

            foreach (var entity in entities)
            {
                //validator degiskeninde _valiodatorType olan ProductValidator new lenmistir,instance
                //olusturulmustur...Dolayisi ile
                ValidationTool.Validate(validator, entity);
            }
        }
        //public static void Validate(IValidator validator, object entity){} bu methodu biz burda 
        //calistiriyoruz....
        //Bir methodun icindeki paramtresinin birden fazla olma durumunda da iste bu sekilde 
        //onu dondererek calistirabiliriz...

    }
}
