using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

    public class Material : BaseEntity
    {
        [Required]
        public string Name { set; get; }
        [Required]
        public string Suplier { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public string Type { get; set; }

        [JsonIgnore]
        public List<Stok> Stoks { get; set; }
    }
}
