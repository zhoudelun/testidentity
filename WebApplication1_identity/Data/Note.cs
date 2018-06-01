using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Data
{
    /// <summary>
    /// 新增note，公告
    /// </summary>
    public class Note :EntityBase
    {
        [MaxLength(10)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Content { get; set; }
    }
}
