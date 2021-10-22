using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception//MethodInterception da
     //MethodInterceptionBaseAttribute u inherit etmisti
     //MethodInterception da biz OnBefore,Exception,OnSuccess,OnAfter gibi tek tek virtual method
     //lari yazdik iste burda biz hangisini calistirmak istersek onun icini dolduruyoruz

    {
        //ValidationApect bir MethodInterception dir ayni zamanda da MethodInterceptionBaseAttribute dur
        private Type _validatorType;//ProductValidator tipi(ve onun gibi olanlar CategoryValidator...)
      
        //BURDA BIZ ATTRIBUTE E BIR TIP PARAMETRESI OLUSTURUYORUZ VE SU SEKILDE KULLANILMASINI
        //SAGLIYORUZ YANI ATTRIBUTE E PARAMETRE OLUSTURUYORUZ VE BUNU TYPE ILE GECMEK ZORUNDASINIZ
        //ATTRIBUTE LERDE

       // [ValidatonAspect(typeof(ProductValidator))]=>ProductValidator u kullanarak bu methodu 
       //dogrula demektir
        public ValidationAspect(Type validatorType)
        //Attriubute te Type ile gecmek zorundayiz
        //Cunku bunu Add methodu uzerinde [ValidatonAspect(typeof(ProductValidator))] seklinde kullaniriz
        {//IsValidator FlutentValidation dan gelen ve ProductValidator tipindeki nesnelerin implement
         //ettigi interfacedir yani onlarin referansini tutuyor
         //IValidator ProductValidatorun inherit ettigi AbstractValidator class tarafindan implement
         //edildigi icin ProductValitator un da referansini tutuyor ve biz IValidator uzerinden
         //ProductValidator e ulasabiliyoruz
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                //Sadece IValidator tiplerinde calismasi iciin yaziyoruz yani back-end imizi kullanan
                //kullanici eger oraya IValidator tiipinde yani ProductValidator,CategoryValidator
                //tipinde veri gondermezse hata firlat diyoruz
            {
                throw new System.Exception("Bu bir dogrulama sinifi degil");
            }
            //Buraya gelirsem demekki biz dogru nesnedeyiz IValidator yani ProductValidatorden,
            //CategoryManager,CustomerManager 
            _validatorType = validatorType;
        }//Simdi artik tipimiz degiskenime atayip hangi islem olmasini istersem onun icini doldura
         //bilirim

        //Buraya dikkat et vurucu nokta burasi MethodInterception icinde OnBefore var ici bombos ve
        //OnBefore un icini burda dolduruyoruz ki OnBefore olarak calissi Add methdou yani 
        //Add methodundan once Attribute muz okunsun
        //Ama sen diyorsun ki validation da OnBefore da olacak ve burda da override ederek bu kodum
        //calissin diyoruz
        //OnBefore Virtual method old icin ici bos idi zaten kendisi biz ona yeni birsy yazmak icin
        //override etmeliyiz
        protected override void OnBefore(IInvocation invocation)//Add methodu
        {
            //ProductValidator newe leniyor burda cunku biz validation kurallarini constructor a yazdik
            //Yani ProductValidator new lenince icindeki validation kurallari calisir
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //Reflectotion ile calisma aninda bir instance olusturuyoruz ProductValidator den
            //VE ayni zamanda o nesnenin tum detayli verilerine calisma aninda ulasabiliyoruz
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            
            //ProductValidator un git base typini bul ve onun generic calistigi veri tipini bul
            //ProductValidator:AbstractValidator<Product> Product tipi
            //ProductValidtor un BaseType i AbstractValidator onun generic argumanlarindan ilkini bul
            //invocation Add methodumuzdur
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //Burda da ilgili methodun parametreleerini bul yani Add methodunun parametrelerini bul
            //invocation bizim ProductManager da ki methodumuzdur unutma
            //Burasi cok onemli dikkatli oku-diyor ki Add methdounun parametrelerinden birden fazla
            //parametresi olabilir onun icin cogul alir, public IResult Add(Product product)
            //Add methodunun parametrelerinin tiplerini
            //sira ile ProductValidator:AbstractValidator<Product> burdaki Product tipi ile ayni
            //olup olmadigini kontrol et ve ayni olanlari entities degiskenine liste olarak at..
            //Bunlar bana neden lazim cunku biz validation yapacagiz validation ne icin yapiliyordu
            //Kullanicinin gonderidigi veriyi yapisal olarak dogru girmeme durumundan dolayi biz dog
            //rulama yapmak istiyorduk ondan dolayi biz hangi veriler icin dogrulama yazdi isek onlara
            //validation uygulamak isteidgimiz icin bu sekilde yapiyoruz
            //Add methodunda birden fazla parametre de olabilir birden fazla validation da olabilir
           
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);//ValidationTool u merkezi bir noktaya aldik
            }
            //validator=>ProductValidator
            //entity=>Product product
            //Biz AOP yi yapmadan once tek satirda Add methodu icinde calistirdigimiz Validation
            //kodu nu biz AOP icinden calisitiriyoruz ve burayi calistirmak icin bizim bir validatore
            //yani ProductValidator gibi bir de onun inherit ettigi yani Base i olan
            //nesnenin generic argumani yani parametresine sini ihtiyacimiz vardi
             // public class ProductValidator : AbstractValidator<Product>
        }
    }
}
//Biz bu sayfada CrossCuttingConcerns altinda Validation altindaki  ValidationTool u AOP den
//once tek satirda Add methodu icinde calistirmistik simdi ise onu AOP icinde yani bu sayfada
//MethodIntercaption da yazdigimiz cati basliklarimizdan hangisini calistirmak istiyorsak 
//onun icini dolduruyoruruz burda da OnBefore un icini doldurduk ve tum bu islemleri
//onun icinde yaptik ki Add methodumuzdan once calissinZ
//calistiirdik ve ValidationTool da parametre olarak verdigimiz ProductValidator e Reflection
//ile calisma esnasinda ProductValidation dan bir instance olusturarak erisebildik  ona
//ProductValidator un inherit ettigi Base i olan nesnein generic arumenti olan entity Product a ise
//yine Reflection ile calisma aninda eristik ve
//Methodumzun  entitilerin birden cok olma durumunu da goze aldik ve methodumuzun parametresindeki herbir
//nesneyi ProductValidatorun inherit ettigi base sinifinin generic nesnesi veya tipi ile karsilastiririz
//Ayni olan lari liste icine atariz ve o listedeki entitiler bizim validation yapmamiz gerkeenler dir
//KUllanicidan gelen ve bizim dogrulamammiz gerekenlerdire ondan dolayi da liste icinde topladigimiz
//entitilerin herbirisine ayri ayri merkezi validation islemimizi uygulariz!!!!!
