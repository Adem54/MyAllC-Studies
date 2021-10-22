using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using Core.Aspects.Autofac.Exception;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Core.Utilities.Interceptors
{//IInterceptorSelector Castle.DynamicProxy  dan geliyor ve implement edince SelectInterceptors
    //operasyonunu bize getirir
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //type bizim Aspecti ekledigimiz siniftir,ProductManager gibi
            //MethodInfo method=>Add methodu

            //IInterceptor ise MethodInterceptionBaseAttribute un implement ettigi hem MethodInterceptionBaseAttribute
            //hem de MethodInterception in referansini tutuyor 
            //IInterceptor[] interceptors araya giricilerdir

            //ProductManager in GetCustomAttributte lerini al , ValidationAspect o da bir attribute idi ama
            //onun tipi MethodInterceptionBaseAttribute dur attribute olarak, MethodInterceptionBaseAtribute
            //ve onu inherit eden varsa onu da al.. ve listele diyoruz...
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit:true).ToList();
            //Bizim bu Aspect olayina konu olan nesnelerimiz...
            //Attribute umuz MethodInterceptionBaseAttribute ile basladi ve MethodInterception ve ValidatoinAspect
            //te birer attribute dur cunku MethodInterception MethodInterceptionBaseAttribute u inherit ediyor
            //ValidationAspect te MethodInterception i inherit ediyor

            var methodAttributes = type.GetMethod(method.Name).
                GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit:true);
            //Bizim attribute tipimiz MethodInterceptionBaseAttribute dur yani ValidationAspect olan
            //attribute umuz un de referansini tutan asil attribute tipimiz budur yani
            //inherit:true, Iki manager birbirini inherit ederse sikinti yasamayalim diye yapiliyor bu

            classAttributes.AddRange(methodAttributes);
            
            //classAttributes lere yani bir listeye baska bir listeyi dahil edip yeni bir liste olusturuldu
            //--Burayi ekledik....
            //Biz merkezi biryere ExceptionLogAspecti yazip heryerde calismasi icin buraya yaziyoruz
            //Tek tek tum methodlarin ustune yazmamak icin boyle yapiyoruz ama burda cok dikkatli
            //olmamiz gerekiyor

            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
            
            //--Burayi ekledik!!!

            return classAttributes.OrderBy(x => x.Priority).ToArray();
            //Attribute leri yani aspect leri siraliyoruz burda bir class a ait attribute leri yazdik ve sirala diyoruz
            //Artik ValidationAspect,LogAspect,AuthorizationAspect... gibi bunlari sirala
            //Biz Priority ozelligini verdigimiz zaman Priority ye gore sirala demis oluyoruz....
            //[ValidationAspect(typeof(ProductValidator),Priority=1)]
            //[AuthorizationAspect(typeof(ProductValidator),Priority=2)]
            //Priority MethodInterceoptionBaseAttribute de olusturuldu ve onun icindeki Priority
            //hem MethodInterception da kullanilabilir hem de ValidationAspect ve diger tum Aspectler de 
            //de kullaniiabilecektir ASpectler MethodInterception i inherit ettigi surece....
            //Ornegin priority sayilarini da paranteze bu sekilde ekleriz ve hangininin once calisacagi da belli
            //olmus olur... bu sekilde...

        }
    }
}
//Burda yaptigimiz islem Manager icindeki class ve method attribute leri bir listede topalamak,  ve onlari
//Priority ye verecegimiz siralamaya gore siralamak...
