using MutexDotCom.Data.Helper;
using System.ComponentModel.DataAnnotations;

namespace MutexDotCom.Models
{
    public class Developer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Skills")]
        [Required(ErrorMessage = "Skills are required")]
        public string Skills { get; set; }
        //Relation
        public List<DevProjects> DevProjects { get; set; }
    }
}
