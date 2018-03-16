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
    /// 一个model只能有一个page显示属性
    /// 如果想在一个model，分别显示多个page？——那就整块不相干的都隐藏
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
        public UserExtend UserExtend { get; set; } 
        public IList<Topic> MyAddTopic { get; set; }
      
        /// <summary>
        /// 测试
        /// 可用于get
        /// submit当然不行
        /// </summary>
        /// <returns></returns>
        public ActionResult OnGetAA()
        {
            testM();
            return Page();
        }
        /// <summary>
        /// 与async方法的区别是：await 和 rsult的 取舍省略。
        /// 确切的，result是等候。功能同await。
        /// </summary>
        public void testM()
        {
            var ue = _testService.Meth();
            UserExtend = ue.Result; 
        }
        /// <summary>
        /// 用户信息--1所属地，2关注主题
        /// </summary>
        /// <returns></returns>
        public async Task OnGetAsync()
        {
            //IsOk = 101;//页面加载时首先处理，所以页面会显示101.
            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name); 
            UserExtend = await _testService.GetUserExtendAsync(user.Id);
        }


        /// <summary>
        /// 用户的添加的主题
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGetMyAddTopic()
        {
            ApplicationUser user =   _userManager.FindByNameAsync(User.Identity.Name).Result;
            MyAddTopic = _testService.GetMyAddTopic(user.Id).Result.Items;
            return Page();
        }
        /// <summary>
        /// 修改逻辑
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