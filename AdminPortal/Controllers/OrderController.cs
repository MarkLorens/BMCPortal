using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AdminPortal.Models;
using static AdminLibrary.Business_Logic.OrderProcessor;
using System.Data.SqlClient;
using AdminLibrary.Data_Access;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace AdminPortal.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        // GET: Order
        public ActionResult Index(string searchString)
        {
            ViewBag.Message = "Order List";
            var data = LoadOrder();
            List<Order> orders = new List<Order>();

            if (!String.IsNullOrEmpty(searchString))
            {
                foreach(var row in data)
                {
                    if(searchString == row.order_ref)
                    {
                        orders.Add(new Order
                        {
                            order_ref = searchString,
                            item = row.item,
                            tgl_masuk = row.tgl_masuk,
                            tgl_selesai = row.tgl_selesai,
                            dp = row.dp,
                            sisa = row.sisa,
                            total = row.total,
                            pj = row.pj,
                            instansi = row.instansi,
                            bought_amt = row.bought_amt,
                            id = row.id
                        });
                        return View(orders);
                    }
                }
            }
            foreach (var row in data)
            {
                orders.Add(new Order
                {
                    order_ref = row.order_ref,
                    item = row.item,
                    tgl_masuk = row.tgl_masuk,
                    tgl_selesai = row.tgl_selesai,
                    dp = row.dp,
                    sisa = row.sisa,
                    total = row.total,
                    pj = row.pj,
                    instansi = row.instansi,
                    bought_amt = row.bought_amt,
                    id = row.id
                });
            }
            return View(orders);
        }
        public ActionResult CreateOrderBarang()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderBarang(Order order)
        {
            if (ModelState.IsValid)
            {
                int countItem = 0;
                int countInstansi = 0;
                double stockAvailable = 0;
                double itemPrice = 0;
                using (SqlConnection c = new SqlConnection(SqlDataAccess.GetConnectionString()))
                {
                    c.Open();
                    using (SqlCommand sqlItem = new SqlCommand(@"SELECT COUNT(item) FROM Stock WHERE item = @item", c))
                    using (SqlCommand sqlInstansi = new SqlCommand(@"SELECT COUNT(instansi) FROM Tender WHERE instansi = @instansi", c))
                    using (SqlCommand sqlAmt = new SqlCommand(@"SELECT ISNULL((SELECT stock FROM Stock WHERE item=@item),0)", c))
                    using (SqlCommand sqlPrice = new SqlCommand(@"SELECT ISNULL((SELECT price FROM Stock WHERE item=@item),0)",c))
                    {
                        sqlItem.Parameters.AddWithValue("@item", order.item);
                        sqlInstansi.Parameters.AddWithValue("@instansi", order.instansi);
                        sqlAmt.Parameters.AddWithValue("@item", order.item);
                        sqlPrice.Parameters.AddWithValue("@item",order.item);

                        countItem = (int)sqlItem.ExecuteScalar();
                        countInstansi = (int)sqlInstansi.ExecuteScalar();
                        stockAvailable = Convert.ToDouble(sqlAmt.ExecuteScalar());
                        itemPrice = Convert.ToDouble(sqlPrice.ExecuteScalar());
                    }
                }

                if (countItem == 1 && countInstansi == 1 && stockAvailable >= order.bought_amt && order.dp <= (itemPrice * order.bought_amt))
                {
                    int order_id = 0;
                    using (SqlConnection c = new SqlConnection(SqlDataAccess.GetConnectionString()))
                    {
                        c.Open();
                        using (SqlCommand sqlID = new SqlCommand(@"SELECT id FROM Stock WHERE item = @item", c))
                        {
                            sqlID.Parameters.AddWithValue("@item", order.item);

                            order_id = (int)sqlID.ExecuteScalar();
                        }
                    }
                    Guid refHelper = Guid.NewGuid();
                    order.tgl_masuk = DateTime.Now;
                    order.total = (float)itemPrice * order.bought_amt;
                    order.sisa = order.total - order.dp;
                    order.id = order_id;
                    order.item_type = "Barang";

                    int x = createOrder(
                        refHelper.ToString(),
                        order.tgl_masuk,
                        order.dp,
                        order.sisa,
                        order.total,
                        order.pj,
                        order.instansi,
                        order.id,
                        order.bought_amt,
                        order.item_type,
                        (float)stockAvailable
                        );

                    float actualStock = (float)stockAvailable - order.bought_amt;
                    int BoughtAmtToInt = -Math.Abs((int)order.bought_amt);

                    int y = UpdateStockByOrder(
                        actualStock,
                        BoughtAmtToInt,
                        DateTime.Now,
                        order.item);

                    return RedirectToAction("Index");
                }
                else if (order.item == null || order.instansi == null)
                {
                    ModelState.AddModelError("dp", "Exception hit, null values is passed");
                }
                if (countItem == 1 && countInstansi < 1)
                {
                    ModelState.AddModelError("instansi", "Instansi tidak ditemukan");
                }
                if (countItem < 1 && countInstansi == 1)
                {
                    ModelState.AddModelError("item", "Barang tidak ditemukan");
                }
                if (countItem == 1 && countInstansi == 1 && stockAvailable < order.bought_amt)
                {
                    ModelState.AddModelError("bought_amt", "Stock barang tidak cukup");
                }
                if (countItem == 1 && countInstansi == 1 && stockAvailable >= order.bought_amt && order.dp > (itemPrice * order.bought_amt))
                {
                    ModelState.AddModelError("dp","DP lebih besar dari total (" + (itemPrice*order.bought_amt) + ")");
                }
                if (countItem < 1 && countInstansi < 1)
                {
                    ModelState.AddModelError("item", "Barang tidak ditemukan");
                    ModelState.AddModelError("instansi", "Instansi tidak ditemukan");
                }
            }
                return View();
        }

        public ActionResult CreateOrderJasa()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrderJasa(Order order)
        {
            if (ModelState.IsValid)
            {
                int countItem = 0;
                int countInstansi = 0;
                double stockAvailable = 0;
                double itemPrice = 0;
                using (SqlConnection c = new SqlConnection(SqlDataAccess.GetConnectionString()))
                {
                    c.Open();
                    using (SqlCommand sqlItem = new SqlCommand(@"SELECT COUNT(item) FROM Stock WHERE item = @item", c))
                    using (SqlCommand sqlInstansi = new SqlCommand(@"SELECT COUNT(instansi) FROM Tender WHERE instansi = @instansi", c))
                    using (SqlCommand sqlAmt = new SqlCommand(@"SELECT ISNULL((SELECT stock FROM Stock WHERE item=@item),0)", c))
                    using (SqlCommand sqlPrice = new SqlCommand(@"SELECT ISNULL((SELECT price FROM Stock WHERE item=@item),0)", c))
                    {
                        sqlItem.Parameters.AddWithValue("@item", order.item);
                        sqlInstansi.Parameters.AddWithValue("@instansi", order.instansi);
                        sqlAmt.Parameters.AddWithValue("@item", order.item);
                        sqlPrice.Parameters.AddWithValue("@item", order.item);

                        countItem = (int)sqlItem.ExecuteScalar();
                        countInstansi = (int)sqlInstansi.ExecuteScalar();
                        stockAvailable = Convert.ToDouble(sqlAmt.ExecuteScalar());
                        itemPrice = Convert.ToDouble(sqlPrice.ExecuteScalar());
                    }
                }

                if (countItem == 1 && countInstansi == 1 && stockAvailable >= order.bought_amt && order.dp <= (itemPrice * order.bought_amt))
                {
                    int order_id = 0;
                    using (SqlConnection c = new SqlConnection(SqlDataAccess.GetConnectionString()))
                    {
                        c.Open();
                        using (SqlCommand sqlID = new SqlCommand(@"SELECT id FROM Stock WHERE item = @item", c))
                        {
                            sqlID.Parameters.AddWithValue("@item", order.item);

                            order_id = (int)sqlID.ExecuteScalar();
                        }
                    }

                    var getAmoutOfStoredOrder = LoadOrder();
                    int refs = 1;
                    foreach (var row in getAmoutOfStoredOrder)
                    {
                        refs++;
                    }
                    Guid refHelper = Guid.NewGuid();
                    order.tgl_masuk = DateTime.Now;
                    order.total = (float)itemPrice * order.bought_amt;
                    order.sisa = order.total - order.dp;
                    order.id = order_id;

                    int x = createOrder(
                        refHelper.ToString(),
                        order.tgl_masuk,
                        order.dp,
                        order.sisa,
                        order.total,
                        order.pj,
                        order.instansi,
                        order.id,
                        order.bought_amt,
                        order.item_type,
                        (float)stockAvailable
                        );

                    float actualStock = (float)stockAvailable - order.bought_amt;
                    int BoughtAmtToInt = -Math.Abs((int)order.bought_amt);
                    int y = UpdateStockByOrder(
                        actualStock,
                        BoughtAmtToInt,
                        DateTime.Now,
                        order.item);

                    return RedirectToAction("Index");
                }
                else if (order.item == null || order.instansi == null)
                {
                    ModelState.AddModelError("dp", "Exception hit, null values is passed");
                }
                if (countItem == 1 && countInstansi < 1)
                {
                    ModelState.AddModelError("instansi", "Instansi tidak ditemukan");
                }
                if (countItem < 1 && countInstansi == 1)
                {
                    ModelState.AddModelError("item", "Barang tidak ditemukan");
                }
                if (countItem == 1 && countInstansi == 1 && stockAvailable < order.bought_amt)
                {
                    ModelState.AddModelError("bought_amt", "Stock barang tidak cukup");
                }
                if (countItem == 1 && countInstansi == 1 && stockAvailable >= order.bought_amt && order.dp > (itemPrice * order.bought_amt))
                {
                    ModelState.AddModelError("dp", "DP lebih besar dari total (" + itemPrice * order.bought_amt + ")");
                }
                if (countItem < 1 && countInstansi < 1)
                {
                    ModelState.AddModelError("item", "Barang tidak ditemukan");
                    ModelState.AddModelError("instansi", "Instansi tidak ditemukan");
                }
            }
            return View();
        }

        public ActionResult OrderFinished(string id)
        {
            var data = LoadOrder();
            foreach (var row in data)
            {
                int x = orderFinished(id, DateTime.Now);
            }
            return RedirectToAction("Index");
        }
    }
}