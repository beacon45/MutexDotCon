using MutexDotCom.Data.ViewModels;
using MutexDotCom.Models;
using MutexDotCom.Data.Helper;

namespace MutexDotCom.Data.Services.Abstract
{
    public interface IProjectService : IEntityBaseRepo<Project>
    {
        Task<Project> GetProjectByIdAsync(int id);
        Task<NewProjectDDVM> GetProjectServiceValues();
        Task AddNewProjectAsync(NewProjectVM data);
        Task UpdateProjectAsync(NewProjectVM data);

    }
}
