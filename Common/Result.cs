using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Result<T>
    {
        public string UserMassage { get; set; }
        public bool ısSuccesssed { get; set; }
        public T ProcessResult { get; set; }
    }
}
