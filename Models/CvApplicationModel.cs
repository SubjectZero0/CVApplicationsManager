using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CVApplicationsManager.Models
{
    public class CvApplicationModel
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Firstname { get; set; }

        [MaxLength(20)]
        public string Lastname { get; set; }

        [MaxLength(60)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string? Mobile { get; set; }

        [ForeignKey("DegreeId")]
        public DegreesModel? Degree { get; set; }

        public int? DegreeId { get; set; }

        [MaxLength(60)]
        public string? CvBlob { get; set; }

        public DateTime DateCreated { get; set; }
    }
}