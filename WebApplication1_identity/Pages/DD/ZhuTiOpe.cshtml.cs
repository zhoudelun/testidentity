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
            [MinLength(2,ErrorMessage ="������2����")]
            [MaxLength(10, ErrorMessage = "������10����")]
            public string Title { get; set; }

            [MaxLength(20)]
            public string Des { get; set; }
        }
        /// <summary>
        /// ����һ������
        /// ҳ����أ���Ӧ�ü���֮��Ķ�������ֵ�����ҳ�档
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
                    ModelState.AddModelError(string.Empty, "�Ѿ�������");
                    return Page();//ֱ�ӵ���view��û����OnGet. ���ԣ�post��ҳ�治Ҫ������ʾ����Ϣ����ֳ�ȥ�ɡ��������첽ajax��
                }
            }
            return Page();//error.
        }

      
    }
}