using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_identity.Data;
using Microsoft.AspNetCore.Authorization;
using WebApplication1_identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1_identity.Pages.DD
{
    [Authorize]
    public class MyFaModel : BaseModel
    {
        public MyFaModel(ITestService testService, UserManager<ApplicationUser> userManager) :base(testService,userManager)
        {
        }
        public IPagedList<Info> Info { get; set; }
        public async Task OnGetAsync(int pid=0)
        {
            Info = await _testService.FaGetByUserIdAsync(CurrentUser.Id,pid);
        }
    }
}