using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.BLL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal PriceExclTax { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
