using System.ComponentModel.DataAnnotations.Schema;


namespace ShopOnline.DAL.Entities
{
    [Table("Products")]
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PriceExclTax { get; set; }
        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; } = null!;

        public ICollection<OrderProductEntity> OrderProducts { get; set; } = new List<OrderProductEntity>();
    }
}
