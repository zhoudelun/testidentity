using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_identity.Data;
using WebApplication1_identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplication1_identity.Pages.DD
{
    public class FaDetailModel : BaseModel
    {
        public FaDetailModel(ITestService testService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache) : base(testService, userManager, memoryCache)
        {
        }
         
        public Info Info { get; set; }
         
        [BindProperty(SupportsGet =true)]
        public string Uid { get; set; }
        public async Task OnGetAsync(int Id)
        {
            Info = await _testService.FaGetByIdAsync(Id);
            Uid = CurrentUser.Id;

            
        }
        public async Task OnPostAsync()
        {
        }

    }
}