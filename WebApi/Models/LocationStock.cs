using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class LocationStock
    {
        public string Location { get; set; }
        public string TraceID { get; set; }
        public string MaterialName { get; set; }
    }
}
