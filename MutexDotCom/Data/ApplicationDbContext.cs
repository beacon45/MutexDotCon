using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MutexDotCom.Models;

namespace MutexDotCom.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevProjects>().HasKey(obj => new
            {
                obj.DevId,
                obj.ProjectId
            });
            modelBuilder.Entity<DevProjects>().HasOne(o=>o.Project).WithMany(o=>o.DevProjects).HasForeignKey(o=>o.ProjectId);
            modelBuilder.Entity<DevProjects>().HasOne(o => o.Developer).WithMany(o => o.DevProjects).HasForeignKey(o=>o.DevId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DevProjects> DevProjects { get; set; }
    }
}
