using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_identity.Services;
using WebApplication1_identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1_identity.Pages.DD
{
    /// <summary>
    /// һ��modelֻ����һ��page��ʾ����
    /// �������һ��model���ֱ���ʾ���page�������Ǿ����鲻��ɵĶ�����
    /// </summary>

    [Authorize]
    public class MyModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITestService _testService;
        public MyModel(ITestService testService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _testService = testService;
        }
        public int IsOk { get; set; } = 100;
        public ApplicationUser UserExtend { get; set; } 
        public IList<Topic> MyAddTopic { get; set; }
      
        /// <summary>
        /// ����
        /// ������get
        /// submit��Ȼ����
        /// </summary>
        /// <returns></returns>
        public ActionResult OnGetAA()
        {
            testM();
            return Page();
        }
        /// <summary>
        /// ��async�����������ǣ�await �� rsult�� ȡ��ʡ�ԡ�
        /// ȷ�еģ�result�ǵȺ򡣹���ͬawait��
        /// </summary>
        public void testM()
        {
            var ue = _testService.Meth();
            UserExtend = ue.Result; 
        }
        /// <summary>
        /// �û���Ϣ--1�����أ�2��ע����
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            //IsOk = 101;//ҳ�����ʱ���ȴ�������ҳ�����ʾ101.
            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name); 
            UserExtend = await _testService.GetUserExtendAsync(user.Id);
        }


        /// <summary>
        /// �û�����ӵ�����
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGetMyAddTopic(string msg="")
        {
            ApplicationUser user =   _userManager.FindByNameAsync(User.Identity.Name).Result;
            MyAddTopic = _testService.GetMyAddTopic(user.Id).Result.Items;
            return Page();
        }
        /// <summary>
        /// �޸��߼�
        /// </summary>
        /// <param name="id"></param>
        public   void OnPostAsync(long id)
        {
            //ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            //   _testService.SetUserExtend(new UserExtend {
            //        Id = user.Id,BelongTeamId=id,
            //        MyTeams =id.ToString()               
            //    });
        }
    }
}