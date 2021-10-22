using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
  public  class CacheAspect:MethodInterception
    {
        //Burasi ProductManager daki ozelikkle listeleme operasyonlarinin onunde calisacak aspect,attribute
        //interceptor dur
        //Datayi ne kadar sure cache tutacagiz onu burda belirtmeliyiz
        //CacheManager immizin icindeki operasyonlara erismemiz gerekiyor onun icinde onu
        //constructor da yaziyoruz
        private int _duration;
        private ICacheManager _cacheManager;
        public CacheAspect(int duration=60)
        {
            _duration = duration;
            //Birde kendi yazdigimiz baglanmamiz gerekiyor
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            //Kendi yazdigimiz servise ulasirz artik cunku ICacheManager i tip olarak verdik!!!!
            //Birde biz ICacheManager in neye karsilik geldigiini CoreModule a yazdik,yazmamiz gerekiyor
            // services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }

        //Simdi bizim sunu gerceklestirmemiz gerekiyor.Once git bir bak bakalim cache de var mi
        //Yoksa cache e ekle , eger cache de varsa git cache den getir dememiz gerekiyor
        //Burda key degeri bizim icin method bilgisi olacak yani classi, methodun ismi ve parametreleri
        //seklinde olacak

        public override void Intercept(IInvocation invocation)
        {
            
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}" + $".{invocation.Method.Name}");
            //Class ismi ve mehtod ismine ulastik...
            //invocation.Method.ReflectedType.FullName=>class ismi
            //invocation.Method.Name=>method ismi
            //ProductManager.GetByCategory boyle yazabilme islemini methodName e atadik...
            //Simdi de parametrelere gelelim
            //Suslu parantez icindekiler dinamik digerleri sabit, statik
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //ProductManager.GetByCategory() yazdgimiz bu methdun parametresini olusturyoruz simdide
            //parantez i methoddan sonra actik ve string.join(arguments) arguments parametreler
            //her bir parametre icin eger parametre varsa onu stringe cevir aksi takdirde Null olarak yani parametre
            //yokmus gibi yaz
            //Methodun parametrelerine bakacak , methodName sonuna bir parantez aciyor sonra
            //tum parametreleri virgulle bir araya getiriyor kisacasi goruntu su oluyor:
            //ProductManager.GetByCategory(1,sdasfga) tamamen methodu cagir gibi kendimizce bir key olusturduk
            //bunu boyle yaptik cunku bu bana sunu saglayacak farkli parametrelerde gelirse key degismis
            //olacak dolayisi ile operasyon icerigi bazli bir caching altyapisi gerceklestirmis oluyoruz..
            if (_cacheManager.IsAdd(key))//key=ProductManager.GetByCategory(1,sdasfga)
            {////Eger bu key daha once cache ye eklenmis ise
                //O zaman mehtodu hic calistirma direk 
                invocation.ReturnValue = _cacheManager.Get(key);
            }
            invocation.Proceed();
            //invocation.ReturnValue methodun kendisnin ReturnVAluesi
            //Add methodunun donen datasi...
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }

    }
}
