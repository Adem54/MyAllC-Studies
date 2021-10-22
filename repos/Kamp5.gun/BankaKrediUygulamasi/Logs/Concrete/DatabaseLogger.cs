using BankaKrediUygulamasi.Logs.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankaKrediUygulamasi.Logs.Concrete
{
    public class DatabaseLogger : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("DatabaseLogger loglandi");
        }
    }
}
