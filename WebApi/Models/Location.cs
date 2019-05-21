using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Location: BaseEntity
    {

        [StringLength(10)]
        public string Name { get; set; }



        [JsonIgnore]
        public Stok Stok { get; set; }

    }
}
