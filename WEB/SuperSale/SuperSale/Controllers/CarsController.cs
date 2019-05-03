using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperSale.Data;
using SuperSale.Models;
using SuperSale.Models.Input;

namespace SuperSale.Controllers
{
    public class CarsController : Controller
    {

        private readonly IDbQueryExecutor _dbQueryExecutor;

        public CarsController(IDbQueryExecutor dbQueryExecutor)
        {
            _dbQueryExecutor = dbQueryExecutor;
        }

        // GET: Cars
        public async Task<ActionResult> Index()
        {
            var cars = await _dbQueryExecutor.ExecuteQueryAsync<Car>(SPNames.GetCars);

            return View(cars.ToList());
        }


        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromBody]CarInputModel car)
        {
            try
            {
                await _dbQueryExecutor.ExecuteNonQueryAsync(SPNames.NewCar, car);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // POST: Cars/Delete/5
        [HttpDelete]
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