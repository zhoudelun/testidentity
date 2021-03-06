﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Data
{

    /// <summary>
    /// Tags Table.
    /// 估计有10000个
    /// 2018.6.22决定不使用tag表，tag以空格分割保留在info表的tags字段即可。
    /// </summary>
    public class Tag:EntityBase
    {
       
        [MaxLength(10)]
        public string Title { get; set; }

        public string    DDUserId { get; set; }
        public ApplicationUser DDUser { get; set; }//创建者

        public int Socre { get; set; }//推荐程度 越大使用频率越高-->机制？确保高频tag？
        public ICollection<InfoTag> Infos { get; set; }
        public ICollection<TeamTag> TeamTag { get; set; }
    }


}
