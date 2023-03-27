using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CVApplicationsManager.Views
{
    public class DegreesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Degree Title")]
        public string? DegreeName { get; set; }
    }
}
