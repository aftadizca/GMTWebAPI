using Newtonsoft.Json;

namespace WebApi.Models
{
    public class StokMaterialOut
    {
        public string StockID { get; set; }
        public string MaterialOutID { get; set; }
        public int Qty { get; set; }
        

        [JsonIgnore]
        public Stok Stok { get; set; }
        [JsonIgnore]
        public MaterialOut MaterialOut { get; set; }
    }
}
