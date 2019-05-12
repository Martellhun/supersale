using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using SuperSale.Data;
using SuperSale.Models;
using SuperSale.Models.Input;

namespace SuperSale.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IDbQueryExecutor _dbQueryExecutor;

        public CustomersController(IDbQueryExecutor dbQueryExecutor)
        {
            _dbQueryExecutor = dbQueryExecutor;
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var customerDetails = await GetCustomerDetailsAsync(id);
            return View(customerDetails);
        }

        // GET: Customers/CustomerCar/5
        public async Task<ActionResult> CustomerCar(int id)
        {
            var cars = await _dbQueryExecutor.ExecuteQueryAsync<Car>(SPNames.GetCars);
            ViewBag.Cars = cars;
            return View();
        }

        // GET: Customers/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: Customers/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Search(IFormCollection customerCollection)
        {
            try
            {
                var customer = new CustomerSearchModel
                {
                    FirstName = customerCollection[nameof(CustomerSearchModel.FirstName)],
                    LastName = customerCollection[nameof(CustomerSearchModel.LastName)],
                    WithWildCard = bool.TryParse(customerCollection[nameof(CustomerSearchModel.WithWildCard)], out var result) ? result: false
                };

                var spParams = _dbQueryExecutor.GenerateDynamicParameters(customer);

                var searchresult = await _dbQueryExecutor.ExecuteQueryAsync<CustomerModel>(SPNames.SearchCustomer, spParams);
                return View("Index", searchresult);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var customerDetails = await GetCustomerDetailsAsync(id);
            return View(customerDetails);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                var customer = new CustomerModel
                {
                    FirstName = collection[nameof(CustomerModel.FirstName)],
                    LastName = collection[nameof(CustomerModel.LastName)],
                    Company = collection[nameof(CustomerModel.Company)],
                    Email = collection[nameof(CustomerModel.Email)]
                };

                var spParams = _dbQueryExecutor.GenerateDynamicParameters(customer);
                
                spParams.Add("@CustomerID", id);

                await _dbQueryExecutor.ExecuteNonQueryAsync(SPNames.SetCustomer, spParams);

                return RedirectToAction(nameof(Details), new { id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Search");
            }
            catch
            {
                return View();
            }
        }

        private async Task<CustomerDetailsModel> GetCustomerDetailsAsync(long id)
        {
            var spParams = new DynamicParameters();

            spParams.Add("@CustomerID", id);

            var (customer, cars) = await _dbQueryExecutor.ExecuteQueryTwoSetsAsync<CustomerModel, Car>(SPNames.GetCustomer, spParams);
            return new CustomerDetailsModel(customer.Single(), cars);
        }
    }
}