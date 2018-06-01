using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Data
{
    /// <summary>
    /// 查找信息info
    /// </summary>
    public class InfoSearchDTO
    {
        /// <summary>
        /// 当前页数
        /// </summary>
        public int Pid { get; set; } = 0;
        /// <summary>
        /// 主题
        /// </summary>
        public int TopicId { get; set; }
        /// <summary>
        /// 所在地
        /// </summary>
        public long TeamId { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public int TagId { get; set; }
    }
}
