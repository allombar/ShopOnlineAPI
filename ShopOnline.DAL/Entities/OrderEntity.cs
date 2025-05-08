using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DAL.Entities
{
    [Table("Orders")]
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public bool IsProcessed { get; set; }

        public int UserId { get; set; }
        public virtual UserEntity User { get; set; } = null!;

        public virtual ICollection<OrderProductEntity> OrderProducts { get; set; } = new List<OrderProductEntity>();
    }
}