using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Ressource_Relationnel.Controllers
{
    public class RessourceController : Controller
    {
        // GET: RessourceController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RessourceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RessourceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RessourceController/Create
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

        // GET: RessourceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RessourceController/Edit/5
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

        // GET: RessourceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RessourceController/Delete/5
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
