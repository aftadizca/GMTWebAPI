using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{

    public class Material
    {
        [Required]
        public string ID {set; get;}
        [Required]
        public string Name {set; get;}
        [Required]
        public string Suplier { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public string Type { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ICollection<Stok> Stoks { get; set; }
    }
}
