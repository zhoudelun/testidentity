using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text;

namespace WebApplication1_identity
{
    public class FileLoggerWriter
    {
        static object Lock = new object();
        static FileLoggerWriter _instance;
        internal ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();
        string _logDir = $"{AppDomain.CurrentDomain.BaseDirectory}logs"; 
        public CancellationTokenSource CancellationToken => new CancellationTokenSource();



        public static FileLoggerWriter Instance {
            get {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        _instance = _instance ?? new FileLoggerWriter();
                    }
                }
                return _instance;
            }
        }
        private FileLoggerWriter()
        { 

            Task.Run(() => {

                if (!Directory.Exists(_logDir))
                    Directory.CreateDirectory(_logDir);
                while (!CancellationToken.IsCancellationRequested || _queue.Count() > 0)
                {
                    if (_queue.Count() == 0)
                    {
                        Thread.Sleep(50);// Task.Delay(500);
                        continue;
                    }
                       
                    if (_queue.TryDequeue(out string result))
                        File.AppendAllText($"{_logDir}\\{DateTime.Now.ToString("yyyyMMdd")}.txt", result);
                }
            });

        }

        internal void WriteLine(LogLevel logLevel, string message, string name, Exception exception)
        {

            var logBuilder = new StringBuilder();

            logBuilder.AppendLine($"-----{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}-----");
            logBuilder.AppendLine($"{logLevel.ToString()}:{name}");
            logBuilder.AppendLine(message);
            if (exception != null) logBuilder.AppendLine(exception.ToString());
            logBuilder.AppendLine("-----End-----");
            logBuilder.AppendLine();

            _queue.Enqueue(logBuilder.ToString());
        }
    }
}
