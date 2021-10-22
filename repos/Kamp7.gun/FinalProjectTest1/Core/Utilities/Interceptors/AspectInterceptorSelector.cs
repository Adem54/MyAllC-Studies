using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {//Interceptor MethdoInterceptionBaseAttribute un implement ettigi interface dir
     //Ve icerisinde public void Intercept(IInvocation invocation) parametre olarak
     //ProductManager gibi nesnelerimizde var olan methodlari temsil eden paramtre alir 
     //MethodInfo bu System.Reflection dan gelir ve tipimize ait yani ProductManager a ait methodlari temsil eder
     //o methodlara ait verilere ulasiriz ve istedigimiz methodu da cagirabiliriz calisma aninda,
     //Type type bu System den gelir
     //---------------------------------------
     //MethodInfo reflection dan gelir using.system.reflection diye cozebilriz.Bunu cozunce diger
     //alti cizililer de duzeliyor
     //Bu method yani SelectInterceptors IInterceptor[] dizi tipinde IInterceptorSelector interface inden geliyor
     //IInterceptorSelector interface i AspectInterceptorSelector tarafndan implement edilmis
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {//Type type=>ProductManager, MethodInfo method=>Add methodu
         //IInterceptor[] interceptors=> void Intercept(IInvocation invocation) 

            //ClassAttirube lerini veriyor ve listeliyor bu Reflection dan yapabildigmiz bir sey

            //Olusturulan GetCustomerAttributes<T> t burda attribute tipi dir ve biz oraya attribute lerimizin base i
            //olan MethdoInterceptionBaseAttribute koyduk...Bu attribute umuzu inherit eden tum nesneler burda 
            //onun yerine yazilabilirz cunku onu inherit edenlerin referanslarini tutuyor
            //MethodInterception bizim base olan MethodInterceptionBaseAttribute u inherit ediyor
            //ValidationAspect ise MehtodInterception u inherit ediyor dolayisi ile
            //ValidationAspect te bir MethodInterceptionBaseAttribute dur, yani burda attribute
            //olarak biz ValidationAspect yazdigimiz icin onu alabilecek cunku burya onun tipini
            //yazdik ve bu arada bu surdurulebilir olsun diye biz MethodInterceptionBaseAttribute
            //ten uretilecek sekilde planlanmis yani onu tip e koydgumuz zaman hersey 
            //yerli yerine oturuyor
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //Methodattributeleri aliyoruz burda da ve bunlar liste olarak gelir
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
           // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
            //Burda classAttributes leri demek iste bizim Validaton,Authorization,Log,Transiction
            //gibi islemlerimizi anlamlandirmak icin icine koydgumuz yapidir Onlari oncelik degerine
            //gore siralayarak bir liste icerisine atiyor burda
        }
    }
}
//BURASI BIZE TUM INTERCEPTORLARI BIZIM ONCELIK SIRAMIZA GORE SIRALAMIS VE BIR LISTEYE ATIMIS BIR SEKILDE
//DONDERIYOR BIZ INTERCEPTORLARIMIZI SISTEME KAYDEDERKEN GIDIP DEPENCENCYRESOVERS KLASORUNDE
//AUTOFAC ICINDE AutofacBusinessModule de ASPECTINTERCEPTORSELECTOR U KAYDEDERIZ..