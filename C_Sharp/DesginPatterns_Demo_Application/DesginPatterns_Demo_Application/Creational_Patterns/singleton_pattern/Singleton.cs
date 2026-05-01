using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPatterns_Demo_Application.Creational_Patterns.singleton_pattern
{
    internal class Logger
    {
        private static readonly Object _lock = new Object();
        private static Logger logger;

        private Logger()
        {
        }

        public static Logger GetInstance()
        {

            lock (_lock)
            {
                if(logger == null)
                {
                    logger = new Logger();
                }
            }
            return logger;
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}
