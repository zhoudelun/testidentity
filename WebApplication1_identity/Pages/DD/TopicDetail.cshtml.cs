using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1_identity.Services;

namespace WebApplication1_identity.Pages.DD
{
    public class TopicDetailModel : BaseModel
    {
        public TopicDetailModel(ITestService testService,UserManager<ApplicationUser> userManager,IMemoryCache memoryCache)
            :base(testService,userManager,memoryCache)
        {

        }
        public  Topic Topic { get; set; } 
        public async Task OnGetAsync(int Id)
        {
            Topic = await _testService.TopicGetByIdAsync(Id);
        }
    }
}