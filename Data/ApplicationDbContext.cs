using CVApplicationsManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CVApplicationsManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DegreesModel> Degrees { get; set; }

        public DbSet<CvApplicationModel> CvApplications { get; set; }

    }
}