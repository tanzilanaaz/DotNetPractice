using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExample
{
    public sealed class logging
    {
        private static logging instance;
        private static readonly object _lock = new object();
        private logging() {}
        public static logging Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new logging();
                        }
                    }
                }
                return instance;
            }
        }
        public void LogMessage(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }
}
