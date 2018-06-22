using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1_identity.Data
{
    public interface IsPublish
    {
        /// <summary>
        /// 发布字段标记
        /// </summary>
        bool?  IsPublish { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Team2> Team2 { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }//不加没数据
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

        public DbSet<Note> Note { get; set; }

//        InvalidOperationException: Cannot create a DbSet for 'Deal' because this type is not included in the model for the context.
//Microsoft.EntityFrameworkCore.Internal.InternalDbSet<TEntity>.get_EntityType()
        public DbSet<Deal> Deal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            ////批量过滤IsPublish
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(e => typeof(IsPublish).IsAssignableFrom(e.ClrType)))
            //{
            //    modelBuilder.Entity(entityType.ClrType).Property<bool?>("IsPublish");
            //    var parameter = Expression.Parameter(entityType.ClrType, "e");
            //    var body = Expression.Equal(
            //        Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(bool?) }, parameter, Expression.Constant("IsPublish")),
            //        Expression.Constant(true,typeof(bool?) )
            //        );
            //    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(body, parameter));
            //}
        }
    }
     
}
