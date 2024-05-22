using MutexDotCom.Data.Helper;
using MutexDotCom.Data.Services.Abstract;
using MutexDotCom.Models;

namespace MutexDotCom.Data.Services.Implementation
{
    public class DeveloperService : EntityBaseRepo<Developer>, IDeveloperService
    {
        public DeveloperService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
