using MutexDotCom.Data.Helper;
using System.ComponentModel.DataAnnotations;

namespace MutexDotCom.Models
{
    public class Department : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo")]
        [Required(ErrorMessage = "logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Department Name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        //Relation
        public List<Project> Projects { get; set; }
    }
}
