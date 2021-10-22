using System;

namespace OOP3
{
    class FileLoggerService : ILoggerService//bu class ILoggerService i implement ediyor burda
                                                //Bu class a sen bir ILoggerService alternatifisin diyoruz
                                                
    {
        public void Log()
        {
            Console.WriteLine("Dosyaya loglandi");
        }
    }
}
