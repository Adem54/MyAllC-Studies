using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Performance
{
 public   class PerformanceAspect:MethodInterception
    {
        //Mesela ProductManager da herhangi bir operasyonu ele alalim.Ornegin GetAllByCategory operasyonunun
        //basindan sonuna ne kadar sure geciyorsa onu hesaplamamiz lazim
        //O zaman demekki bizim override etmemiz gereken iki kisim var birisi OnBefore bir digeri de
        //OnAfter, bu ikisini yakaliyor olmamiz gerekiyor
        //Bu ikisinin sonucunda ortaya cikan zamani hesaplayip bununla ilgili islem yapacagim
        //Dolayisi ile kullanicidan o islemi yapmam icin gerekli olan sureyi istiyor olacagim

        private int _internal;//aralik demek,gecen sureyi buz bununla tutacagiz
        private Stopwatch _stopwatch;//Bu da bir kronometre gorevi gorecek bizim icin
        //using System.Diagnostics;
        //Ya bunu new leyecegiz ya da Core da iken DependencyResolvers a geliriz CoreModule geliriz
        //Burda services.AddSingleton<Stopwatch>(); artik PerformanceAspect icinde o Stopwatch a ulasabilirim
        //Yani new leme isini bu sekilde halletmis olduk
        public PerformanceAspect(int interval)
        {
            _internal = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }
        
        //Bizim bu islem basladigi zaman bu stopwatch i baslatmamiz gerekiyor
       
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        //Bittigi zaman ise bu stopwatch i durdurmam gerekiyor
        protected override void OnAfter(IInvocation invocation)
        {
            //Eger saniye cinsinden gecen sure _interval dan buyuk ise
            if (_stopwatch.Elapsed.TotalSeconds>_internal)
            {
                //Gecen sureyi Debug tarafinda yazmak istiyoruz mesela bunun icin basit bir format yazacagiz
                //Biz buna mail attirabiliriz gelistiriciye ,yoneticiye mesela,konu ile ilgili kisiye sistemin otomaik mail 
                //atmasini saglayabiilirsiniz
                Debug.WriteLine($"Performance:{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");

                //Business.Abstract.IProductService=>{invocation.Method.DeclaringType.FullName}
                //{invocation.Method.Name}=>GetAll methodunu calistirdigimizi varsayalim...
                //Iki class taki isimde ayni olabilir diye bu sekilde
                //{_stopwatch.Elapsed.TotalSeconds} bu sekilde gecen surey i de yazabiliriz
            }


            _stopwatch.Reset();
        }

    }
}
