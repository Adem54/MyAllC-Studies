using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    //ICacheManager ismini veriyoruz cunku cache ile ilgili bizim operasyonlarimiz var
    //Ve o operasyonlari biz gidip de BusinessConcrete yazmayiz cunku orda biz veritabanindan oraya
    //gelen business islemlerini yapariz ancak burda cache on bellek ile veritabani arasinda bazi
    //genel islemler yapacagiz..
public interface ICacheManager
    {
        //Bir cache ile neler yapilirsa onlari yapacagiz...
        T Get<T>(string key);//
        object Get(string key);
        void Add(string key, object data, int duration);
        bool IsAdd(string key);//Data cache den mi geliyor yoksa veritabanindan mi geliyor
        void Remove(string key);
        void RemoveByPattern(string pattern);
        //Burda da string bir pattern verip o patterna uyanlarin silinmesini isteyebiliriz
        //Mesela get ile baslayan tum cache leri sil gibi....O yuzden isimlendirme kurallari
        //cok onemlidir....

    }
}
