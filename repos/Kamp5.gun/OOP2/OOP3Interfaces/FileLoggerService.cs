using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3Interfaces
{
    class FileLoggerService : ILoggerService
    {
        public void Log()
        {
            Console.WriteLine("Dosya olarak kaydedildi!");
        }
    }
}
