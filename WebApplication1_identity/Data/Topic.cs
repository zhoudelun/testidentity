using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Data
{
    /// <summary>
    /// topic表，中心词表
    /// 以生产为主题，一起来！扩展生活所需
    /// 以需求者为中心，供给者为副
    /// 一个团体，大概10个关键词，估计叠加共100个
    /// 耕地（借用/租/付费），浇地（借用/公用排队/？有人要浇地么一起来啊），雇人（干活?我缺个帮手），进城（顺风/用车？谁有车借用，or一起去啊，我没车），打井，修路
    /// 卖地蛋（1.5一斤），卖大蒜（5毛）-->应集为一个？？tag应为大蒜/地蛋。。。所以，tag还是要留。
    /// 卖煎饼，鸡蛋，提供婚宴，一条龙等商业衍生品（农民息息相关）
    /// </summary>
    public class Topic
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Title { get; set; }
        public string Des { get; set; }//描述

        public string DDUserId { get; set; }//DDUserID must the same as the UserExtend ,this is string .if int will not well.
        public ApplicationUser DDUser { get; set; }//creater

        public DateTime CreatTime { get; set; }
        public ICollection<Info> Infos { get; set; }
        public ICollection<UserTopic> UserExtend { get; set; }
        public ICollection<Team> Team { get; set; }

        public TopicAudit TopicAudit { get; set; }

    }

    /// <summary>
    /// 主题create 确审表
    /// 与topic一对一
    /// 自动审核机制：超过一定数量的人
    /// 协助作用，人工确认为基础
    /// </summary> 
    public class TopicAudit
    {
        [Key]
        [ForeignKey("Topic")]//应该是默认的就是这个（与名字为Topic的关联）关系
        public int TopicId { get; set; }//即是外键，又是主键（mysql可能不支持外键?）

        public Topic Topic { get; set; }


        public int Count { get; set; }//count>10时，即可转正 
        [MaxLength(50)]
        public string Reason { get; set; }//返回user 未通过的结果原因等信息
        public DateTime CreatTime { get; set; }

    }
    public class UserTopic {
        public int Id { get; set; }
        public string    UserExtendId { get; set; }//添加了便于使用啊
        public ApplicationUser UserExtend { get; set; }

        public int TopicId { get; set; }//添加了便于使用啊
        public Topic Topic { get; set; }
    }
    public  class UserTeam
    {
        public int Id { get; set; }
        public string UserExtendId { get; set; }
        public ApplicationUser UserExtend { get; set; }
        public long TeamId { get; set; }
        public Team Team { get; set; }
    }
}
