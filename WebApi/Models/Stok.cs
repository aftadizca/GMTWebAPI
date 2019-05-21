using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Stok : BaseEntity
    {
        //foreign key
        public string LocationID { get; set; } = "0";
        public string MaterialID { get; set; }
        public string StatusQCID { get; set; } = "1";

        [StringLength(20)]
        public string Lot { get; set; }
        public DateTime ComingDate { get; set; } = DateTime.Now;
        public DateTime ExpiredDate { get; set; }
        public int QTY { get; set; }
        public bool IsOut { get; set; } = false;


        //relation
        [JsonIgnore]
        public StatusQC StatusQC { get; set; }
        [JsonIgnore]
        public Material Material { get; set; }
        [JsonIgnore]
        public Location Location { get; set; }
        [JsonIgnore]
        public ICollection<StokMaterialOut> StokMaterialOut { get; set; }
    }
}
