using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebKedoya.Data;
using WebKedoya.Models;

namespace WebKedoya.Controllers
{
    public class SettingController : Controller
    {
        private readonly SettingDataContext _db;

        public SettingController(SettingDataContext context)
        {
            _db = context;
        }


        // GET: Setting
        /*
        public ActionResult Index()
        {
            var items = _db.Settings.ToList();
            return View(items);
        }
        */

        public async Task<IActionResult> Index(
                    string sortOrder,
                    string currentFilter,
                    string searchString,
                    int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nama" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "tgl_lahir" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var settings = from s in _db.Settings
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                settings = settings.Where(s => s.SettingName.Contains(searchString)
                                       || s.SettingDescription.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    settings = settings.OrderByDescending(s => s.SettingName);
                    break;
                case "Type":
                    settings = settings.OrderBy(s => s.SettingType);
                    break;
                case "Description":
                    settings = settings.OrderByDescending(s => s.SettingDescription);
                    break;
                default:
                    settings = settings.OrderBy(s => s.SettingName);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<Setting>.CreateAsync(settings.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setting = await _db.Settings
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.SettingID == id);

            if (setting == null)
            {
                return NotFound();
            }

            return View(setting);
        }


        // GET: Setting/Create
        public ActionResult Create()
        {

            List<General> generalList = new List<General>();

            //generalList = (from ogeneral in _db.Generals
            //               select ogeneral).ToList();
            
            return View();
        }

        // POST: Setting/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Setting item)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _db.Add(item);
                    _db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Setting/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
                if (id == null)
            {
                return NotFound();
            }
            var setting = await _db.Settings.SingleOrDefaultAsync(m => m.SettingID == id);
            if (setting == null)
            {
                return NotFound();
            }
            return View(setting);
        }

        // POST: Setting/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> EditPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var settingToUpdate = await _db.Settings.SingleOrDefaultAsync(s => s.SettingID == id);
            if (await TryUpdateModelAsync<WebKedoya.Models.Setting>(
                settingToUpdate,
                "",s => s.SettingName, s => s.SettingDescription, s => s.SettingType))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(settingToUpdate);
        }

        // GET: Setting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Setting/Delete/5
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