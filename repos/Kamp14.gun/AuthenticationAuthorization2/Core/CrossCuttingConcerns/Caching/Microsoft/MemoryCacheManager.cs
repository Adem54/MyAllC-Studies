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
    public class MemoryCacheManager : ICacheManager
    {
        ////Microsoft.Extensions.Caching.Memory; ve Microsoft.Extensions.DependencyInjection da
        //yuklenmeli....

        //Oncelikle biz servisimizi kullanirken  hangi servise baglanacagiz onu belirtmeliyiz ki
        //o sekilde biz servis teki operasyonlara eriselimm
        IMemoryCache _cache;
        public MemoryCacheManager()
        {
            //IMemoryCache ile .Net altyapsindan gelen , cache islemini burda kendi servisimizi
            //yazarken kullandik..
            _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
            //using Microsoft.Extensions.DependencyInjection;
            //Servise erisiriz once...
            //Ve artik _cache araciligi ile asagidaki islemlerimizi yapabiliriz
        }


        public void Add(string key, object data, int duration)
        {
            _cache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public bool IsAdd(string key)
        
        
        {
            return _cache.TryGetValue(key,out _);
            ////out _ demek ben ne sonuc dondurecegini onemsemiyorum
            //benim icin var mi yok mu onu kontrol et demektir
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
            }
        }
    }
}
