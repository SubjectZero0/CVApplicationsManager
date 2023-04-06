using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVApplicationsManager.Views
{
    public class CreateDegreeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Degree Title")]
        [Required]
        [MaxLength(20)]
        public string DegreeName { get; set; }
    }
}