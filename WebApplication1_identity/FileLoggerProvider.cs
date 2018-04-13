using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private Func<string, LogLevel, bool> _filter;
        public FileLoggerProvider()
        {
            _filter = (category, logLevel)=> {
                bool _flag = false;
                switch (category)
                {
                    case "注册":
                        _flag = logLevel >= LogLevel.Warning;
                        break;
                    default:
                        _flag = logLevel >= LogLevel.Error;
                        break;
                }
                return _flag; } ;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(categoryName,_filter);
          
        }

        public void Dispose()
        {
            FileLoggerWriter.Instance.CancellationToken.Cancel();
            while (FileLoggerWriter.Instance._queue.Count()>0)
            { 
                Task.Delay(100).Wait();
            }

        }
    }
}
