using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperSale.Data;
using SuperSale.Models;

namespace SuperSale.Controllers
{
    public class WarrantytypesController : Controller
    {
        private readonly IDbQueryExecutor _dbQueryExecutor;

        public WarrantytypesController(IDbQueryExecutor dbQueryExecutor)
        {
            _dbQueryExecutor = dbQueryExecutor;
        }

        // GET: Cars
        public async Task<ActionResult> Index()
        {
            var warrantytypes = await _dbQueryExecutor.ExecuteQueryAsync<Warrantytype>(SPNames.GetWarrantytypes);

            return View(warrantytypes.ToList());
        }

        // GET: Warrantytypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Warrantytypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warrantytypes/Create
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

        // GET: Warrantytypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Warrantytypes/Edit/5
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

        // GET: Warrantytypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Warrantytypes/Delete/5
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