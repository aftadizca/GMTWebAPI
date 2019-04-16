using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Stok
    {
        
        [ForeignKey("Location")]
        public int LocationID { get; set; }
        [Key]
        public string TraceID { get; set; }
        public string MaterialID { get; set; }
        public int StatusQCID { get; set; }
        public string Lot { get; set; }
        public DateTime ComingDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int QTY { get; set; }

        [JsonIgnore]
        public StatusQC StatusQC { get; set; }
        [JsonIgnore]
        public Material Material { get; set; }
        [JsonIgnore]
        public Location Location { get; set; }
    }
}
