using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperSale.Data;
using SuperSale.Data.SQLQueries;
using SuperSale.Models;
using SuperSale.Models.Input;
using static SuperSale.Data.SQLParams.CarParams;

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
        public async Task<ActionResult> Create(IFormCollection carCollection)
        {
            try
            {
                var car = new CarInputModel {
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
            }
        }


        // POST: Cars/Delete/5
        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var qParams = _dbQueryExecutor.GenerateDynamicParameters(new CarIdParams { CarId = id});

                await _dbQueryExecutor.ExecuteNonQueryAsync(CarQueries.DeleteCar, qParams, System.Data.CommandType.Text);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}