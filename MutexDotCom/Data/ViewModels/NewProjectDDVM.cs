using MutexDotCom.Data.Services.Implementation;
using MutexDotCom.Models;

namespace MutexDotCom.Data.ViewModels
{
    public class NewProjectDDVM
    {
        public NewProjectDDVM()
        {
            Departments = new List<Department>();
            Managers = new List<Manager>();
            Developers = new List<Developer>();     
        }
        public List<Department> Departments { get; set; }
        public List<Manager> Managers { get; set; }
        public List<Developer> Developers { get; set; }
    }
}
