using AdminPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AdminLibrary.Business_Logic.RestockProcessor;

namespace AdminPortal.Controllers
{
    [Authorize]
    public class RestockController : Controller
    {
        // GET: Restock
        public ActionResult Index()
        {
            var data = LoadRestock();
            List<Restock> restocks = new List<Restock>();

            foreach(var row in data)
            {
                restocks.Add(new Restock
                {
                    order_ref = row.order_ref,
                    date_bought = row.date_bought,
                    buyer = row.buyer,
                    amt_bought = row.amt_bought,
                    amt_spent = row.amt_spent,
                    id = row.id,
                    item = row.item,
                    actualDate = row.date_bought.ToString("dd/MM/yyyy")
                });
            }
            return View(restocks);
        }
    }
}