using CVApplicationsManager.Contracts;
using CVApplicationsManager.Data;
using CVApplicationsManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CVApplicationsManager.Repositories
{
    public class DegreesRepository : GenericRepository<DegreesModel>, IDegreesRepository
    {
        private readonly ApplicationDbContext _context;

        public DegreesRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task DeleteUnusedAsync(int? id)
        {
            // Check if degree id is null
            if (id is null)
            {
                throw new Exception("No records found with this Id");
            }

            // Check if the degree is being used in CV Applications
            if (await _context.CvApplications.AnyAsync(x => x.DegreeId == id))
            {
                throw new Exception($"Unable to delete used degree with Id : {id}");
            }

            await DeleteAsync(id);

        }
    }
}