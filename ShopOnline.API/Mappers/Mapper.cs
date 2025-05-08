using Microsoft.JSInterop.Infrastructure;
using ShopOnline.API.Models.Auth;
using ShopOnline.API.Models.Category;
using ShopOnline.API.Models.Product;
using ShopOnline.BLL.Models;
using ShopOnline.DAL.Entities;
using System.ComponentModel;

namespace ShopOnline.API.Mappers
{
    public static class Mapper
    {
        #region User
        public static User ToBll(this RegisterRequest dto)
        {
            return new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password
            };
        }

        public static Product ToBll(this ProductCreateRequest dto)
        {
            return new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                PriceExclTax = dto.PriceExclTax,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId
            };
        }
        #endregion

        #region Category
        public static CategoryRequest ToDto(this CategoryEntity entity)
        {
            return new CategoryRequest
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
        public static CategoryRequest ToDto(this Category entity)
        {
            return new CategoryRequest
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Category ToBll(this CategoryRequest entity)
        {
            return new Category
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static Category ToBll(this CategoryPost entity)
        {
            return new Category
            {
                Name = entity.Name
            };
        }
        #endregion
    }
}
