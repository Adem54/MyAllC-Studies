using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    class DatabaseLoggerService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("Database olarak kaydedildi");
        }
    }
}
