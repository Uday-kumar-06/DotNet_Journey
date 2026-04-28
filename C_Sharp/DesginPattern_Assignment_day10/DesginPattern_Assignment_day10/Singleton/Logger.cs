using System;
using System.Collections.Generic;
using System.Text;

namespace DesginPattern_Assignment_day10
{
    sealed class Logger
    {
        private readonly Object _lock = new Object();
        private Logger logger;

        private Logger()
        {
            Console.WriteLine("Logger instance created.....");
        }
        public  Logger GetInstance()
        {
            if (logger == null)
            {
                lock (_lock)
                {
                    logger = new Logger();
                }
            }
            return logger;
        }
        
    }
}
