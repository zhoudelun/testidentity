using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;
using WebApplication1_identity.Services;
using Microsoft.Extensions.Logging;
using WebApplication1_identity.Data;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions; 

namespace WebApplication1_identity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITestService _testService;
        private readonly ILogger _logger;
        private readonly ApplicationDbContext db;
        private IMemoryCache _memoryCache;
        private const string cachekeyTopic = "Topic_list";
        private const string cachekeyInfo = "Info_list";
        private const string cachekeyTag = "Tag_list";
        private const string cachekeyNote = "Note_list";

        public IndexModel(ITestService testService, ILogger<IndexModel> logger
            , IMemoryCache memoryCache,ApplicationDbContext context)
        {
            _testService = testService;
            _logger = logger;
            db = context;
            _memoryCache = memoryCache;
            //_logger = logger.CreateLogger("WebApplication1_identity.Pages.IndexModel");
        }

        public IIdentity Identity1 { get; set; }
       
        public void OnGet()
        {
            _logger.LogInformation("测试", "{id}", 101);
            var ue = _testService.Meth();
            string s = ue.Result?.Id;

            Identity1 = User.Identity;
            _logger.LogWarning("jigngao", "{id}", 102);
            ListTopic=GetCahceList<Topic>(db.Topic,cachekeyTopic);
            ListInfo = GetCahceList<Info>(db.Info, cachekeyInfo);
            ListTag = GetCahceList<Tag>(db.Tag, cachekeyTag);
            ListNote = GetCahceList<Note>(db.Note, cachekeyNote);
        }

        private List<T> GetCahceList<T>(IQueryable<T> query,   string key)   where T: EntityBase
        {
            var list = new List<T>();
            if (!_memoryCache.TryGetValue(key, out list))
            {
                list =query.OrderByDescending(o=>o.Id).Take(5).ToList();
                _memoryCache.Set(key, list, TimeSpan.FromMilliseconds(24));
            }
            return list;
        }

        public List<Topic> ListTopic { get; set; }
        public List<Info> ListInfo { get; set; }
        public List<Tag> ListTag { get; set; }
        public List<Note> ListNote { get; set; }
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
