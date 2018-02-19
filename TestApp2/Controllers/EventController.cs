using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp2.Data;
using TestApp2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApp2.Controllers
{
    public class EventController : Controller
    {
        private EventRepository eventRepository;

        public EventController()
        {
            this.eventRepository = CreateEventRepository();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Manage()
        {
            return View();
        }

        // GET: Organization/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organization/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([FromBody]EventViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                var entity = eventRepository.ConvertModelToEntity(model);
                eventRepository.AddRecord(entity);


                return Json(entity);
            }
            catch
            {
                return View();
            }
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Organization/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(string id, [FromBody]EventViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                var entity = eventRepository.ConvertModelToEntity(model, id);
                eventRepository.EditRecord(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Organization/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Organization/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(string id, [FromBody]EventViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var entity = eventRepository.ConvertModelToEntity(model, id);
                eventRepository.DeleteRecord(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Add(EventViewModel model)
        {
            return View();
        }

        private EventRepository CreateEventRepository()
        {
            return new EventRepository();
        }
    }
}
