using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVApplicationsManager.Data;
using CVApplicationsManager.Models;
using CVApplicationsManager.Contracts;
using AutoMapper;
using CVApplicationsManager.Views;

namespace CVApplicationsManager.Controllers
{
    public class CvApplicationsController : Controller
    {
        private readonly ICvApplicationRepository _cvApplicationRepository;
        private readonly IMapper _mapper;

        public CvApplicationsController(ICvApplicationRepository cvApplicationRepository,
                                        IMapper mapper)
        {
            this._cvApplicationRepository = cvApplicationRepository;
            this._mapper = mapper;
        }

        // GET: CvApplications
        public async Task<IActionResult> Index()
        {
            var applications = await _cvApplicationRepository.GetAllAsync();
            var applicationsVM = _mapper.Map<List<CvApplicationViewModel>>(applications);

            return View(applicationsVM);
        }

        // GET: CvApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var applications = await _cvApplicationRepository.GetAsync(id);
            var applicationsVM = _mapper.Map<CvApplicationViewModel>(applications);

            return View(applicationsVM);
        }

        // GET: CvApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CvApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CvApplicationViewModel applicationVM)
        {
            if (ModelState.IsValid)
            {
                var application = _mapper.Map<CvApplicationModel>(applicationVM);
                application.DateCreated = DateTime.Now;
                await _cvApplicationRepository.AddAsync(application);

                return RedirectToAction(nameof(Index));
            }
            return View(applicationVM);
        }

        // GET: CvApplications/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.CvApplications == null)
        //    {
        //        return NotFound();
        //    }

        //    var cvApplicationModel = await _context.CvApplications.FindAsync(id);
        //    if (cvApplicationModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(cvApplicationModel);
        //}

        //// POST: CvApplications/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,CvBlob,DateCreated,Firstname,Lastname,Email,Mobile,DegreeId")] CvApplicationModel cvApplicationModel)
        //{
        //    if (id != cvApplicationModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(cvApplicationModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CvApplicationModelExists(cvApplicationModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(cvApplicationModel);
        //}

        //// GET: CvApplications/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.CvApplications == null)
        //    {
        //        return NotFound();
        //    }

        //    var cvApplicationModel = await _context.CvApplications
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (cvApplicationModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cvApplicationModel);
        //}

        //// POST: CvApplications/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.CvApplications == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.CvApplications'  is null.");
        //    }
        //    var cvApplicationModel = await _context.CvApplications.FindAsync(id);
        //    if (cvApplicationModel != null)
        //    {
        //        _context.CvApplications.Remove(cvApplicationModel);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CvApplicationModelExists(int id)
        //{
        //  return (_context.CvApplications?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
