using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Extensions
{

    public static class MyHttpContext
    {
        private static IHttpContextAccessor _accessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current => _accessor.HttpContext;

        internal static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
    }
    /// <summary>
    /// 利用MyHttpContext的cookie操作。
    /// </summary>
    public class CookieHelper
    {
        public static void SetCookie(string name, string value)
        {
            MyHttpContext.Current.Response.Cookies.Append(name, value);
        }
        public static string GetCookie(string name)
        {
            return MyHttpContext.Current.Request.Cookies[name] == null ? "" : MyHttpContext.Current.Request.Cookies[name];
        }
        public static void RemoveCookie(string name)
        {
            if (MyHttpContext.Current.Request.Cookies[name] != null)
            {
                MyHttpContext.Current.Response.Cookies.Delete(name);
            }
        }
    }

    public static class StaticHttpContextExtensions
    {
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            MyHttpContext.Configure(httpContextAccessor);
            return app;
        }
    }
}
