using AracKiralama.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ResultProcess<T>
    {
        public Result<int> GetResult(AracKiralamaRezervasyonEntities db)
        {
            Result<int> result = new Result<int>();
            int sonuc = db.SaveChanges();
            if (sonuc>0)
            {
                result.UserMassage = "Basarili";
                result.ısSuccesssed = true;
                result.ProcessResult = sonuc;
            }
            else
            {
                result.UserMassage = "basarisiz";
                result.ısSuccesssed = false;
                result.ProcessResult = sonuc;
            }
            return result;
        } 
        public Result<List<T>>GetListResult(List<T> data)
        {
            Result<List<T>> result = new Result<List<T>>();
            if (data!=null)
            {
                result.UserMassage = "Basarili";
                result.ısSuccesssed = true;
                result.ProcessResult = data;
            }
            else
            {
                result.UserMassage = "Basarisiz";
                result.ısSuccesssed = false;
                result.ProcessResult = data;
            }
            return result;
        }
        public Result<T> GetT(T data)
        {
            Result<T> result = new Result<T>();
            if (data!=null)
            {
                result.UserMassage = "Basarili";
                result.ısSuccesssed = true;
                result.ProcessResult = data;
            }
            else
            {
                result.UserMassage = "Basarisiz";
                result.ısSuccesssed = false;
                result.ProcessResult = data;
            }
            return result;
        }
    }
}
