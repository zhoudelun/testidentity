using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1_identity.Data;
using WebApplication1_identity.Services;
using System.Reflection;
using WebApplication1_identity.Extensions;

namespace WebApplication1_identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
                });

            // Register no-op EmailSender used by account confirmation and password reset during development
            // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
            services.AddSingleton<IEmailSender, EmailSender>();
            ////����ע�����
            //foreach (var item in GetClassName("Service"))
            //{
            //    foreach (var typeArray in item.Value)
            //    {
            //        services.AddScoped(typeArray, item.Key);
            //    }
            //}
            services.AddUnitOfWork<ApplicationDbContext>();//ע�����ݲִ�//���UnitOfWork֧��
            //services.AddSingleton<ITestService, TestService>();//use next line or will throw exception:InvalidOperationException: Cannot consume scoped service 'Microsoft.EntityFrameworkCore.IUnitOfWork' from singleton 'WebApplication1_identity.Services.ITestService'.
            services.AddScoped(typeof(ITestService), typeof(TestService));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//ע��HttpContextAccessor��ʹ��httpcontext������cookie
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.UseStaticHttpContext();//action�������ôˣ�����ʹ��cookie���Զ��巽����
        }

        /// <summary>  
        /// ��ȡ�����е�ʵ�����Ӧ�Ķ���ӿ�
        /// </summary>  
        /// <param name="assemblyName">����</param>
        public Dictionary<Type, Type[]> GetClassName(string assemblyName)
        {
            if (!String.IsNullOrEmpty(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> ts = assembly.GetTypes().ToList();

                var result = new Dictionary<Type, Type[]>();
                foreach (var item in ts.Where(s => !s.IsInterface))
                {
                    var interfaceType = item.GetInterfaces();
                    result.Add(item, interfaceType);
                }
                return result;
            }
            return new Dictionary<Type, Type[]>();
        }
    }



}
