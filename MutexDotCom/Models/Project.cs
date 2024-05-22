using MutexDotCom.Data.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MutexDotCom.Models
{
    public class Project : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProbelemStatement { get; set; }
        public string ClientName { get; set; }
        public string ImageURL { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        
        //Relation
        public List<DevProjects> DevProjects { get; set; }
        
        //Department
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        
        //Manager
        public int ManagerId {  get; set; }
        [ForeignKey("ManagerId")]
        public Manager Manager { get; set; }
    }
}
