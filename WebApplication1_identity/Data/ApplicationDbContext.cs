using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1_identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<TestTable> TestTable { get; set; }
        public DbSet<UserExtend> UserExtend { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TopicAudit> TopicAudit { get; set; }
        public DbSet<InfoTeam> InfoTeam { get; set; }
        public DbSet<InfoTag> InfoTag { get; set; }
        public DbSet<UserTopic> UserTopic { get; set; }
        public DbSet<UserTeam> UserTeam { get; set; }
        public DbSet<TeamTopic> TeamTopic { get; set; }
        public DbSet<TeamTag> TeamTag { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
     
}
