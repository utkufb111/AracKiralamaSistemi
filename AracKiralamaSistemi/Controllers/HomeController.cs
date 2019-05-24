using AracKiralama.Entity;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaSistemi.Controllers
{
    public class HomeController : Controller
    {
        private static AracKiralamaRezervasyonEntities db = Tool.GetConnection();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.araclars.ToList());
        }
        public ActionResult Detail(int id)
        {
            araclar a = db.araclars.SingleOrDefault(ar => ar.aracID == id);
            Session["Araba"] = id;
            return View(a);
        }
    }
}