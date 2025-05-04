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

        public UserEntity GetByEmail(string email)
        {
            UserEntity user = _context.User.FirstOrDefault(u => u.Email == email);

            if (user is null)
                throw new ArgumentNullException(nameof(email), "Email inexistant");

            return user;
        }

        public string GetPassword(string email)
        {
            UserEntity user = _context.User.FirstOrDefault(u => u.Email == email);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(email), "Email inexistant");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentNullException(nameof(user.Password), "Mot de passe non défini");
            }

            return user.Password;
        }
    }
}