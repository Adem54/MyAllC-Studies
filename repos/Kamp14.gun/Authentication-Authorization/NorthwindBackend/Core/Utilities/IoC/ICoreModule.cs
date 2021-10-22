using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
public interface ICoreModule
    {
        //Ayni bizim AutofacBusinessModule da yaptigmiz gibi Load ooperasyonu ve
        //parametrede biz orda Autofac den gelen ContainerBuilder i  dahil ettik
        //Burda ise IServiceCollection i dahil edecegiz. .NetCore IServiceCollection in 
        //ne oldugunu ve kim oldugunu biliyor o yuzden ona gore enjeksiyon yapacak kendisi

        void Load(IServiceCollection services);
    }
}
