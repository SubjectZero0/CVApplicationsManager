﻿using CVApplicationsManager.Models;
using CVApplicationsManager.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVApplicationsManager.Contracts
{
    public interface ICvApplicationRepository : IGenericRepository<CvApplicationModel>
    {
    }
}