using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
   public class CacheAspect:MethodInterception
    {
        //Methodun onunde calisacak bir operasyon yazacagiz

        //1-Bizim oncelikle duration yani ne kadar sure cache de tutacagiz datayi
        //2-CacheManager imizin kendisi cunku burda biz artik cache imizi operasyonda calistiracagimiz
        //yerdir burasi...

        private int _duration;//Bunu kullanicidan istiyor olacagiz...
        private ICacheManager _cacheManager; //Hangi cache manager i kullanacaksin

        public CacheAspect(int duration=60)//default olarak 60 dakika veririz
           //  [CacheAspect(duration: 10)] burda kullanilacak...biz birsey yazmassak 60 dakka verecek
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            //Dikkat edelim bu bir cache manager i  calistirabilmemiz bu sekilde oluyor
            //GetService<ICacheManager>() dependencyINjection dan geliyor
            //Birde biz ICacheManager in neye karsilik geldigiini CoreModule a yazdik
           // services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }

        //Simdi bizim sunu gerceklestirmemiz gerekiyor.Once git bir bak bakalim cache de var mi
        //Yoksa cache e ekle , eger cache de varsa git cache den getir dememiz gerekiyor
        //Burda key degeri bizim icin method bilgisi olacak yani classi, methodun ismi ve parametreleri
        //seklinde olacak
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}" +
                $".{invocation.Method.Name}");
            //Class ismi ve mehtod ismine ulastik...
            //invocation.Method.ReflectedType.FullName=>class ismi
            //invocation.Method.Name=>method ismi
            //Simdi de parametrelere gelelim
            //Suslu parantez icindekiler dinamik digerleri sabit, statik
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //Bunu ornegin categoryye gore listeyelyip 2 no lu categoryId sine gore
            //listeleyince 2 numarali key e gore listelemis oluyoruz
            //string.Join("," aralarina virgul koy demek
            //methodName i yani class ismi sonra method ismi aralarinda . var ve sonra
            //methodun aynen cagrilma imzasi gibi ProductManager.GetByCategory(int categoryId) gibi
            // yaziyorduk ya onun gibi parantez i methoddan sonra actik ve string.join(arguments) arguments parametreler
            //her bir parametre icin eger parametre varsa onu stringe cevir aksi takdirde Null olarak yani parametre
            //yokmus gibi yaz
            //Methodun parametrelerine bakacak , methodName sonuna bir parantez aciyor sonra
            //tum parametreleri virgulle bir araya getiriyor kisacasi goruntu su oluyor:
            //ProductManager.GetByCategory(1,sdasfga) tamamen methodu cagir gibi kendimizce bir key olusturduk
            //bunu boyle yaptik cunku bu bana sunu saglayacak farkli parametrelerde gelirse key degismis
            //olacak dolayisi ile operasyon icerigi bazli bir caching altyapisi gerceklestirmis oluyoruz..

            if (_cacheManager.IsAdd(key))//Eger bu key daha once cache ye eklenmis ise
                //O zaman mehtodu hic calistirma direk 
            {

                invocation.ReturnValue = _cacheManager.Get(key);
                //methodun return degerine cache deki degeri al yukle diyoruz....
                return;//VE bitir diyoruz
            }
            //Eger  bu key cache de yoksa o zaman methodu calistir ve 
            invocation.Proceed();
            //invocation.ReturnValue methodun kendisnin ReturnVAluesi
            _cacheManager.Add(key, invocation.ReturnValue,_duration);
            //Son calisan degeri artik alip cache ekle demis oluyoruz...
        }
    }
}
