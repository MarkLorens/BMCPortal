using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AdminLibrary.Business_Logic;
using AdminPortal.Models;
using static AdminLibrary.Business_Logic.TenderProcessor;

namespace AdminPortal.Controllers
{
    [Authorize]
    public class TenderController : Controller
    {
        // GET: Tender
        public ActionResult Index()
        {
            ViewBag.Message = "Tender List";
            var data = LoadTender();
            List<Tender> tenders = new List<Tender>();

            foreach(var row in data)
            {
                tenders.Add(new Tender
                {
                    instansi = row.instansi,
                    alamat = row.alamat,
                    no_kontak = row.no_kontak,
                    email = row.email
                });
            }
            return View(tenders);
        }

        public ActionResult CreateTender()
        {
            ViewBag.Message = "Create Tender";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTender(Tender tender)
        {
            
            if (ModelState.IsValid)
            {
                int recordsCreated = createTender(tender.instansi, 
                    tender.alamat, 
                    tender.no_kontak, 
                    tender.email);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}