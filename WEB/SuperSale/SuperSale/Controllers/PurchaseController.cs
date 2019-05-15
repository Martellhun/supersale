using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperSale.Data;
using SuperSale.Models;
using DapperParameters;

namespace SuperSale.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IDbQueryExecutor _dbQueryExecutor;

        public PurchaseController(IDbQueryExecutor dbQueryExecutor)
        {
            _dbQueryExecutor = dbQueryExecutor;
        }

        [HttpGet]
        public async Task<ActionResult> NewPurchase (long carId, long customerId)
        {
            ViewBag.CarId = carId;
            ViewBag.CustomerId = customerId;
            var spParams = new DynamicParameters();
            spParams.Add("@CarID", carId);
            var products = await _dbQueryExecutor.ExecuteQueryAsync<Product>(SPNames.GetProducts, spParams);

            return View(products.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> ProcessPurchase([FromBody]PurchaseModel purchaseModel)
        {

            var selectedItems = purchaseModel.PurchaseItems.Where(p => p.Selected).ToList();

            var purchase = new ProcessPurchaseParams
            {
                CarID = purchaseModel.CarID,
                CustomerID = purchaseModel.CustomerID,
                UserEmail = HttpContext.User.Identity.Name,
                TotalPrice = selectedItems.Sum( p => p.UnitPrice )                
            };

            var spParams = _dbQueryExecutor.GenerateDynamicParameters(purchase);

            spParams.AddTable("@ServicePackIDList", "IdList", selectedItems.Where(p => p.ProductType == ProductType.ServicePack).Select( p => new ServiceItem { ServiceID = p.ProductID, ServiceType = p.ProductTypeID } ).ToList());
            spParams.AddTable("@Parts", "PartList", selectedItems.Where(p => p.ProductType == ProductType.Part).Select(p => new PartItem { PartID = p.ProductID, Quantity = 1 }).ToList());

            await _dbQueryExecutor.ExecuteNonQueryAsync(SPNames.PurchaseProcess, spParams);

            return RedirectToAction("Details", "Customers", new { id = purchaseModel.CustomerID } );
            
        }
    }
}