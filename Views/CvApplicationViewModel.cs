using CVApplicationsManager.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVApplicationsManager.Views
{
    public class CvApplicationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(20)]
        [Required]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(20)]
        [Required]
        public string Lastname { get; set; }

        [Display(Name = "Email Address")]
        [MaxLength(60)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Mobile Number")]
        [MaxLength(10)]
        [MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string? Mobile { get; set; }

        [Display(Name = "Education Degree")]
        public DegreesViewModel? Degree { get; set; }

        [Display(Name = "Education Degree")]
        public int? DegreeId { get; set; }

        [Display(Name = "Upload your CV")]
        [MaxLength(60)]
        public string? CvBlob { get; set; }
    }
}