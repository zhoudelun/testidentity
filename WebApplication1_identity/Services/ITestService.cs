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
    public interface ITestService
    {
        Task<ApplicationUser> Meth();
        Task<TestTable> GetById(int id);
        Task<TestTable> GetCurrentUserAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserExtendAsync(string Id);
        Task<ApplicationUser> GetInfoInputAsync(string Id);
        Task SetUserExtendAsync(ApplicationUser userExtend);

        Task<Team> GetTeamAsync(Expression<Func<Team, bool>> predicate);
        Task<IPagedList<TeamDTO>> GetTeamAsync(string name);
        Task<IPagedList<Topic>> GetTopicAsync(string Id);
        Task<bool> SetTopicAsync(string Id, int[] tid);
        Task<IPagedList<Topic>> GetTeamTopicAsnyc(string Id);
        Task<IPagedList<Topic>> GetTeamTopicByTeamIdAsnyc(long teamid);
        Task<bool> AddTopic(Topic topic);

        Task<IPagedList<Topic>> GetAllTopicAsnyc(int c = 0);
        Task<IPagedList<Topic>> GetForAuditAsync(int c = 10);
        Task<IPagedList<Topic>> GetMyAddTopic(string Id);
        Task<bool> TopicAuditAsync(int[] tid);
        Task<Topic> TopicGetByIdAsync(int Id);


        Task<bool> FaCreateAsync(Info  input);
        Task<IPagedList<Info>> FaGetByUserIdAsync(string Id,int pid);
        Task<IPagedList<Info>> FaGetBySearchAsync(InfoSearchDTO info);
        Task<Info> FaGetByIdAsync(int Id);
        /// <summary>
        /// 根据infoid获取 申请合作记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<IPagedList<Deal>> DealGetByIdAsync(int Id,int pid);
        /// <summary>
        /// 乙方接收的
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        Task<IPagedList<Deal>> DealGetMyAsync(string uid,int pid);
        /// <summary>
        /// 甲方发起的
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        Task<IPagedList<Deal>> DealGetMyChooseAsync(string uid, int pid);
        Task<bool> DealCreateAsync(Deal deal);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> DealUpdateAsync(Deal deal);
    }
}
