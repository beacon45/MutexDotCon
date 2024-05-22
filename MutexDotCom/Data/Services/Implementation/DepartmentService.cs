using MutexDotCom.Data.Helper;
using MutexDotCom.Data.Services.Abstract;
using MutexDotCom.Models;

namespace MutexDotCom.Data.Services.Implementation
{
    public class DepartmentService : EntityBaseRepo<Department>, IDepartmentService
    {
        public DepartmentService(ApplicationDbContext context): base(context)
        {
            
        }

    }
}
