using System.ComponentModel.DataAnnotations;

namespace ShopOnline.API.Models.Product
{
    public class ProductRequest
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, 99999.99)]
        public decimal PriceExclTax { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }

}
