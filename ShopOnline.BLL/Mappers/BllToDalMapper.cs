using ShopOnline.DAL.Entities;
using ShopOnline.BLL.Models;

namespace ShopOnline.BLL.Mappers
{
    public static class BllToDalMapper
    {
        public static UserEntity ToEntity(this User user)
        {
            return new UserEntity
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
        }

        public static ProductEntity ToEntity(this Product product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PriceExclTax = product.PriceExclTax,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId
            };
        }
        public static User ToModel(this UserEntity entity)
        {
            return new User
            {
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role
            };
        }

    }
}
