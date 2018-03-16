using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;
using WebApplication1_identity.Services;

namespace WebApplication1_identity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITestService _testService;
        public IndexModel(ITestService testService)
        {
            _testService = testService;
        }

        public IIdentity Identity1 { get; set; }
        public string Myname { get; set; }
        public void OnGet()
        {
            var ue = _testService.Meth();
            string s = ue.Result.Id;
            Myname = User.Identity.Name;
            Identity1 = User.Identity;
        }

        ///// <summary>
        ///// next is the bad way.Must use async Task (never async void) or above.
        ///// it will call  props before ,so it will dispose().
        ///// this makes the null like the exc:
        ///// NullReferenceException: Object reference not set to an instance of an object.
        /////WebApplication1_identity.Pages.Index_Page+<ExecuteAsync>d__16.MoveNext() in Index.cshtml, line 6
        ///// </summary>
        //public async void OnGet()
        //{
        //    var ue = await _testService.Meth();
        //    string s = ue.Id;
        //    Myname = User.Identity.Name+"A";
        //    Identity1 = User.Identity;
        //}
    }
}
