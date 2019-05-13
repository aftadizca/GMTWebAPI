using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Location: BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public Stok Stok { get; set; }

    }
}
