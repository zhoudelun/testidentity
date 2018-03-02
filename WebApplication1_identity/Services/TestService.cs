using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_identity.Data;

namespace WebApplication1_identity.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TestTable> GetById(int id)
        {
            var repo =   _unitOfWork.GetRepository<TestTable>();
            if(await repo.FindAsync(1)==null)
            {
                await  repo.InsertAsync(new TestTable { Name = "s32" });
                var i=await _unitOfWork.SaveChangesAsync();

                
            }
            return await repo.GetFirstOrDefaultAsync(f => f.Name == "s32",null,null,true);
        }

        public async Task<TestTable> GetCurrentUserAsync(ApplicationUser user)
        {
            var repo = _unitOfWork.GetRepository<TestTable>();
            var _d =await repo.FindAsync(1);
            _d.Name += user.UserName;
            repo.Update(_d);
            await _unitOfWork.SaveChangesAsync();
            return _d;
        }
    }
}
