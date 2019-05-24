using AracKiralama.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace AracKiralamaSistemi.Controllers
{
    public class LoginController : Controller
    {
        private static AracKiralamaRezervasyonEntities db = Tool.GetConnection();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AracKiralama.Entity.kullanicilar model)
        {
            bool giris = false;
            foreach (AracKiralama.Entity.kullanicilar item in db.kullanicilars.ToList())
            {
                if (model.eposta == item.eposta && model.sifre == item.sifre)
                {
                    Session["User"] = item.kullaniciID;
                    giris = true;
                    break;
                }
                else
                {
                    giris = false;
                }
            }
            int id = (int)Session["User"];
            AracKiralama.Entity.kullanicilar kul = db.kullanicilars.SingleOrDefault(k=>k.kullaniciID==id);
            
            if (giris == true)
            {

                if (kul.roleID == 1)
                {
                    return RedirectToAction("AracListeleme", "Arac");
                    //return RedirectToAction("List", "Member", new { area = "Admin" });/*admin pageyr yönlendirme yap*/
                }
                else if (kul.roleID == 2)
                {
                    return RedirectToAction("Index", "Home");//anasayfaya yönlendirme yap
                }
                else
                {
                    ViewBag.Message = "Başarısız";
                    return View(kul);
                }
            }
            else
            {
                ViewBag.Message = "Başarısız";
                return View(model);
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}