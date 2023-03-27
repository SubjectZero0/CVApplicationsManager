﻿using CVApplicationsManager.Contracts;
using CVApplicationsManager.Data;
using CVApplicationsManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVApplicationsManager.Repositories
{
    public class CvApplicationsRepository : GenericRepository<CvApplicationModel>, ICvApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public CvApplicationsRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}