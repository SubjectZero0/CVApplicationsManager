using AutoMapper;
using CVApplicationsManager.Contracts;
using CVApplicationsManager.Models;
using CVApplicationsManager.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVApplicationsManager.Controllers
{
    public class DegreesController : Controller
    {
        private readonly IDegreesRepository _degreesRepository;
        private readonly IMapper _mapper;

        public DegreesController(IDegreesRepository degreesRepository, IMapper mapper)
        {
            this._degreesRepository = degreesRepository;
            this._mapper = mapper;
        }

        // GET: Degrees
        public async Task<IActionResult> Index()
        {
            var degrees = await _degreesRepository.GetAllAsync();
            var degreesVM = _mapper.Map<List<DegreesViewModel>>(degrees);

            return View(degreesVM);
        }

        // GET: Degrees/Create
        public async Task<IActionResult> Create()
        {
            var degree = new CreateDegreeViewModel();
            return View(degree);
        }

        // POST: Degrees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDegreeViewModel degreeVM)
        {
            if (ModelState.IsValid)
            {
               
                var degree = _mapper.Map<DegreesModel>(degreeVM);

                await _degreesRepository.AddAsync(degree);

                return RedirectToAction(nameof(Index));
            }

            return View(degreeVM);
        }

        // GET: Degrees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var degree = await _degreesRepository.GetAsync(id);
            var degreeVM = _mapper.Map<EditDegreeViewModel>(degree);

            return View(degreeVM);
        }

        // POST: Degrees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditDegreeViewModel degreeVM)
        {
            var degree = await _degreesRepository.GetAsync(id);

            if (ModelState.IsValid)
            {
                _mapper.Map(degreeVM, degree);
                await _degreesRepository.UpdateAsync(degree);

                return RedirectToAction(nameof(Index));
            }

            return View(degreeVM);
        }

        // POST: Degrees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _degreesRepository.DeleteUnusedAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
