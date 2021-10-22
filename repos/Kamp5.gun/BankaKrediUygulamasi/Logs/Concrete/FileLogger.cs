using BankaKrediUygulamasi.Logs.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankaKrediUygulamasi.Logs.Concrete
{
    public class FileLogger : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("FileLogger uygulandi");
        }
    }
}
