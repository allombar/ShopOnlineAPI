namespace ShopOnline.API.Models.Product
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal PriceExclTax { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

}
