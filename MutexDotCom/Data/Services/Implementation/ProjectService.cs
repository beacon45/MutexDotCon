using Microsoft.EntityFrameworkCore;
using MutexDotCom.Data.Helper;
using MutexDotCom.Data.Services.Abstract;
using MutexDotCom.Data.ViewModels;
using MutexDotCom.Models;
using System.Threading.Tasks;

namespace MutexDotCom.Data.Services.Implementation
{
    public class ProjectService : EntityBaseRepo<Project> , IProjectService
    {
        private readonly ApplicationDbContext _context;
        public ProjectService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProjectAsync(NewProjectVM data)
        {
            var newProject=new Project() 
            {
                Name = data.Name,
                ProbelemStatement = data.ProbelemStatement,
                ClientName = data.ClientName,
                ImageURL = data.ImageURL,
                InitialDate = data.InitialDate,
                EndDate = data.EndDate,
                ManagerId = data.ManagerIds,
            };
            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();

            foreach (var devId in data.DevelopersIds)
            {
                var newDevProject = new DevProjects()
                {
                    ProjectId = newProject.Id,
                    DevId = devId,
                    
                };
                await _context.DevProjects.AddAsync(newDevProject);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var projectDetails=await _context.Projects
                .Include(d=>d.Department)
                .Include(m=>m.Manager)
                .Include(dp=>dp.DevProjects)
                .ThenInclude(dev=>dev.Developer)
                .FirstOrDefaultAsync(n=>n.Id==id);
            return projectDetails;
        }

        public async Task<NewProjectDDVM> GetProjectServiceValues()
        {
            var response = new NewProjectDDVM()
            {
                Departments = await _context.Departments.OrderBy(n => n.Name).ToListAsync(),
                Managers = await _context.Managers.OrderBy(n => n.Name).ToListAsync(),
                Developers = await _context.Developers.OrderBy(n => n.Name).ToListAsync()
            };
            return response;
        }

        public async Task UpdateProjectAsync(NewProjectVM data)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(n=>n.Id==data.Id);

            if (dbProject != null)
            {
                dbProject.Name = data.Name;
                dbProject.ProbelemStatement = data.ProbelemStatement;
                dbProject.ClientName = data.ClientName;
                dbProject.ImageURL = data.ImageURL;
                dbProject.InitialDate = data.InitialDate;
                dbProject.EndDate = data.EndDate;
                dbProject.ManagerId = data.ManagerIds;

                await _context.SaveChangesAsync();
            }

            // remove Devs
            var devsExit= _context.DevProjects.Where(n=>n.ProjectId==data.Id).ToList();
            _context.DevProjects.RemoveRange(devsExit);
            await _context.SaveChangesAsync();

            //Add Devs
            foreach (var devId in data.DevelopersIds)
            {
                var newdevProject = new DevProjects()
                {
                    ProjectId = data.Id,
                    DevId = devId,
                };
                await _context.DevProjects.AddAsync(newdevProject);
            }
            await _context.SaveChangesAsync();
        }
    }
}
