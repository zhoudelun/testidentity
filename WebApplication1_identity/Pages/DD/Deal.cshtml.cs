using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1_identity.Data;
using WebApplication1_identity.Services;

namespace WebApplication1_identity.Pages.DD
{
    [Authorize]
    public class DealModel : BaseModel
    {
        public DealModel(
            ITestService testService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache) : base(testService, userManager, memoryCache)
        {
        } 
        [BindProperty(SupportsGet =true)]
        public InputModel Input { get; set; }
        public Deal MyDeal { get; private set; }
        public bool IsPublisher { get; private set; }

        public class InputModel
        {
            //[Required(ErrorMessage ="标题必填")] 
            [MaxLength(50, ErrorMessage = "内容不超过50个字")]
            public string Remark { get; set; }
            public int InfoId { get;
                //internal 
                    set; }


            public int  Id { get; set; }
            public string Comment { get; set; }
            public string Reply { get; set; }
        }
        /// <summary>
        /// show deal of mine 
        /// </summary>
        /// <param name="Id"></param>
        public async Task OnGetAsync(int id)
        {
            //是自己，直接跳转到查看申请
            IsPublisher = _testService.DealCheckHasApplyedAsync(id, CurrentUser.Id); 
            Input.InfoId = id;
            MyDeal = await _testService. DealGetMyByIdAsync(id,  CurrentUser.Id);
        }
       
        /// <summary>
        /// 申请合作
        /// </summary>
        /// <param name="Id">信息id</param>
      
        public  void  OnGetApplyAsync(int id)
        {
            Input.InfoId = id; 
        }
        /// <summary>
        /// 做出回复，确定合作
        /// </summary>
        /// <param name="Id">合作id</param>
        /// <param name="InfoId">信息id</param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetChooseAsync(int id, int infoId)
        {
            var deal = new Deal { Id = id, InfoId = infoId, Status= EnumDealStatus.成功,ChooseTime= DateTime.Now, DDUserId =CurrentUser.Id };
            await _testService.DealUpdateAsync(deal);
            return RedirectToPage("./MyDeal"//,new { handler = "Choose" }
                );
        }

      
        /// <summary>
        /// 提交申请合作
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            var deal = new Deal { Remark = Input.Remark, InfoId = Input.InfoId, DDUserId = CurrentUser.Id };
            await _testService.DealCreateAsync(deal);
            return RedirectToPage("./Deal",new { id= Input.InfoId});
        }
    }
}