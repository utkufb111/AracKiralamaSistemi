using AracKiralama.Entity;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.Repository
{
     public class KullanicilarRepository:IDisposable
    {
        private static AracKiralamaRezervasyonEntities db = Tool.GetConnection();
        ResultProcess<kullanicilar> resultkullanici = new ResultProcess<kullanicilar>();
        public bool KullaniciInsert(kullanicilar item)
        {
            db.kullanicilars.Add(item);
            db.SaveChanges();
            return true;
            
        }
       
        public bool KullaniciDelete(int id)
        {
            kullanicilar silinecek = db.kullanicilars.SingleOrDefault(k => k.kullaniciID == id);
            if (silinecek.kiralikAraclars.Count == 0)
            {
                db.kullanicilars.Remove(silinecek);
            }
            else
            {
                //
            }
            db.SaveChanges();
            return true;
        }
        public bool KullaniciUpdate(kullanicilar item)
        {
            //adres guncelleme yapılacak
            kullanicilar guncellenecek = db.kullanicilars.SingleOrDefault(k => k.kullaniciID == item.kullaniciID);
            guncellenecek.ad = item.ad;
            guncellenecek.soyad = item.soyad;
            guncellenecek.eposta = item.eposta;
            guncellenecek.sifre = item.sifre;
            guncellenecek.tel = item.tel;
            db.SaveChanges();
            return true;
        }
        
        public List<kullanicilar> KullaniciListele()
        {
            return db.kullanicilars.ToList();
        }
        
        public Result<kullanicilar> GetKullaniciById(int id)
        {
            kullanicilar bulunacak = db.kullanicilars.SingleOrDefault(k => k.kullaniciID == id);
            return resultkullanici.GetT(bulunacak);
        }

        public bool LoginControl(kullanicilar item)
        {
            bool giris = false;
            foreach (kullanicilar i in db.kullanicilars)
            {
                if (i.eposta == item.eposta && i.sifre == item.sifre)
                {
                    giris = true;
                    break;
                }

            }
            return giris;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
