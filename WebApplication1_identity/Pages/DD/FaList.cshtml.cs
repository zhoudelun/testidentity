using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1_identity.Data;
using WebApplication1_identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1_identity.Pages.DD
{
    [Authorize]
    public class FaListModel : BaseModel
    {
        [TempData]
        public string StatusMessage { get; set; }
        public FaListModel(ITestService testService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache) : base(testService, userManager, memoryCache)
        {
        }
        public IPagedList<Info> Info { get; set; }
        //public ApplicationUser UserExtend { get; set; }
        public SelectList LTopic { get; set; }

        public SelectList LTeam { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var id = CurrentUser.Id;
            var u=await _testService.GetInfoInputAsync(CurrentUser.Id);
            LTopic = new SelectList(u.Topic.Select(s=>s.Topic).ToList(), "Id", "Title");
            if (LTopic == null || LTopic.Count() == 0)
            { 
                return RedirectToPage("./ZhuTi" ,new { msg = "先关注主题,才能搜索信息 :)" });
            }
            LTeam = new SelectList( u.Team.Select(s => s.Team).ToList(),"Id","Name");
            if (LTeam == null || LTeam.Count() == 0)
            {
                return RedirectToPage("./set",new { msg  = "先关注的地方,才能搜索那里的信息 :)" } );
            }
            StatusMessage = "请搜索";
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Info= await _testService.FaGetBySearchAsync(new InfoSearchDTO { TopicId = Input.LTopic, TeamId = Input.LTeam });
            var id = CurrentUser.Id;
            var u = await _testService.GetInfoInputAsync(CurrentUser.Id);
            LTopic = new SelectList(u.Topic.Select(s => s.Topic).ToList(), "Id", "Title");
            LTeam = new SelectList(u.Team.Select(s => s.Team).ToList(), "Id", "Name");
            return Page();
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public int LTopic { get; set; } 

           
            public long LTeam { get; set; }

            public string Tag { get; set; }
        }
    }
}