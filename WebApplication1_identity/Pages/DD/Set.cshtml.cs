using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_identity.Services;
using Microsoft.AspNetCore.Identity;
using WebApplication1_identity.Data;

namespace WebApplication1_identity.Pages.DD
{
    public class SetModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITestService _testService;
        [TempData]
        public string StatusMessage { get; set; }
        public SetModel(ITestService testService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _testService = testService  ;
        }
        public void OnGet()
        {
        }
        /// <summary>
        /// ?handler=Zdl
        /// ͨ������handler����
        /// </summary>
        /// <param name="term">����term</param>
        /// <returns></returns>
        public async Task<ActionResult> OnGetZdlAsync(string term)
        { 
            var d = await _testService.GetTeamAsync(term);
            return new JsonResult(d.Items); 
        }
        /// <summary>
        /// ��ע�����أ��Ա㷢����Ϣ������
        /// </summary>
        /// <param name="id"></param>
        public async Task OnPost(long id)
        {
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var _ue = new UserExtend { Id = user.Id };
            var _t = new List<UserTeam>();
            _t.Add(new UserTeam {TeamId=id,UserExtendId= user.Id });
            
            await _testService.SetUserExtendAsync(new UserExtend
            {
                Id = user.Id,
                Team = _t 
            });
            StatusMessage = "���óɹ���";
        }
        /// <summary>
        /// ����belongteam������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult>  OnPostZdlAsync(long id)
        {
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            await _testService.SetUserExtendAsync(new UserExtend
            {
                Id = user.Id,
                BelongTeamId = id,
                MyTeams = id.ToString()
            });
            return RedirectToPage("./my");//"./dd.my" is no need.
        }
         
    }
}