﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public Stok Stok { get; set; }

    }
}
