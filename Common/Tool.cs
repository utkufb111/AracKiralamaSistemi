using AracKiralama.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public  class Tool
    {
        public static AracKiralamaRezervasyonEntities db = null;
        public static AracKiralamaRezervasyonEntities GetConnection()
        {
            if (db == null)
            {
                db = new AracKiralamaRezervasyonEntities();
            }
            return db;
        }

    }
}
