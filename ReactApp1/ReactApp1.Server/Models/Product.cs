#nullable disable
using ReactApp1.Server.Models;

#nullable disable
using System.Text.Json.Serialization;

namespace ReactApp1.Server.Models
{
    public class Product
    {
        public string productId { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        [JsonIgnore]
        public decimal unitPrice { get; set; }
        public decimal? maximumQuantity { get; set; }
        public decimal sellPrice => unitPrice * 1.2m; // 20% markup
    }
}
