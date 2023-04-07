using System.ComponentModel.DataAnnotations.Schema;

namespace CVApplicationsManager.Models
{
    public class AppllicantModel
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string? Mobile { get; set; }

        [ForeignKey("DegreesModel")]
        public DegreesModel? DegreeName { get; set; }
        public int? DegreeId { get; set; }
    }
}
