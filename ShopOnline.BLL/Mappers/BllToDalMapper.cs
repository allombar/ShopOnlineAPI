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
                Id = user.Id,
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

        public static CategoryEntity ToEntity(this Category category)
        {
            return new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
