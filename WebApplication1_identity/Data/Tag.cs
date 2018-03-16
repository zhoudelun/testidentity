using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Data
{

    /// <summary>
    /// Tags Table.
    /// 估计有10000个
    /// </summary>
    public class Tag
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Title { get; set; }

        public string    DDUserId { get; set; }
        public UserExtend DDUser { get; set; }//创建者

        public int Socre { get; set; }//推荐程度 越大使用频率越高-->机制？确保高频tag？
        public ICollection<InfoTag> Infos { get; set; }
        public ICollection<TeamTag> TeamTag { get; set; }
    }
}
