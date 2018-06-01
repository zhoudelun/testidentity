using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApplication1_identity.Data;
using WebApplication1_identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using StackExchange.Profiling;

namespace WebApplication1_identity.Pages.DD
{
    [Authorize]
    public class FaModel : BaseModel
    {
        public FaModel(ITestService testService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache) : base(testService, userManager, memoryCache)
        {
        }

        [TempData]
        public string StatusMessage { get; set; }
        public SelectList LTopic { get; set; }

        public IList<Team>  LTeam{ get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required(ErrorMessage ="标题必填")] 
            [MaxLength(20, ErrorMessage = "内容不超过10个字")]
            public string Title { get; set; }

            [Required(ErrorMessage ="内容必填")]
            [MaxLength(100,ErrorMessage ="内容不超过50个字")]
            public string Content { get; set; }

            //public ICollection<Team> LTeam { get; set; }

            //public Topic LTopic { get; set; }
            public int LTopic { get; set; }
            public long[] LTeam { get; set; }
        }
        public async Task<IActionResult> OnGetAsync()
        {
            //var _u = await _userManager.GetUserAsync(User);//通过User获取IdentityUser，包含了所有继承后的props.
            //_u = await _userManager.FindByIdAsync(_u.Id);//也可以通过id
            var _u = await _testService.GetInfoInputAsync(CurrentUser.Id) ;//或者直接通过Current.Id,自己写个，从数据库里获取
            var _l = _u.Topic.Select(s => s.Topic).ToList();
            if (_l == null || _l.Count() == 0)
            {
                StatusMessage = "先关注的主题,才能发布信息:)";
                return RedirectToPage("./ZhuTi");
            }
            LTopic =new SelectList(_l, "Id","Title");
            LTeam = _u.Team.Select(s => s.Team).ToList();
            if (LTeam == null || LTeam.Count() == 0)
            {
                StatusMessage = "先设置关注的地方,发布的信息将显示在那里:)";
                return RedirectToPage("./set");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostNewAsync()
        {
            if (ModelState.IsValid)
            { 
                if(Input.LTeam==null|| Input.LTeam.Count()==0)
                {
                    ModelState.AddModelError(string.Empty, "显示位置必须勾选一个");
                    return  await OnGetAsync(); 
                }
                var info = new Info
                {
                    Title = Input.Title,
                    Content = Input.Content,
                    DDUserId = CurrentUser.Id,
                    TopicId = Input.LTopic,
                    CreateTime= DateTime.Now
                };
                info.Teams = new List<InfoTeam>();
                foreach(var t in Input.LTeam)
                {
                    info.Teams.Add( new InfoTeam { TeamId = t, Info = info }); 
                }
                var b = await _testService.FaCreateAsync(info);
                return RedirectToPage("./myfa");
            }
            return await OnGetAsync();//虽然并不是很好的逻辑，但这样没错误。最好，还是把显示信息分离开？但这里需要的数据要么缓存起来。
        }
    }
}