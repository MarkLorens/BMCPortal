using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPortal.Models;
using static AdminLibrary.Business_Logic.StockProcessor;
using static AdminLibrary.Business_Logic.RestockProcessor;
using System.Data.SqlClient;
using AdminLibrary.Data_Access;

namespace AdminPortal.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            ViewBag.Message = "Stock List";
            var data = LoadStock();
            List<Stock> stocks = new List<Stock>();

            foreach(var row in data)
            {
                stocks.Add(new Stock
                {
                    id = row.id,
                    item = row.item,
                    stock = row.stock,
                    amt_modified = row.amt_modified,
                    last_modified = row.last_modified,
                    modified_by = row.modified_by,
                    brand = row.brand,
                    price = row.price,
                    stock_before = row.stock_before
                });
            }
            return View(stocks);
        }
        public ActionResult CreateStock()
        {
            ViewBag.Message = "Create Stock";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStock(Stock stocks)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int countItem = 0;
                int checkID = 0;
                int compareID = random.Next(999);
                using (SqlConnection c = new SqlConnection(SqlDataAccess.GetConnectionString()))
                {
                    c.Open();
                    using (SqlCommand sqlItem = new SqlCommand(@"SELECT COUNT(item) FROM Stock WHERE item=@item;", c))
                    using (SqlCommand sqlID = new SqlCommand(@"SELECT COUNT(id) FROM Stock WHERE id=@id;", c))
                    {
                        sqlItem.Parameters.AddWithValue("@item", stocks.item);
                        sqlID.Parameters.AddWithValue("@id", compareID);

                        countItem = (int)sqlItem.ExecuteScalar();
                        checkID = (int)sqlID.ExecuteScalar();

                        while (checkID == 1)
                        {
                            compareID = random.Next(999);
                            checkID = (int)sqlID.ExecuteScalar();
                        }
                        if (countItem < 1)
                        {
                            stocks.id = compareID;
                            Guid refHelper = Guid.NewGuid();
                            stocks.amt_modified = 0;
                            stocks.last_modified = DateTime.Now;
                            stocks.modified_by = "SOON BROTHERS";
                            int x = createStock(
                                stocks.id,
                                stocks.item,
                                stocks.stock,
                                stocks.amt_modified,
                                stocks.last_modified,
                                stocks.modified_by,
                                stocks.brand,
                                stocks.price,
                                stocks.stock
                                );
                            int y = CreateRestock(
                                refHelper.ToString(),
                                DateTime.Now.Date,
                                stocks.buyer,
                                stocks.stock,
                                stocks.amt_spent,
                                stocks.id
                                );
                            return RedirectToAction("Index");
                        }
                        if (countItem == 1)
                        {
                            ModelState.AddModelError("item", "Barang sudah ada. Penambahan stock dilakukan di halaman 'Tambahkan Stock'");
                        }
                    }
                }
            }
            return View();
        }

        public ActionResult AddStock(int id)
        {
            var data = LoadStock();
            foreach (var row in data)
            {
                if (id == row.id)
                {
                    Stock stocks = new Stock()
                    {
                        id = id,
                        item = row.item,
                        stock = row.stock,
                        amt_modified = row.amt_modified,
                        last_modified = row.last_modified,
                        modified_by = row.modified_by,
                        brand = row.brand,
                        price = row.price
                    };
                    return View(stocks);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStock(int id, Stock stocks)
        {
            if (ModelState.IsValid)
            {
                float actualStock = stocks.stock + stocks.stockAdded;
                int AmtModToInt = (int)stocks.stockAdded;
                Guid refHelper = Guid.NewGuid();
                int y = UpdateStockBefore(
                    stocks.stock,
                    stocks.item
                    );
                int x = UpdateStockByAddStock(
                    actualStock,
                    AmtModToInt,
                    DateTime.Now,
                    stocks.item
                    );

                int z = CreateRestock(
                    refHelper.ToString(),
                    DateTime.Now.Date,
                    stocks.buyer,
                    stocks.stockAdded,
                    stocks.amt_spent,
                    stocks.id
                    );
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}