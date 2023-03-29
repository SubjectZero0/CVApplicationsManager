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
        [DataType(DataType.PhoneNumber)]
        public string? Mobile { get; set; }

        [Display(Name = "Education Degree")]
        public DegreesViewModel? Degrees { get; set; }

        [Display(Name = "Education Degree")]
        public int? DegreeId { get; set; }

        [Display(Name = "Upload your CV")]
        public string? CvBlob { get; set; }

    }
}