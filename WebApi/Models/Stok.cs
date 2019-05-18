using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class Stok : BaseEntity
    {
        [JsonIgnore]
        public string LocationID { get; set; } = "0";
        [JsonIgnore]
        public string MaterialID { get; set; }
        [JsonIgnore]
        public string StatusQCID { get; set; } = "1";
        public string Lot { get; set; }
        public DateTime ComingDate { get; set; } = DateTime.Now;
        public DateTime ExpiredDate { get; set; }
        public int QTY { get; set; }


        public StatusQC StatusQC { get; set; }
        public Material Material { get; set; }
        public Location Location { get; set; }
        public ICollection<StokMaterialOut> StokMaterialOut { get; set; }
    }
}
