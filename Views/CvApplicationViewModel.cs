using CVApplicationsManager.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVApplicationsManager.Views
{
    public class CvApplicationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string Lastname { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [MaxLength(10)]
        [MinLength(10)]
        public string? Mobile { get; set; }

        [Display(Name = "Degree Title")]
        public DegreesViewModel? DegreeName { get; set; }
        public int? DegreeId { get; set; }

        [Display(Name = "Upload your CV")]
        public string? CvBlob { get; set; }

        [Display(Name = "Date of Creation")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
    }
}
