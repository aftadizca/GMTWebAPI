using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class StokMaterialOut : BaseEntity
    {
        
        public string StokID { get; set; }

        [JsonIgnore]
        public Stok Stok { get; set; }
        [JsonIgnore]

        [ForeignKey("Id")]
        public MaterialOut MaterialOut { get; set; }
    }


    public class StokMaterialOutComparer : IEqualityComparer<StokMaterialOut>
    {
        public bool Equals(StokMaterialOut x, StokMaterialOut y)
        {
            return x.StokID == y.StokID;
        }

        public int GetHashCode(StokMaterialOut obj)
        {
            return obj.StokID == null ? 0 : obj.StokID.GetHashCode();
        }
    }
}
