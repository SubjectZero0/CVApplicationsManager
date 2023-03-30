namespace CVApplicationsManager.Models
{
    public class CvApplicationModel : ApplicantModel
    {
        public int Id { get; set; }

        public string? CvBlob { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
