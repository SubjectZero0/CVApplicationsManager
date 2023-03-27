namespace CVApplicationsManager.Models
{
    public class CvApplicationModel : AppllicantModel
    {
        public int Id { get; set; }

        public string? CvBlob { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
