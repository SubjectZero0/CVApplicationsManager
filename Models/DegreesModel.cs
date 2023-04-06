using System.ComponentModel.DataAnnotations;

namespace CVApplicationsManager.Models
{
    public class DegreesModel
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string DegreeName { get; set; }
    }
}