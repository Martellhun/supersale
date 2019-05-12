using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperSale.Data;
using SuperSale.Models;

namespace SuperSale.Controllers
{
    public class ServicePacksController : Controller
    {
        private readonly IDbQueryExecutor _dbQueryExecutor;

        public ServicePacksController(IDbQueryExecutor dbQueryExecutor)
        {
            _dbQueryExecutor = dbQueryExecutor;
        }

        // GET: ServicePacks
        public async Task<ActionResult> Index()
        {
            var servicePacks = await _dbQueryExecutor.ExecuteQueryAsync<ServicePack>(SPNames.GetServicePacks);

            return View(servicePacks.ToList());
        }

        // GET: ServicePacks/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var spParams = new DynamicParameters();   //_dbQueryExecutor.GenerateDynamicParameters(id);
            spParams.Add("@ServicePackID", id);

            var recipes = await _dbQueryExecutor.ExecuteQueryAsync<Recipes>(SPNames.GetRecipes, spParams);

            return View(recipes.ToList());
        }

        // GET: ServicePacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicePacks/Create
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

        // GET: ServicePacks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServicePacks/Edit/5
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

        // GET: ServicePacks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServicePacks/Delete/5
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