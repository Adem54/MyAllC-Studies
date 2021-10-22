using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
  public  interface ICacheManager
    {
        //Bir cache ile neler yapilacaksa onlar yapilabilir
        T Get<T>(string key);
        //Generic bir yapi kuruyoruz belli bir tipteki cache degerini okumaya calisacagim
        //Ayni sekilde obje olarak da kullanabiliriz
        object Get(string key);
        //Biz cache i okumak icin get operasyonlari yazdik 
        //Birde cache e eklemek icin Add operasyonu yazariz
        void Add(string key,object data,int duration);
        //key degerini data si ne ise onu ekleriz key:data, ne kadar duracaksa cache de
        //onu ekleriz...
        bool IsAdd(string key);
        //Birde direk cache den mi getireyim yoksa veritabanindan getirip cache e mi ekleyeyim
        //Eklenmis mi seklinde birsey yaziyoruz
        void Remove(string key);
        //Remove da belli bir cache keyinin ortadan kaldirilmasini saglar
        void RemoveByPattern(string pattern);
        //Burda da string bir pattern verip o patterna uyanlarin silinmesini isteyebiliriz
        //Mesela get ile baslayan tum cache leri sil gibi....O yuzden isimlendirme kurallari
        //cok onemlidir....
    }
}
