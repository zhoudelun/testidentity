using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1_identity
{
    public class FileLogger : ILogger
    {
        private readonly string _name;
        private readonly Func<string, LogLevel, bool> _filter;

        public FileLogger(string name):this(name,filter:null)
        {
           
        }

        public FileLogger(string name, Func<string, LogLevel, bool> filter)
        {
            _name = string.IsNullOrEmpty(name) ? nameof(FileLogger) : name;
            _filter = filter ?? ((category, logLevel) => true);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NoopDisposable.Instance;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _filter(_name, logLevel);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;
            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message))
                return;

            FileLoggerWriter.Instance.WriteLine(logLevel, message, _name, exception);

        }
    }

    internal class NoopDisposable:IDisposable
    {
        public static NoopDisposable Instance = new NoopDisposable();

        public void Dispose()
        {
             
        }
    }
}
