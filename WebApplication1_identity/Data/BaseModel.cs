using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_identity.Services;
using Newtonsoft.Json;
using WebApplication1_identity.Extensions;

namespace WebApplication1_identity.Data
{
    public class BaseModel :PageModel
    { 
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly ITestService _testService;
 

        public BaseModel(ITestService testService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _testService = testService;
        }
        public   ApplicationUser CurrentUser {
            get {
                var _c = MyHttpContext.Current.Request.Cookies["my"];
                var u = new ApplicationUser();
                if (_c == null)
                {
                    u = _userManager.FindByNameAsync(User.Identity.Name).Result;
                    MyHttpContext.Current.Response.Cookies.Append("my", 
                        JsonConvert.SerializeObject(u));
                }
                else
                {
                    u = JsonConvert.DeserializeObject<ApplicationUser>(_c);
                }
                return u;
            }
        } 


    }
}
