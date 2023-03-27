using CVApplicationsManager.Contracts;
using CVApplicationsManager.Data;
using CVApplicationsManager.Models;

namespace CVApplicationsManager.Repositories
{
    public class CvApplicationsRepository : GenericRepository<CvApplicationModel>, ICvApplicationRepository
    {
        public CvApplicationsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
