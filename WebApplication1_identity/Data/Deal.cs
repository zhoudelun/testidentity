using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_identity.Data
{
    /// <summary>
    /// 合作申请记录表
    /// </summary>
    public class Deal:EntityBase
    {


        public string DDUserId { get; set; }
        public ApplicationUser DDUser { get; set; }//申请人

        public Info Info { get; set; }
        public int InfoId { get; set; }//关联发布的信息（发布人）



        public EnumDealStatus Status { get; set; }// 状态：默认0，1达成（发起方作出回复）


        //其它
        public string Remark { get; set; }//申请合作时留言

        public DateTime CreateTime { get; set; }// 日期
        public DateTime ChooseTime { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }//差评留言,可积累+日期
        [MaxLength(200)]
        public string Reply { get; set; }//发布人的回复,可积累+日期
    }
}
