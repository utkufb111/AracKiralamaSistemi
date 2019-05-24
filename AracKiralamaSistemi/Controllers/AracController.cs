using AracKiralama.Entity;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;

namespace AracKiralamaSistemi.Controllers
{
    public class AracController : Controller
    {
        private static AracKiralamaRezervasyonEntities db = Tool.GetConnection();
        //Apiyle birleştirilemedi...
        // GET: Arac
        public ActionResult AracInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AracInsert(araclar item,HttpPostedFileBase photo)
        {
            string PhotoName = "";
            if (photo != null && photo.ContentLength > 0 )
            {
                PhotoName = Guid.NewGuid().ToString().Replace("-", "") + ".png";
                string path = Server.MapPath("~/Upload/" + PhotoName);
                photo.SaveAs(path);
            }
            item.photo = PhotoName;
            item.aracDurumu = false;
            //Apideki aracinsert çağırılcak..
            return RedirectToAction("AracListeleme");  
        }
        public ActionResult AracDelete(int id)
        {
            return RedirectToAction("AracListeleme");
        }
        [HttpGet]
        public ActionResult AracUpdate(int id)
        {
            araclar a = db.araclars.SingleOrDefault(ar => ar.aracID == id);
            return View(a);
        }
        [HttpPost]
        public ActionResult AracUpdate(araclar item, HttpPostedFileBase photo)
        {
            string photoName = item.photo;
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    string ext = Path.GetExtension(photo.FileName);
                    photoName = Guid.NewGuid().ToString().Replace("-", "");
                    if (ext == ".jpg")
                    {
                        photoName += ext;
                    }
                    else if (ext == ".png")
                    {
                        photoName += ext;
                    }
                    else if (ext == ".bmp")
                    {
                        photoName += ext;
                    }
                    else
                    {
                        ViewBag.Mesaj = "Lütfen .jpg,.png,.bmp tipinde  resim yükleyiniz.";
                        return View(item);
                    }
                    string path = Server.MapPath("~/Upload/" + photoName);
                    photo.SaveAs(path);
                }
            }
            item.photo = photoName;
            //Apideki  aracupdate  çağırılacak..
            return RedirectToAction("AracListeleme");
        }
        
        public ActionResult AracListeleme()
        {
            //Apideki araclist çağırılacak..
            return View();
        }
        [HttpGet]
        public ActionResult AracKiralama()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AracKiralama (kiralikAraclar item)
        {
            item.aracID =(int)Session["Araba"];
            item.kullaniciID = (int)Session["User"];
            //Apideki arackiralama  çağırılacak...
            return RedirectToAction("Index","Home");
        }
    }
}