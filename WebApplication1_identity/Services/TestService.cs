using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication1_identity.Data;
using WebApplication1_identity.Pages.DD;

namespace WebApplication1_identity.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationUser> Meth()
        {
            var repo = _unitOfWork.GetRepository<ApplicationUser>();
            var value = await repo.FindAsync("bce25988-d32c-4038-90bc-4d865a5355ee");
            return value;
        }
        public async Task<TestTable> GetById(int id)
        {
            var repo = _unitOfWork.GetRepository<TestTable>();
            if (await repo.FindAsync(1) == null)
            {
                await repo.InsertAsync(new TestTable { Name = "s32" });
                var i = await _unitOfWork.SaveChangesAsync();


            }
            return await repo.GetFirstOrDefaultAsync(f => f.Name == "s32", null, null, true);
        }

        public async Task<TestTable> GetCurrentUserAsync(ApplicationUser user)
        {
            var repo = _unitOfWork.GetRepository<TestTable>();
            var _d = await repo.FindAsync(1);
            _d.Name += user.UserName;
            repo.Update(_d);
            await _unitOfWork.SaveChangesAsync();
            return _d;
        }

        public async Task<IPagedList<TeamDTO>> GetTeamAsync(string name)
        {
            var x = await _unitOfWork.GetRepository<Team>()
                 .GetPagedListAsync<TeamDTO>(
                     s => new TeamDTO { id = s.Id, value = s.Name, title = s.Parent.Name },
                     w => w.Name == name);
            return x;
        }


        public async Task<Team> GetTeamAsync(Expression<Func<Team, bool>> predicate )
        {
            return await _unitOfWork.GetRepository<Team>() 
                .GetFirstOrDefaultAsync(predicate, null,
                null, true);
        }

        /// <summary>
        /// 获取用户信息
        /// 重点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>所属team，关注topic</returns>
        public async Task<ApplicationUser> GetUserExtendAsync(string Id)
        {
            var repo = _unitOfWork.GetRepository<ApplicationUser>();
            //var _d = await repo.GetFirstOrDefaultAsync(w => w.Id == Id, null, 
            //q => q.Include(i => i.BelongTeam), true);
            var _dtopic = await repo.GetFirstOrDefaultAsync(w => w.Id == Id, null,
                q => q.Include(i => i.BelongTeam)//attention. null???
                .Include(i => i.Topic).ThenInclude(ut => ut.Topic)
                .Include(i => i.Team).ThenInclude(ut => ut.Team),
                true);
            return _dtopic;
        }
        #region fabu
        /// <summary>
        /// 获取用户信息
        /// 为发布设置：关注team，关注topic，关注tag——必须先设置才可用。
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetInfoInputAsync(string Id)
        {
            var repo = _unitOfWork.GetRepository<ApplicationUser>();
            var _dt = await repo.GetFirstOrDefaultAsync(w => w.Id == Id, null,
                q => q//.Include(i => i.BelongTeam)
                    .Include(i => i.Topic).ThenInclude(ut => ut.Topic)//智能提示 
                    .Include(i => i.Team).ThenInclude(ut => ut.Team)
                    //.Include(i=>i.MyTags)//The property 'MyTags' is not a navigation property of entity type 'UserExtend'. The 'Include(string)' method can only be used with a '.' separated list of navigation property names.
                    ,
                true);

            return _dt;
        }
        #endregion
        [Obsolete("use the next async.")]
        public void SetUserExtend(ApplicationUser userExtend)
        {
            var repo = _unitOfWork.GetRepository<ApplicationUser>();
            ApplicationUser _d = repo.GetFirstOrDefault(w => w.Id == userExtend.Id, null, null, true);
            if (_d == null)
            {
                repo.Insert(userExtend);
            }
            else
            {
                repo.Update(_d);
            }

            _unitOfWork.SaveChanges();
            return;
        }
        /// <summary>
        /// 设置归属地
        /// 设置 关注地
        /// </summary>
        /// <param name="userExtend"></param>
        /// <returns></returns>
        public async Task SetUserExtendAsync(ApplicationUser userExtend)
        {
            var repo = _unitOfWork.GetRepository<ApplicationUser>();
            var _d = await repo.GetFirstOrDefaultAsync(w => w.Id == userExtend.Id, null, null, false);
            if (_d == null)
            {
                await repo.InsertAsync(userExtend);//
                _d = await repo.GetFirstOrDefaultAsync(w => w.Id == userExtend.Id, null, null, false);
            }

            if (userExtend.BelongTeamId > 0)
            {
                _d.BelongTeamId = userExtend.BelongTeamId;
                _d.MyTeams = $"{userExtend.BelongTeamId},{_d.MyTeams}".TrimEnd(','); //dot split it. it'is null when first? 
            }
            if (userExtend.Team != null)
            {
                _d.Team = _d.Team == null ? new List<UserTeam>() : _d.Team;
                _d.Team.Add(userExtend.Team.FirstOrDefault());//add the team
            }

            repo.Update(_d);

            await _unitOfWork.SaveChangesAsync();//throw exception if void but not Task.
            return;
        }
        #region Topic

        /// <summary>
        /// 获取其设置的topic 
        /// 非create
        /// </summary>
        /// <param name="Id">通过用户的id</param>
        /// <returns></returns>
        public async Task<IPagedList<Topic>> GetTopicAsync(string Id)
        {
            var repo = _unitOfWork.GetRepository<UserTopic>();
            return await repo.GetPagedListAsync<Topic>(
                s => s.Topic,
                w => w.UserExtend.Id == Id);
        }
        /// <summary>
        /// 获取team的topic
        /// 通过id 关联BelongTeam
        /// </summary>
        /// <param name="Id">用户id</param>
        /// <returns></returns> 
        public async Task<IPagedList<Topic>> GetTeamTopicAsnyc(string Id)
        {
            var r = _unitOfWork.GetRepository<ApplicationUser>();
            var x = await r.GetFirstOrDefaultAsync(u => u.Id == Id, null, null, true);//2methd with the same name, but 5 or 4 params.so need make the number.
            var teamid = x.BelongTeamId;//首先查到teamid

            var repo = _unitOfWork.GetRepository<TeamTopic>();//再去 关联表里找topic
            return await repo.GetPagedListAsync<Topic>(
                s => s.Topic,
                w => w.Team.Id == teamid,
                null,
                q => q.Include(i => i.Topic)
            );
        }
        public async Task<IPagedList<Topic>> GetTeamTopicByTeamIdAsnyc(long teamid)
        {
            //var r = _unitOfWork.GetRepository<UserExtend>();
            //var x = await r.GetFirstOrDefaultAsync(u => u.Id == Id, null, null, true);//2methd with the same name, but 5 or 4 params.so need make the number.
            //var teamid = x.BelongTeamId;//首先查到teamid

            var repo = _unitOfWork.GetRepository<TeamTopic>();//再去 关联表里找topic
            return await repo.GetPagedListAsync<Topic>(
                s => s.Topic,
                w => w.Team.Id == teamid,
                null,
                q => q.Include(i => i.Topic)
            );
        }
        /// <summary>
        /// 所有可用的topic，需检查关联count标识，大于10个即显示
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public async Task<IPagedList<Topic>> GetAllTopicAsnyc(int c = 0)
        {
            return await _unitOfWork.GetRepository<TopicAudit>()
                .GetPagedListAsync<Topic>(
                    s => s.Topic,
                    w => w.Count > c
                );
        }
        /// <summary>
        /// 待审核的
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public async Task<IPagedList<Topic>> GetForAuditAsync(int c = 10)
        {
            return await _unitOfWork.GetRepository<TopicAudit>()
                .GetPagedListAsync<Topic>(
                    s => s.Topic,
                    w => w.Count < c
                );
        }
        /// <summary>
        /// 获取某人添加的topic
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IPagedList<Topic>> GetMyAddTopic(string Id)
        {
            return await _unitOfWork.GetRepository<Topic>()
                .GetPagedListAsync<Topic>(
                    s => s,
                    w => w.DDUserId == Id,
                    null,
                    q => q.Include(t => t.TopicAudit)
                );
        }
        /// <summary>
        /// 设置某人的topic
        /// 关联记录表
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="tid"></param>
        /// <returns></returns>
        public async Task<bool> SetTopicAsync(string Id, int[] tid)
        {
            var _u = await GetUserExtendAsync(Id);
            var _mytopid = _u.Topic.Select(s => s.TopicId).ToArray();

            var r = _unitOfWork.GetRepository<UserTopic>();

            r.Delete(_u.Topic.Where(w => !tid.Contains(w.TopicId)));

            foreach (var item in tid.Except(_mytopid))
            {
                await r.InsertAsync(new UserTopic { UserExtendId = Id, TopicId = item });
            }


            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        /// <summary>
        /// topic审核--批量通过
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public async Task<bool> TopicAuditAsync(int[] tid)
        {
            var r = _unitOfWork.GetRepository<TopicAudit>();
            IEnumerable<TopicAudit> d = r.GetPagedListAsync<TopicAudit>(
                s => s,
                w => tid.Contains(w.TopicId),
                null,
                null,
                0, 100, false
                ).Result.Items;//result 就是await后的。
            foreach (var item in d)
            {
                item.Reason = "管理员批";
                item.Count = 100;
                item.CreatTime = DateTime.Now;
            }

            r.Update(d);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// 添加一个新tag
        /// 如果title存在不添加
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public async Task<bool> AddTopic(Topic topic)
        {
            var repo = _unitOfWork.GetRepository<Topic>();
            var r = await repo.GetFirstOrDefaultAsync<Topic>(s => s, f => f.Title == topic.Title);
            if (r != null)
            {
                return false;// has exist.
            }
            await repo.InsertAsync(topic);
            await _unitOfWork.SaveChangesAsync();

            var repo2 = _unitOfWork.GetRepository<TopicAudit>();//同事插入关联记录
            r = await repo.GetFirstOrDefaultAsync<Topic>(s => s, f => f.Title == topic.Title);
            await repo2.InsertAsync(new TopicAudit { CreatTime = DateTime.Now, Count = 0, TopicId = r.Id });
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        #endregion
        #region fabu

        public async Task<bool> FaCreateAsync(Info info )
        {
            var repo = _unitOfWork.GetRepository<Info>();
            await repo.InsertAsync(info);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IPagedList<Info>> FaGetByUserIdAsync(string Id,int pid)
        {
            var repo = _unitOfWork.GetRepository<Info>();
            return  await repo.GetPagedListAsync<Info>(
                s=>s,
                w => w.DDUserId == Id,
                null,null,pid); 
        }
        public async Task<Info> FaGetByIdAsync(int Id)
        {
            return await _unitOfWork.GetRepository<Info>()
                .GetFirstOrDefaultAsync(   f => f.Id == Id,null, 
                i=>i.Include(q=>q.Topic)
                ,true );
        }

        #endregion
    }
}
