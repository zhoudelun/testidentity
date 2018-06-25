using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1_identity.Data;
using WebApplication1_identity.Services;

namespace WebApplication1_identity.Pages.DD
{
    [Authorize]
    public class DealReplyModel :BaseModel
    {


        public DealReplyModel(
        ITestService testService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache) : base(testService, userManager, memoryCache)
        {
        }
        [BindProperty(SupportsGet = true)]
        public InputModel Input { get; set; }


        public class InputModel
        {
            //[Required(ErrorMessage ="标题必填")] 
            [MaxLength(50, ErrorMessage = "内容不超过50个字")]
            public string Remark { get; set; }
            public int Id { get; set; }
        }
        /// <summary>
        /// 给个差评去
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public void OnGetAsync(int Id )
        {
            Input.Id = Id;
          
        }


        public async Task<IActionResult> OnPostAsync()
        {
            var deal = new Deal { Id = Input.Id,   Reply = Input.Remark, Status = EnumDealStatus.回复, DDUserId = CurrentUser.Id };
            await _testService.DealUpdateAsync(deal);
            return RedirectToPage("./DealUQ", new { id = Input.Id });
        }
    }
}