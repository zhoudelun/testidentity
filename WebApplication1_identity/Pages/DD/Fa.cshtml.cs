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
            [Required(ErrorMessage ="�������")] 
            [MaxLength(20, ErrorMessage = "���ݲ�����10����")]
            public string Title { get; set; }

            [Required(ErrorMessage ="���ݱ���")]
            [MaxLength(100,ErrorMessage ="���ݲ�����50����")]
            public string Content { get; set; }

            //public ICollection<Team> LTeam { get; set; }

            //public Topic LTopic { get; set; }
            public int LTopic { get; set; }
            public long[] LTeam { get; set; }
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var _u = await _userManager.GetUserAsync(User);
            _u= await _testService.GetInfoInputAsync(_u.Id);
            var _l = _u.Topic.Select(s => s.Topic).ToList();
            if (_l == null || _l.Count() == 0)
            {
                StatusMessage = "�ȹ�ע������,���ܷ�����Ϣ:)";
                return RedirectToPage("./ZhuTi");
            }
            LTopic =new SelectList(_l, "Id","Title");
            LTeam = _u.Team.Select(s => s.Team).ToList();
            if (LTeam == null || LTeam.Count() == 0)
            {
                StatusMessage = "�����ù�ע�ĵط�,��������Ϣ����ʾ������:)";
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
                    ModelState.AddModelError(string.Empty, "��ʾλ�ñ��빴ѡһ��");
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
            return await OnGetAsync();//��Ȼ�����Ǻܺõ��߼���������û������ã����ǰ���ʾ��Ϣ���뿪����������Ҫ������Ҫô����������
        }
    }
}