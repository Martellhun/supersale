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
    public class PartsController : Controller
    {
        private readonly IDbQueryExecutor _dbQueryExecutor;

        public PartsController(IDbQueryExecutor dbQueryExecutor)
        {
            _dbQueryExecutor = dbQueryExecutor;
        }

        // GET: Parts
        public async Task<ActionResult> Index()
        {
            var parts = await _dbQueryExecutor.ExecuteQueryAsync<Part>(SPNames.GetParts);

            return View(parts.ToList());
        }

        // GET: Parts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection partCollection)
        {
           /* try
            {
                var part = new PartInputModel
                {
                    BrandName = carCollection[nameof(Car.Brand)],
                    Typename = carCollection[nameof(Car.Type)],
                    Engine = int.Parse(carCollection[nameof(Car.Engine)]),
                    Generation = int.Parse(carCollection[nameof(Car.Gen)])
                };

                var spParams = _dbQueryExecutor.GenerateDynamicParameters(car);

                await _dbQueryExecutor.ExecuteNonQueryAsync(SPNames.NewCar, spParams);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }*/
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parts/Edit/5
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

        // GET: Parts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parts/Delete/5
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