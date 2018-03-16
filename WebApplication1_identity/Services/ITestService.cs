﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_identity.Data;
using WebApplication1_identity.Pages.DD;

namespace WebApplication1_identity.Services
{
    public interface ITestService
    {
        Task<UserExtend> Meth();
        Task<TestTable> GetById(int id);
        Task<TestTable> GetCurrentUserAsync(ApplicationUser user);
        Task<UserExtend> GetUserExtendAsync(string Id);
        Task<UserExtend> GetInfoInputAsync(string Id);
        Task SetUserExtendAsync(UserExtend userExtend);
       
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
        Task<bool> FaCreateAsync(Info  input);
        Task<IPagedList<Info>> FaGetByUserIdAsync(string Id,int pid);
        Task<Info> FaGetByIdAsync(int Id);
    }
}
