using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarShopApi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string ModelSku { get; set; } = String.Empty;
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Description { get; set; } = String.Empty;
        [Required]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category? Category{ get; set; }
    }
}
