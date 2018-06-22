using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Data
{

    /// <summary>
    /// 信息发布
    /// 最直接的Data，produce
    /// 
    /// </summary>
    public class Info:EntityBase
    { 

        public int TopicId { get; set; }
        public Topic Topic { get; set; }//主题只能是一个了
        public string TagsId { get; set; }//dot split ints.store for show easy.

        public ICollection<InfoTag> Tags { get; set; }//包含那些tag.for search from tag.
        [MaxLength(10)]
        public string  Tag { get; set; }//决定弃用tag表，省去关联查询。仅一个tag。----此举，tag上升为副标题概念。
        public string TeamsId { get; set; }//没有用到？准备弃用
        public ICollection<InfoTeam> Teams { get; set; }//显示在那些团体可见

        [MaxLength(20)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Content { get; set; }
        public string DDUserId { get; set; }
        public ApplicationUser DDUser { get; set; }//作者
        public DateTime CreateTime { get; set; }//发帖日期
        //[DisplayFormat(NullDisplayText = "暂无")]
        public int InfoStatus { get; set; }//枚举mysql可能不支持
    }

    public class InfoTag
    {
        public int Id { get; set; }
        public int InfoId { get; set; }
        public Info Info { get; set; }

        public int TagId  { get; set; }
        public Tag Tag { get; set; }
    }
    public class InfoTeam
    {
        public int Id { get; set; }
        public int InfoId { get; set; }
        public Info Info { get; set; }

        public long TeamId { get; set; }
        public Team Team { get; set; }

    }
}
