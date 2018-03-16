using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_identity.Data;
using System.ComponentModel.DataAnnotations;
using WebApplication1_identity.Services;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1_identity.Pages.DD
{
    public class ZhuTiOpeModel : BaseModel
    {
        public ZhuTiOpeModel(ITestService testService, UserManager<ApplicationUser> userManager) : base(testService, userManager)
        {
        }

        public void OnGet()
        {
            ;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        { 
            [MinLength(2,ErrorMessage ="不少于2个字")]
            [MaxLength(10, ErrorMessage = "不超过10个字")]
            public string Title { get; set; }

            [MaxLength(20)]
            public string Des { get; set; }
        }
        /// <summary>
        /// 新增一个主题
        /// 页面加载，不应该加载之外的东西。拆分到单独页面。
        /// </summary>
        /// <returns></returns>
        public ActionResult OnPostNew()
        {
            if (ModelState.IsValid)
            {
                var b = _testService.AddTopic(new Topic { Title = Input.Title, DDUserId = CurrentUser.Id, CreatTime = DateTime.Now, Des = Input.Des });
                if (b.Result)
                {
                    return RedirectToPage("./my","myaddtopic"); //RedirectToPage("./my?handler=myaddtopic"); //No page named './my?handler=myaddtopic' matches the supplied values.
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "已经存在了");
                    return Page();//直接到了view，没调用OnGet. 所以，post的页面不要包含显示的信息，拆分出去吧。或者用异步ajax。
                }
            }
            return Page();//error.
        }

      
    }
}