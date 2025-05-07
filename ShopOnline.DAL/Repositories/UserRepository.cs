using ShopOnline.DAL.Entities;
using Microsoft.Data.SqlClient;
using ShopOnline.DAL.interfaces;

namespace ShopOnline.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopOnlineDbContext _context;

        public UserRepository(ShopOnlineDbContext context)
        {
            _context = context;
        }

        public void Add(UserEntity user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public UserEntity? GetByEmail(string email)
        {
            return _context.User.FirstOrDefault(u => u.Email == email);
        }

        public string GetPassword(string email)
        {
            return GetByEmail(email)?.Password ?? throw new ArgumentException("Email introuvable.");
        }
    }
}