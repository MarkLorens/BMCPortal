using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPortal.Controllers
{
    [Authorize]
    public class MesinProduksiController : Controller
    {
        // GET: MesinProduksi
        public ActionResult Index()
        {
            return View();
        }
    }
}