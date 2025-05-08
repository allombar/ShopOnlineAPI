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

        #region Product
        public static ProductResponse ToDto(this Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                PriceExclTax = product.PriceExclTax,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId
            };
        }

        public static Product ToBll(this ProductRequest product)
        {
            return new Product
            {
                Name = product.Name,
                Description = product.Description,
                PriceExclTax = product.PriceExclTax,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId
            };
        }
        #endregion
    }
}
