using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebKedoya.Data;
using WebKedoya.Models;

namespace WebKedoya.Controllers
{
    public class KehadiranController : Controller
    {
        protected KedoyaDataContext db = new KedoyaDataContext();

        // GET: Kehadiran
        [HttpGet]
        public ActionResult Index()
        {
            var kehadiranList = db.Kehadirans.ToList();

            List<KehadiranFormViewModel> items = new List<KehadiranFormViewModel>();

            foreach(Kehadiran kehadiran in kehadiranList)
            {
                KehadiranFormViewModel item = new KehadiranFormViewModel();
                item.IDKehadiran = kehadiran.IDKehadiran;
                item.Jumlah = kehadiran.Jumlah;
                item.Tanggal = kehadiran.Tanggal;


                var ibadah = db.JenisIbadahs.Where(p => p.KodeJenisIbadah.Equals(kehadiran.KodeJenisIbadah)).Single<JenisIbadah>();
                item.NamaJenisIbadah = ibadah.NamaJenisIbadah;

                var jemaat = db.JenisJemaats.Where(p => p.KodeJenisJemaat.Equals(kehadiran.KodeJenisJemaat)).Single<JenisJemaat>();
                item.NamaJenisJemaat = jemaat.NamaJenisJemaat;

                items.Add(item);
            }
            return View(items);
        }

        // GET: Kehadiran/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }


        // GET: Kehadiran/Create
        public ActionResult CreateNew()
        {
            ViewBag.JenisIbadah = new SelectList(db.JenisIbadahs.ToList(), "KodeJenisIbadah", "NamaJenisIbadah");
            ViewBag.JenisJemaat = new SelectList(db.JenisJemaats.ToList(), "KodeJenisJemaat", "NamaJenisJemaat");
            //var jenisJemaatList = db.JenisJemaats.ToList();
            //List<KehadiranFormViewModel> items = new List<KehadiranFormViewModel>();

            //items = db.JenisJemaats.ToList();
            //var tupleHadir = new Tuple <KehadiranFormViewModel, List<JenisJemaat>>(ViewBag, items);

            return View();
        }

        // GET: Kehadiran/Create
        public ActionResult Create()
        {
            ViewBag.JenisIbadah = new SelectList(db.JenisIbadahs.ToList(), "KodeJenisIbadah", "NamaJenisIbadah");
            ViewBag.JenisJemaat = new SelectList(db.JenisJemaats.ToList(), "KodeJenisJemaat", "NamaJenisJemaat");

            return View();
        }

        // POST: Kehadiran/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KehadiranFormViewModel item)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Kehadiran kehadiran = new Kehadiran();
                    kehadiran.Tanggal = item.Tanggal;
                    kehadiran.KodeJenisIbadah = item.KodeJenisIbadah;
                    kehadiran.KodeJenisJemaat = item.KodeJenisJemaat;
                    kehadiran.Jumlah = item.Jumlah;
                    db.Add(kehadiran);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                        .Where(y => y.Count > 0)
                        .ToList();

                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    //return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);

                    return View(errors);
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Kehadiran/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Kehadiran/Edit/5
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

        // GET: Kehadiran/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kehadiran/Delete/5
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