using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Metting_Minutes.EF;
using Metting_Minutes.DTO;
using Metting_Minutes.Models;
using System.Web.UI.WebControls;

namespace Metting_Minutes.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new Metting_MinutesEntities1();
            ViewBag.CorporateData = db.Corporate_table.ToList();
            ViewBag.IndividualData = db.Individual_table.ToList();
            ViewBag.Product = db.Product_Unit.ToList();
            ViewBag.Finalproduct = db.FinalProducts.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(Index form)
        {

            var db = new Metting_MinutesEntities1();
            if (ModelState.IsValid)
            {
                var product = new FinalProduct();
                var details = new Metting_Details();
                details.AttendsFromHostSide = form.AttendsFromHostSide;
                details.AttendsFromClientSide = form.AttendsFromClientSide;
                details.MeetingDisCussion = form.MeetingDisCussion;
                details.CustomerName = form.CustomerName;
                details.MettingDecision = form.MettingDecision;
                details.MeettingAgenda = form.MeettingAgenda;
                details.Date = form.Date;
                if (form.Time.HasValue)
                {
                    // Assuming form.Time is in 24-hour format
                    if (form.Time.Value.Hours >= 12)
                    {
                        // If the hour is 12 or greater, subtract 12 hours
                        details.Time = form.Time.Value.Subtract(TimeSpan.FromHours(12));
                        _ = details.Time + "PM";
                    }
                    else
                    {
                        details.Time = form.Time.Value;
                        _ = details.Time + "AM";
                    }
                }
                details.MeetingPlace = form.MeetingPlace;
                db.Metting_Details.Add(details);
                db.SaveChanges();
                product.Unit = form.Unit;
                product.ProductName = form.ProductName;
                product.Quantity = form.Quantity;
                db.FinalProducts.Add(product);
                db.SaveChanges();
               
            }
            ViewBag.CorporateData = db.Corporate_table.ToList();
            ViewBag.IndividualData = db.Individual_table.ToList();
            ViewBag.Product = db.Product_Unit.ToList();
            ViewBag.Finalproduct = db.FinalProducts.ToList();
            return View(form);
        }

        [HttpPost]
        public ActionResult SaveFinalProducts(List<FinalProduct> finalProducts)
        {
            try
            {
                using (var db = new Metting_MinutesEntities1())
                {

                    foreach (var product in finalProducts)
                    {

                        db.FinalProducts.Add(product);
                    }
                    db.SaveChanges();

                    return Json(new { success = true, message = "Data saved successfully" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error saving data: " + ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            var db = new Metting_MinutesEntities1();
            var data = db.FinalProducts.Find(Id);
            return View(data);
        }
       
        [HttpPost]
        public ActionResult EditProduct(FinalProduct d)
        {
            var db = new Metting_MinutesEntities1();
            var ex = db.FinalProducts.Find(d.id);
            ex.ProductName = d.ProductName;
            ex.Unit = d.Unit;
            ex.Quantity = d.Quantity;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult deleteProduct(int Id)
        {
            var db = new Metting_MinutesEntities1();
            var data = db.FinalProducts.Find(Id);

            if (data != null)
            {
                db.FinalProducts.Remove(data);
                db.SaveChanges();
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }





    }
}