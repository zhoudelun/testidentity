using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Data
{
    public class DealDto
    {
        public int InfoId { get; set; }//关联发布的信息
        public string DDUserId { get; set; }

        public string Remark { get; set; }
    }
}
