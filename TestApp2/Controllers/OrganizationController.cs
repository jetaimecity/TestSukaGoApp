using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp2.Data;
using TestApp2.Models;

namespace TestApp2.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly OrganizationRepository repository;

        public OrganizationController()
        {
            this.repository = new OrganizationRepository();
        }

        // GET: Organization
        public ActionResult Index()
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
        public ActionResult Create(OrganizationViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                var entity = this.repository.ConvertModelToEntity(model);
                this.repository.AddRecord(entity);

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
        public ActionResult Edit(string id, OrganizationViewModel model)
        {
            try
            {
                var entity = this.repository.ConvertModelToEntity(model, id);
                this.repository.EditRecord(entity);

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
       // [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, OrganizationViewModel model)
        {
            try
            {
                // TODO: Add delete logic here

                var entity = this.repository.ConvertModelToEntity(model, id);
                this.repository.DeleteRecord(entity);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}