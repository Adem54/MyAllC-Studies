using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces3
{
    //ICustomerDal ismi database islemleri yapilirken kullaniliyor Data-access-layer dan geliyor
    interface ICustomerDal
    {
        //Interface i biz farkli implementasyonlar icin kullaniriz mesela ornegin 
        //Mesela biz hem Sql hem de Oracle veya Msql ile calismam gerekiyor o zaman ben her iki sistemi de ayri implemente
        //etmem gerekir
        //Ozellikle birbirinin alternatifi olan islerde kullaniriz.Yani benzer islerini yapildigii ama detaylarda 
        //her birimin kendi kurallarinin oldugu tarz durumlarla karsilasirsak bu tur durumlarda interface kullanilir
        void Add();
        void Update();
        void Delete();
    }
}
