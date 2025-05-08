using ShopOnline.DAL.Entities;
using ShopOnline.BLL.Models;

namespace ShopOnline.BLL.Mappers
{
    public static class DalToBllMapper
    {
        public static User ToBll(this UserEntity entity)
        {
            return new User
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role
            };
        }

        public static Category ToBll(this CategoryEntity entity)
        {
            return new Category
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Product ToBll(this ProductEntity entity)
        {
            return new Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                PriceExclTax = entity.PriceExclTax,
                StockQuantity = entity.StockQuantity,
                CategoryId = entity.CategoryId
            };
        }
    }
}
