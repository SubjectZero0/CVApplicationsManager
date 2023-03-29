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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new DegreesConfig()); //initializes DbContext with Degrees
        }

        public DbSet<DegreesModel> Degrees { get; set; }

        public DbSet<CvApplicationModel> CvApplications { get; set; }

    }
}