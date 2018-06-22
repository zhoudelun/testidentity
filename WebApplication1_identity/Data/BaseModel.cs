using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_identity.Services;
using Newtonsoft.Json;
using WebApplication1_identity.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1_identity.Data
{
    public class BaseModel :PageModel
    {

        public   UserManager<ApplicationUser> _userManager;
        public   ITestService _testService;
        private IMemoryCache _memoryCache;
   
        public   BaseModel(ITestService testService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache)
        {           
            _testService = testService;
            _userManager = userManager;
            _memoryCache = memoryCache;
        }

        public override NotFoundResult NotFound()
        {
            Response.Redirect("/404.html");
            return null;//            return base.NotFound(); 
        } 
        public   ApplicationUser CurrentUser {
            get {
                string my = User.Identity.Name;
                var item = new ApplicationUser();
                if(! _memoryCache.TryGetValue(my, out item))
                {
                    item= _userManager.FindByNameAsync(User.Identity.Name).Result;
                    _memoryCache.Set(my, item,TimeSpan.FromHours(2));
                }
                return item;

                //var _c = MyHttpContext.Current.Request.Cookies["my"];
                //var u = new ApplicationUser();

                //if (_c == null)
                //{
                //    u = _userManager.FindByNameAsync(User.Identity.Name).Result;
                //    MyHttpContext.Current.Response.Cookies.Append("my", 
                //        JsonConvert.SerializeObject(u));
                //}
                //else
                //{
                //    u = JsonConvert.DeserializeObject<ApplicationUser>(_c);
                //}
                //return u;
            }
        } 


    }
}
