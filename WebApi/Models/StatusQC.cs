using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class StatusQC : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Stok> Stoks { get; set; }
    }
}
