using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CostumModel
{
    public class NewStok
    {
        public DateTime ExpiredDate { get; set; }
        public string Lot { get; set; }
        public string MaterialID { get; set; }
        public int Qty { get; set; }
        public int Pallet { get; set; }
    }
}
