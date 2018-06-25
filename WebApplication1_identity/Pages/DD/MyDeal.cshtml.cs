using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1_identity.Data;
using WebApplication1_identity.Services;

namespace WebApplication1_identity.Pages.DD
{
    [Authorize]
    public class MyDealModel : BaseModel
    {
        public MyDealModel(
            ITestService testService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache) : base(testService, userManager, memoryCache)
        {
        }
        public IPagedList<Deal> MyDeals { get; set; }
       
        public async Task OnGetAsync(int pid=0)
        { 
            MyDeals = await _testService.DealGetBothChooseAsync(CurrentUser.Id, pid);
        }
         
    }
}