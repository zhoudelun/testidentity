using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_identity.Services;
using Microsoft.AspNetCore.Identity;
using WebApplication1_identity.Data;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplication1_identity.Pages.DD
{
    public class SetModel : BaseModel 
    {
     
     
        public SetModel(ITestService testService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache) : base(testService, userManager, memoryCache)
        {
        }
        [TempData]
        public string StatusMessage { get; set; }
        public void OnGet()
        {
        }
        /// <summary>
        /// ?handler=Zdl
        /// 通过传入handler区分
        /// </summary>
        /// <param name="term">传入term</param>
        /// <returns></returns>
        public async Task<ActionResult> OnGetZdlAsync(string term)
        { 
            var d = await _testService.GetTeamAsync(term);
            return new JsonResult(d.Items); 
        }
        /// <summary>
        /// 关注归属地，以便发布信息到这里
        /// </summary>
        /// <param name="id"></param>
        public async Task<IActionResult> OnPost(long id)
        {
            var _team = await _testService.GetTeamAsync(f => f.Id == id);
            if (_team == null)
            {
                return NotFound();
            }
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var _ue = new ApplicationUser { Id = user.Id };
            var _t = new List<UserTeam>();
            _t.Add(new UserTeam {TeamId=id,UserExtendId= user.Id });
            
            await _testService.SetUserExtendAsync(new ApplicationUser
            {
                Id = user.Id,
                Team = _t 
            });
            StatusMessage = "设置成功！";
            return Page();
        }
        /// <summary>
        /// 设置belongteam归属地
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult>  OnPostZdlAsync(long id)
        {
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            await _testService.SetUserExtendAsync(new ApplicationUser
            {
                Id = user.Id,
                BelongTeamId = id,
                MyTeams = id.ToString()
            });
            return RedirectToPage("./my");//"./dd.my" is no need.
        }
         
    }
}