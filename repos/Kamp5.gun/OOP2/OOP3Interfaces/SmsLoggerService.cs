using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    class SmsLoggerService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("SMS olarak loglandi");
        }
    }
}
