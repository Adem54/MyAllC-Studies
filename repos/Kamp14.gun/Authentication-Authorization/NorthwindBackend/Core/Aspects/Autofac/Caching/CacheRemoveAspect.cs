using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace Core.Aspects.Autofac.Caching
{
   public class CacheRemoveAspect:MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(string pattern)//Cache den silinecek pattern dir bu
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            //Microsoft.Extensions.DependencyInjection; dan gelir GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
            //Biz bu cacheRemove u ne zaman calistiracagiz ornegin yeni urun eklendiginde
            //urun guncellendiginde, ve silme operasyonunda biz bunu calistiracagiz cunku  neden yeni
            //urun eklendi cache nin duzeltilmesi gerekiyor...
            //Bu OnSuccess oldugunda calisacak neden cunku Add i calistirdik ama belki de 
            //Success olmadi o zaman bosu bosuna cache i temizlemis oluruz onun icin operasyon
            //basari ile sonuclanirsa CacheRemove calissin diyecegiz...
            //     [CacheRemoveAspect(pattern:"IProductService.Get")]
            //  [CacheRemoveAspect(pattern: "ICategoryService.Get")]
            //Add operasyonumuz basarili  oldugunda bizim IProductService.Get olan yani ProductManager veya
            //IProductService miz de get ile baslayan operasyonlardan cache de olan varsa onlari silecek
           // public IResult Add(Product product)
        }
    }
}
