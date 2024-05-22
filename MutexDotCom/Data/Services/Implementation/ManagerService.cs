using MutexDotCom.Data.Helper;
using MutexDotCom.Data.Services.Abstract;
using MutexDotCom.Models;

namespace MutexDotCom.Data.Services.Implementation
{
    public class ManagerService : EntityBaseRepo<Manager>, IManagerService
    {
        public ManagerService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
