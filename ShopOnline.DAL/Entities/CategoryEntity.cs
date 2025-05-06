using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DAL.Entities
{
    [Table("Categories")]
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    }

}
