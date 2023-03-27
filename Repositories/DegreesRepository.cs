using CVApplicationsManager.Contracts;
using CVApplicationsManager.Data;
using CVApplicationsManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVApplicationsManager.Repositories
{
    public class DegreesRepository : GenericRepository<DegreesModel>, IDegreesRepository
    {
        private readonly ApplicationDbContext _context;

        public DegreesRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}