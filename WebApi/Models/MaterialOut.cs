using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class MaterialOut: BaseEntity
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public string ReceiverName { get; set; }
        public string ReceiverDepartement { get; set; }
        public bool IsDone { get; set; } = false;

        public ICollection<StokMaterialOut> StokMaterialOut { get; set; }
    }
}
