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
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password,
                Role = entity.Role
            };
        }
    }
}
