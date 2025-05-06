using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DAL.Entities
{
    [Table("OrderProducts")]
    public class OrderProductEntity
    {
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; } = null!;

        public int ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;

        public int Quantity { get; set; }
    }

}
