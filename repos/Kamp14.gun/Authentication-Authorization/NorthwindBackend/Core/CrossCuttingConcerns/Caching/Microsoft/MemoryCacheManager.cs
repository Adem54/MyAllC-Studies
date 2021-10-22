using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    //Microsofttan gelen MemoryCacheManager i kullanacagiz..

   
    public class MemoryCacheManager : ICacheManager
    {
        //Core tarafinda DependencyResolvers da CoreModule da AddMemoryCache i serviskoleksiyonuna
        //ekledik....Dolayisi ile onu okumak isteyecegiz...constructor ile
        IMemoryCache _cache;//MemoryCache nin bir interface i var onu kullaniriz..
        //IMemoryCache nin altyapisinda bize lazim olan hersey var
       
        public MemoryCacheManager()
        {
            //Microsoft.Extensions.Caching.Memory; ve Microsoft.Extensions.DependencyInjection da
            //yuklenmeli....
            _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();

                //Bana bir tane IMemoryCache turunde nesne ver dikkat edersek bu biz
                //using Microsoft.Extensions.Caching.Memory; den geliyor.Bu aslinda Microsoftun
                // yani .Net Core ekibinin memorycache implementasyonu yani bizim yazdigimiz
                //services.AddMemoryCache nin implementasyonudur dolayisi ile interface uzerinden
                //diyecegim ki bana kendi veya servis koleksiyonundaki IMemoryCachi ver
                //Yani ben bu yazdgim kod satiri ile servis altyapi ma erisebiliyorumm...
                //Bu bizim icin IMemoryCache dolaysii ile ben onu global yapip diger
                //operasyonlarda kullanabilmeliyim
                //Core da IoC klasorunde yazdigimiz ServiceTool
        }

        //Yukarda ayarlamalari yaptiktan sonra artik Get operasyonlarimdan baslayarak hepsini rahatlikla
        //yazabilirim....MemoryCacheManager bize bu altyapiyi veriyor...

        //Bu yapabildigimiz operasyonlar hep MemoryCacheManager altyapisindan geliyor...
        //Artik _cache uzerinden tum islemlerimizi yapacak hale geldik...

        public void Add(string key, object data, int duration)
        {
            _cache.Set(key, data, TimeSpan.FromMinutes(duration));//duration degeri ile dakika yi kastediyoruz
        }

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public object Get(string key)//Bu da direk obje sonuc ta herzaman nesne olmayabilir
                                     //Yani nesne disinda anonim bir veri tipi olursa...diye
        {
            return _cache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _cache.TryGetValue(key, out _);//out _ demek ben ne sonuc dondurecegini onemsemiyorum
            //benim icin var mi yok mu onu kontrol et demektir
        }

        public void Remove(string key)
        {
             _cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {//Burda cache kolleksiyonundaki elemanlara ulasmaya calisacagim bu patterni bulmak icin
         //Klasik .Net te var ama .NetCore da bizim cache deki butun elemanlara ulasabilecegimiz
         //bir yapi tasarlamamislar ya burayi kodlamayacagiz ya da kendim implementassyonuna eris
         //tigimi bir yontemle o cachedeki butun yapilara ulasacagiz
         //Burasi tamamen hazir bir kod stackoverflow dan alinmis ve cache elemanlarina ulasabilecegimiz
         //bir yapidir

            //EntriesCollection bir property dir yani cache kolleksiyonudur biz ona ulasmaya calisiyoruz aslinda
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {//cacheItemValue olusturyyoruz her bir cache girisi ve ordaki herbir degeri okuyarak EntriesCollectiondaki
                //herbir degeri okuyup cacheCollectionValues icine atiyoruz
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }
            //Elimdeki pattern a gore bir regex olusturuyorum....
            //String olarak gonderdigim patterna gore bir regex olusturuyorum
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //cacheCollectionValues, cache deki benim olusturdugum listedeki butun elemanlari o regexe gore bulup listeye atiyorum
            //Benim gonderdigim patterna uygun olan tum keyleri tum cachlerin icinden alip bir listeye toplamis olduk
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            //En son da foreach ile listeyi donderip sirayla Remove edebiliriz...
            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
            }
            //Sira ile yaptiklarimiz..Once koleksiyona reflection ile ulasiriz ve onlari listeye ekleriz
            //Regeximi olustururum, cache degerleri icnde benim regexime uyanlari bulup listeye atiyorum
            //VE listedeki leri tek tek siliyorum...
        }
    }
}
//Sunucu tarafinda yapilan cacheleme isleminde surekili yapilan istek lerin herseferinde
//veritabanindan cagirilmasi yerine sunucuda bir on bellege alinir ve direk ordan cagirilir..