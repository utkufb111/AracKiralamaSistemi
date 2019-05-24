using AracKiralama.Entity;
using AracKiralama.Repository;
using AracKiralamaSistemi.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AracKiralamaServisi
{
    /// <summary>
    /// Summary description for AracWebServisi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AracWebServisi : System.Web.Services.WebService
    {
        

        [WebMethod]
        public bool KullaniciInsert(kullanicilar item)
        {

            try
            {
                using (var kullanici = new KullanicilarRepository())
                {
                    kullanici.KullaniciInsert(item);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod]
        public bool KullaniciDelete(int id)
        {
            try
            {
                using (var kullanici = new KullanicilarRepository())
                {
                    kullanici.KullaniciDelete(id);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod]
        public bool KullaniciUpdate(kullanicilar item)
        {
            try
            {
                using (var kullanici = new KullanicilarRepository())
                {
                    kullanici.KullaniciUpdate(item);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod]
        public bool KullaniciListele()
        {
            try
            {
                using (var kullanici = new KullanicilarRepository())
                {
                    kullanici.KullaniciListele();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod]
        public bool GetKullaniciById(int id)
        {
            try
            {
                using (var kullanici = new KullanicilarRepository())
                {
                    kullanici.GetKullaniciById(id);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Arac Metodlari

        [WebMethod]
        public bool AracInsert(araclar item)
        {
            try
            {
                using (var araclar = new AraclarRepository())
                {
                    araclar.AracInsert(item);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod]
        public bool AracDelete(int id)
        {
            try
            {
                using (var araclar = new AraclarRepository())
                {
                    araclar.AracDelete(id);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod]
        public bool AracUpdate(araclar item)
        {
            try
            {
                using (var araclar = new AraclarRepository())
                {
                    araclar.AracUpdate(item);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod]
        public bool AraclariListele()
        {
            try
            {
                using (var araclar = new AraclarRepository())
                {
                    araclar.AraclariListele();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod]
        public bool GetAracById(int id)
        {
            try
            {
                using (var araclar = new AraclarRepository())
                {
                    araclar.GetAracById(id);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod]
        public bool LoginControl(kullanicilar item)
        {
            try
            {
                using (var kullanicilar = new KullanicilarRepository())
                {
                    kullanicilar.LoginControl(item);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        [WebMethod]
        public bool AracKirala(kiralikAraclar arac)
        {
            try
            {
                using (var araclar = new AraclarRepository())
                {
                    araclar.AracKirala(arac);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


    }
}
