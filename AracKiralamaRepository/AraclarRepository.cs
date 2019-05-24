using AracKiralama.Entity;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama.Repository
{
     public class AraclarRepository:IDisposable
    {
        private static AracKiralamaRezervasyonEntities db = Tool.GetConnection();
        ResultProcess<araclar> resultarac = new ResultProcess<araclar>();

        public bool AracInsert(araclar item)
        {
            db.araclars.Add(item);
            db.SaveChanges();
            return true;
        }

        public bool AracDelete(int id)
        {
            araclar silinecek = db.araclars.SingleOrDefault(k => k.aracID == id);
            if (silinecek.kiralikAraclars.Count == 0)
            {
                db.araclars.Remove(silinecek);
            }
            else
            {
                //
            }
            db.SaveChanges();
            return true;
        }

        public bool AracUpdate(araclar item)
        {
            //sirket guncelleme yapılacak
            araclar guncellenecek = db.araclars.SingleOrDefault(a => a.aracID == item.aracID);
            guncellenecek.aracMarka = item.aracMarka;
            guncellenecek.aracModel = item.aracModel;
            guncellenecek.gerekenEhliyetYasi = item.gerekenEhliyetYasi;
            guncellenecek.gunlukSinirKm = item.gunlukSinirKm;
            guncellenecek.anlikKm = item.anlikKm;
            guncellenecek.airbag = item.airbag;
            guncellenecek.bagajHacmi = item.bagajHacmi;
            guncellenecek.koltukSayisi = item.koltukSayisi;
            guncellenecek.aracSayisi = item.aracSayisi;
            guncellenecek.renk = item.renk;
            guncellenecek.fiyat = item.fiyat;
            guncellenecek.aracDurumu = item.aracDurumu;
            guncellenecek.sirketID = item.sirketID;
            guncellenecek.photo = item.photo;
            db.SaveChanges();
            return true;
        }

        public List<araclar> AraclariListele()
        {
            return db.araclars.ToList();
        }

        public Result<araclar> GetAracById(int id)
        {
            araclar bulunacak = db.araclars.SingleOrDefault(a => a.aracID == id);
            return resultarac.GetT(bulunacak);
        }




        public bool AracKirala(kiralikAraclar arac)
        {
            bool kiralanDimi = false;
            araclar araba = db.araclars.SingleOrDefault(a => a.aracID == arac.aracID);

            if (araba.aracDurumu == false)
            {
                araba.aracDurumu = true;
                arac.verilisKm = araba.anlikKm;
                arac.kiralanmaZamani = DateTime.Now;
                arac.ucret = (araba.fiyat * arac.KacGun);
                if (araba.aracSayisi >= 1)
                {
                    araba.aracSayisi--;
                }
                db.kiralikAraclars.Add(arac);
                db.SaveChanges();
                kiralanDimi = true;
            }
            return kiralanDimi;
        }

        public void Dispose()
        {
            
        }
    }
}
