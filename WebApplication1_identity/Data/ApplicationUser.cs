using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1_identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(20, ErrorMessage ="不超过20字符")]
        [Display(Name ="我的名言")]
        public string MyWords { get; set; }


        public long? BelongTeamId { get; set; } = null;

        public Team BelongTeam { get; set; }//所属

        public string MyTopic { get; set; }//我关注的topic
        public string MyTags { get; set; }//我关注的tag
        public string MyTeams { get; set; }//我关注的村子。第一个是所属
        public int Score { get; set; }//积分鼓励用 //不设置会自动为0.

        public ICollection<Info> Info { get; set; }

        public ICollection<UserTopic> Topic { get; set; }//我关注的topic
        public ICollection<UserTeam> Team { get; set; }
    }
}
