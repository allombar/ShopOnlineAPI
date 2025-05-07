using Microsoft.JSInterop.Infrastructure;
using ShopOnline.API.Models.Auth;
using ShopOnline.API.Models.Product;
using ShopOnline.BLL.Models;

namespace ShopOnline.API.Mappers
{
    public static class ApiToBllMapper
    {
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
    }
}
