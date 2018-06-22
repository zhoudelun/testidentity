using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1_identity.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1_identity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build(); 
            using (var scope = host.Services.CreateScope())
                            {
                                var services = scope.ServiceProvider;

                                try
                                {
                                    InitializeDatabase(services);
                                }
                                catch (Exception ex)
                                {
                                    var logger = services.GetRequiredService<ILogger<Program>>();
                                    logger.LogError(ex, "初始化数据库失败.");
                                }
                            }
            host.Run();
        


        }
        #region 初始化数据库
        private static  void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceProvider>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                
                db.Database.EnsureCreated();
                db.Database.Migrate();
            
                if (!db.Tag.Any())
                {
                    string userid = string.Empty;
                    var _user = db.UserExtend.FirstOrDefault();
                    if (_user != null)
                    {
                        userid = _user.Id;
                        var l = new List<Tag>() {
                            new Tag(){ Title="鸡蛋", Socre=20, DDUserId= userid},
                            new Tag(){ Title="地蛋", Socre=20, DDUserId= userid},
                        };
                        db.Tag.AddRange(l);
                        db.SaveChanges();
                    }

                }
            }
        }
        #endregion

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
            .ConfigureLogging(builder => {
                builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>();
            });
    } 
}
