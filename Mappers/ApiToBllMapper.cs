using ShopOnline.API.Models.Auth;
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
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
        }
    }
}
