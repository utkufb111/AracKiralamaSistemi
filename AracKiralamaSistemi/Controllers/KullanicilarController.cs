using AracKiralama.Entity;
using AracKiralamaSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace AracKiralamaSistemi.Controllers
{
    public class KullanicilarController : Controller
    {
        // GET: Kullanicilar
        private static AracKiralamaRezervasyonEntities db = Tool.GetConnection();

       
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(kullanicilar model)
        {
            model.roleID = 2;
            return RedirectToAction("Index","Home");
        }
        public ActionResult Delete(int id)
        {
            AracKiralama.Entity.kullanicilar k = db.kullanicilars.SingleOrDefault(kul => kul.kullaniciID == id);
            if (k.kiralikAraclars.Count==0)
            {
                //Api deki kullanıcı delete çağırılcak...
            }
            else
            {
                k.kiralikAraclars.Clear();
                //Api deki kullanıcı delete çağırılcak...
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            kullanicilar kul = db.kullanicilars.SingleOrDefault(k => k.kullaniciID == id);
            return View(kul);
        }
        [HttpPost]
        public ActionResult Update(kullanicilar item)
        {
            //Apideki kullaniciUpdate çağırılacak..
            return RedirectToAction("Index", "Home");

        }
        public ActionResult List()
        {
            //Apideki KullaniciList çağırılacak...
            return View();
        }

        public ActionResult KiralikAraclarim()
        {
            int id = (int)Session["User"];
            List<kiralikAraclar> KList = new List<kiralikAraclar>();
            foreach (var item in db.kiralikAraclars.ToList())
            {
                if (item.kullaniciID==id)
                {
                    KList.Add(item);
                }
            }
            return View(KList.ToList());
        }
       
    }
}