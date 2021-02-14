using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPortal.Models;
using static AdminLibrary.Business_Logic.FCATKProcessor;

namespace AdminPortal.Controllers
{
    [Authorize]
    public class FCATKController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "FCATK";
            var data = LoadFCATK();
            List<FCATK> fcatk = new List<FCATK>();
            foreach(var row in data)
            {
                fcatk.Add(new FCATK
                {
                    order_ref = row.order_ref,
                    item = row.item,
                    tgl_masuk = row.tgl_masuk,
                    stock_before = row.stock_before,
                    bought_amt = row.bought_amt,
                    stock_after = row.stock_before - row.bought_amt,
                    pj = row.pj,
                    item_type = row.item_type
                });
            }
            return View(fcatk);
        }
    }
}