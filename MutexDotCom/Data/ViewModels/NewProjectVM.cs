using MutexDotCom.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MutexDotCom.Data.ViewModels
{
    public class NewProjectVM
    {
        public int Id { get; set; }
        
        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Display(Name = "Project description")]
        [Required(ErrorMessage = "Description is required")]
        public string ProbelemStatement { get; set; }

        [Display(Name = "Client Name")]
        [Required(ErrorMessage = "Name is required")]
        public string ClientName { get; set; }
        
        [Display(Name = "Project Image URL")]
        [Required(ErrorMessage = "Project URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Project start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime InitialDate { get; set; }

        [Display(Name = "Project end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        //Relation
        [Display(Name = "Select Devs")]
        [Required(ErrorMessage = "project Devs are required")]
        public List<int> DevelopersIds { get; set; }

        [Display(Name = "Select a Department")]
        [Required(ErrorMessage = "Project department is required")]
        public int DepartmentIds { get; set; }

        [Display(Name = "Select a Manager")]
        [Required(ErrorMessage = "Project Manager is required")]
        public int ManagerIds { get; set; }
    }
}
