using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity
{
    public static class ProfilerEFCore
    {
        /// <summary>
        /// 监视EFCore
        /// </summary>
        /// <param name="a"></param>
        public static void Look(this Action a)
        { 
            var profiler = MiniProfiler.StartNew("m");
            using (profiler.Step("SqlProfile"))
            {
                // 你的代码 
                a();
            }
            // 输出日志
            if (profiler?.Root != null)
            {
                var p = profiler.Root;
                Trace.WriteLine($"{p.Name}:{p.Id},{p.DurationMilliseconds} ms");
                if (p.HasChildren)
                {
                    p.Children.ForEach(x =>
                    {
                        Trace.WriteLine($"{p.Name}:{x.Name},st:{x.StartMilliseconds} ms,exec:{x.DurationMilliseconds} ms");
                        if (x.CustomTimings?.Count > 0)
                        {
                            foreach (var ct in x.CustomTimings)
                            {
                                Trace.WriteLine($"{p.Name}:Start {ct.Key} --- ");
                                ct.Value?.ForEach(y =>
                                {
                                    Trace.WriteLine($"{p.Name}:{y.CommandString}");
                                    Trace.WriteLine($"{p.Name}:Execute time :{y.DurationMilliseconds} ms,Start offset :{y.StartMilliseconds} ms,Errored :{y.Errored}");
                                });
                                Trace.WriteLine($"{p.Name}:End {ct.Key} --- ");
                            }
                        }
                    });
                }
            }

            profiler?.StopAsync(true).ConfigureAwait(false);
        } 
    } 
}
