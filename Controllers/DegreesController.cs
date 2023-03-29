using AutoMapper;
using CVApplicationsManager.Contracts;
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

        // GET: DegreesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DegreesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DegreesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DegreesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DegreesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DegreesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DegreesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DegreesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
