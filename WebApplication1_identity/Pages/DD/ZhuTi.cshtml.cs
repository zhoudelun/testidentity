using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1_identity.Data;
using WebApplication1_identity.Services;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplication1_identity.Pages.DD
{
    public class ZhuTiModel : BaseModel
    {
        public ZhuTiModel(ITestService testService, UserManager<ApplicationUser> userManager, IMemoryCache memoryCache) : base(testService, userManager, memoryCache)
        {
        }
         
        [TempData]
        public string StatusMessage { get; set; }

        public IPagedList<Topic>  MyTopic { get; set; }
        public IPagedList<Topic> TeamTopic { get; set; }
        public  IList<Topic> AllTopic { get; set; }  
        public  async Task<IActionResult>  OnGetAsync()
        {
            var id = CurrentUser.Id;
            MyTopic =  await _testService.GetTopicAsync(id);//我的
            AllTopic = _testService.GetAllTopicAsnyc(11).Result.Items;//所有可用的

            return Page();             
        }
  
        /// <summary>
        /// 并没用到
        /// 异步获取team的topic
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetTeamAsync()
        {
            var id = CurrentUser.Id;
            TeamTopic = await _testService.GetTeamTopicAsnyc(id) ;
            return new JsonResult(TempData);         
        }
        /// <summary>
        /// 设置某人的topic
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public async Task<ActionResult> OnPostSetMyAsync(int[] tid)
        {
            if (ModelState.IsValid)
            {
                var b= await _testService.SetTopicAsync(CurrentUser.Id,tid);
                return RedirectToPage("./ZhuTi"); //No page named '.ZhuTi' matches the supplied values.
                //return RedirectToAction(".ZhuTi");//  No route matches the supplied values.Must have a get of actionrresult.
            }          
            return Page();
        }
             
    }

   
}