using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_identity.Data;
using Microsoft.AspNetCore.Identity;
using WebApplication1_identity.Services;

namespace WebApplication1_identity.Pages.Ma
{
    public class TopicAuditModel : BaseModel
    {
        public TopicAuditModel(ITestService testService, UserManager<ApplicationUser> userManager) : base(testService, userManager)
        {

        }
        public IList<Topic> ForAudit { get; set; }

        public void OnGet()
        {
            ForAudit = _testService.GetForAuditAsync().Result.Items;
        }
        /// <summary>
        /// ÉóºËÍ¨¹ý
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public async Task<ActionResult> OnPostAsync(int[] tid)
        {
            var b = await _testService.TopicAuditAsync( tid);
           // OnGet();//so ,should call it.But, if check null in view,this is noneed.
            return Page();// RedirectToAction(".ZhuTi");// return LocalRedirect(Url.GetLocalUrl(returnUrl));
        }
    }
}