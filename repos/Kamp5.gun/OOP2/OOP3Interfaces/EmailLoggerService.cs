using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    class EmailLoggerService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("Email olarak kaydedildi!");
        }
    }
}
