using BankaKrediUygulamasi.Credits.Abstract;
using BankaKrediUygulamasi.Logs.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankaKrediUygulamasi.Business
{
  public  class ApplyManager
    {

        public void ApplyForCredit(ICrediService crediService,ILoggerService loggerService)
        {
            crediService.Calculate();
            loggerService.Log();
        }

        public void KrediOnBilgilendirme(List<ICrediService> crediServices)
        {
            foreach (var credi in crediServices)
            {
                credi.Calculate();
            }
        }

    }
}
