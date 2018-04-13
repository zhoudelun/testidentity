using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Data
{
    /// <summary>
    /// User扩展信息
    /// </summary>
    public class UserExtend
    {
        public string Id { get; set; }//Guid 关联
       
    }

    /// <summary>
    /// 行政单位
    /// 省市县乡村5级
    /// 数据来自mysql表
    /// </summary>
    public class Team
    {

        [Key]
       
        public long Id { get; set; }//int不够： 从 -2^31 (-2,147,483,648) 到 2^31 - 1 (2,147,483,647) 的整型数据（所有数字）


        public long? ParentCode { get; set; }
        [ForeignKey("ParentCode")]
         
        public virtual Team Parent { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
        public int Level { get; set; }//一共5级 全在一起了 

      //  public ICollection<InfoTeam> Infos { get; set; }
        //public ICollection<TeamTopic> Topic { get; set; }
        //public ICollection<TeamTag> TeamTag { get; set; }
    }
    public class Team2
    {

        [Key]

        public long Id { get; set; }//int不够： 从 -2^31 (-2,147,483,648) 到 2^31 - 1 (2,147,483,647) 的整型数据（所有数字）


        public long? ParentCode { get; set; }
        [ForeignKey("ParentCode")]

        public virtual Team Parent { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }
        public int Level { get; set; }//一共5级 全在一起了 

        //  public ICollection<InfoTeam> Infos { get; set; }
        //public ICollection<TeamTopic> Topic { get; set; }
        //public ICollection<TeamTag> TeamTag { get; set; }
    }
    public class TeamTopic
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Topic Topic { get; set; }
    }
    public class TeamTag
    {
        public int Id { get; set; }
        public Team Team { get; set; }
        public Tag  Tag { get; set; }
    }
    
}
