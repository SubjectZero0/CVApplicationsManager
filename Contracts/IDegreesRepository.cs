using CVApplicationsManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVApplicationsManager.Contracts
{
    public interface IDegreesRepository : IGenericRepository<DegreesModel>
    {
        Task DeleteUnusedAsync(int? id);
    }
}