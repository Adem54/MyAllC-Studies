
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{//IInterceptor Auotofac in de altyapisinda kullandigi bir DyanmicProxt denilen bir olay var ordan geliyor
    //Core tarafinda castle dynamic proxy yi yukleyelim

    //Bu method adi ustunde temel Attribute Base methodumuz..icine biz sadece Priority olusturduk
    //Intercept methodu IInterceptor den geldi ve onu implemente etme sonucu geldi ve o methodun
    //icinin degistirilebilmesi icin virtual yapiyoruz methodu bu da cook onemlidir
   
    //ATTRIBUTE KONUSUNDA BUNLAR BULUNABILIR..ATTRIBUTE GERCEK HAYAT KULLANIMI!!!
    //Bu bir Attribute oldugu icin simdi ona bir kisit koyacagiz class larda classin en tepesinde
    //kullanilsin diyecegizzz,methodlarda kullanilabilsin ve birden fazla kullanilabilsin ve inherit
    //edildigi altclass larda da kullanilabilsin diyoruz
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)]
   public class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {//Bu Priority yi yazma sebebimiz biz ornegin ProductManager da Add methodu uzerine birden
        //fazla interceptor yani Aspect yazacagiz Cross Cutting Concerns lerden bahsediyoruz
        //Iste onlar normalde yukardan asagi nasil yazarsak siraya dogru oyle calisir ama biz 
        //ilerde sayilari arttikca surekli yerlerini degistirmeye ugrasmayalim diye bir tane
        //hangi siraya gore calsmalari gerektigini belirlemek icin Priority adinda bir property yazariz

        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
      
        }

        //CastleDynamicProxy den gelen Interceptor u implement ettigmiz zaman bize bir tane Intercept
        //adinda bir operasyon getiriyor!!!
        //VIRTUAL CLASS LARA GERCEK HAYAT ORNEGI IYI INCELE!!!
        //Icini bos birakiyoruz ama bu operasyonun degistirilebilme imkani olmasi icin
        //onu virtual yapariz!!!!!Iste abstract class yaptik dolayisi ile virtual method da yapiyoruz
        
    }
}
