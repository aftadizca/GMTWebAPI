using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class StatusQC : BaseEntity
    {

        [StringLength(10)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Stok> Stoks { get; set; }
    }
}
