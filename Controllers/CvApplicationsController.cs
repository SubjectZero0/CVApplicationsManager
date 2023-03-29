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
        private readonly IDegreesRepository _degreesRepository;

        public CvApplicationsController(ICvApplicationRepository cvApplicationRepository,
                                        IMapper mapper,
                                        IDegreesRepository degreesRepository)
        {
            this._cvApplicationRepository = cvApplicationRepository;
            this._mapper = mapper;
            this._degreesRepository = degreesRepository;
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
        public async Task<IActionResult> Create()
        {
            var cvApplicationVM = new CvApplicationViewModel();
            var degrees = await _degreesRepository.GetAllAsync();
            ViewData["Degrees"] = new SelectList(degrees, "Id", "DegreeName");

            return View(cvApplicationVM);
        }

        // POST: CvApplications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CvApplicationViewModel applicationVM, IFormFile? inputFile)
        {
            if (ModelState.IsValid)
            {
                var application = _mapper.Map<CvApplicationModel>(applicationVM);
                application.DateCreated = DateTime.Now;

                if (inputFile is null)
                {
                    await _cvApplicationRepository.AddAsync(application);
                }
                else
                {
                    await _cvApplicationRepository.UpdateOrCreateWithFile(inputFile, application);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(applicationVM);
        }

        //GET: CvApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var application = await _cvApplicationRepository.GetAsync(id);
            var applicationVM = _mapper.Map<CvApplicationViewModel>(application);

            var degrees = await _degreesRepository.GetAllAsync();
            ViewData["Degrees"] = new SelectList(degrees, "Id", "DegreeName");

            return View(applicationVM);
        }

        // POST: CvApplications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CvApplicationViewModel applicationVM, IFormFile? inputFile)
        {
            if (id != applicationVM.Id)
            {
                return NotFound();
            }

            var application = await _cvApplicationRepository.GetAsync(id);

            if (application is null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (inputFile is null)
                    {
                        if (application.CvBlob is not null)
                        {
                            applicationVM.CvBlob = _mapper.Map<CvApplicationViewModel>(application).CvBlob;
                        }

                        _mapper.Map(applicationVM, application);
                        await _cvApplicationRepository.UpdateAsync(application);
                    }
                    else
                    {
                        await _cvApplicationRepository.UpdateOrCreateWithFile(inputFile, application);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CvApplicationExists(applicationVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationVM);
        }

        // POST: CvApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _cvApplicationRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CvApplicationExists(int id)
        {
            var cvApplicationExists = await _cvApplicationRepository.Exists(id);
            return cvApplicationExists;
        }
    }
}