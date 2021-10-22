using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
   public class LogDetail
    {
        //Bizim icin log a ait detay bilgisini tutacaktir
        public string MethodName { get; set; }
        //Loga konu olan method ismi
        public List<LogParameter> LogParameters { get; set; }
        //Log parametreleri,birden fazla log parametresi olacak
        //Log parametresi yani FileLogger mu,DatabaseLogger mu vs gibi 
    }
}
