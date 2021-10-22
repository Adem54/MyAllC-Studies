using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
 public  interface ICoreModule
    {//Bu islemi yaparken AutofacBusinessModule i hatirlayalim orda Load islemi gercekles
        //misti...
        void Load(IServiceCollection services);
    }
}
