using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_identity.Data;

namespace WebApplication1_identity.ViewComponents
{
    /// <summary>
    /// 使用单独的view
    /// razor page 可以在其model里实现？
    /// </summary>
    public class TopicRankList: ViewComponent
    {
        private readonly ApplicationDbContext db;
        private IMemoryCache _memoryCache;
        private string cachekey = "topicrank";
        public TopicRankList(ApplicationDbContext context,IMemoryCache memoryCache)
        {
            db = context;
            _memoryCache = memoryCache;
        }
        public IViewComponentResult Invoke(int count)
        {
            var items = new List<Topic>();
            if(!_memoryCache.TryGetValue(cachekey,out items))
            {
                items = GetRankTopics(count);
                _memoryCache.Set(cachekey, items,TimeSpan.FromMinutes(10));
            }
            return View(items);
        }

        private List<Topic> GetRankTopics(int count)
        {
            return db.Topic.OrderByDescending(o=>o.Id).Take(10).ToList();
        }
    }
}
