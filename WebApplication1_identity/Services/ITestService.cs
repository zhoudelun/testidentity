using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_identity.Data;

namespace WebApplication1_identity.Services
{
    public interface ITestService
    {
        Task<TestTable> GetById(int id);
        Task<TestTable> GetCurrentUserAsync(ApplicationUser user);
    }
}
