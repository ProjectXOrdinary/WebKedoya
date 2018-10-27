using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebKedoya.Data;
using WebKedoya.Models;

namespace WebKedoya.Controllers
{
    public class GeneralController : Controller
    {
        private readonly GeneralDataContext _db;

        public GeneralController(GeneralDataContext context)
        {
            _db = context;
        }

        // GET: General
        public ActionResult Index()
        {
            List<General> generalList = new List<General>();

            generalList = (from ogeneral in _db.Generals
                           select ogeneral).ToList();

            return View();
        }

        // GET: General/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: General/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: General/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: General/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: General/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: General/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: General/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}