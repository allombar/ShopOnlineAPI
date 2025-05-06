using System.ComponentModel.DataAnnotations.Schema;

namespace ShopOnline.DAL.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string Role { get; set; } = "Client";
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
