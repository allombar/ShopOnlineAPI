using ShopOnline.DAL.interfaces;
using ShopOnline.BLL.interfaces;
using ShopOnline.BLL.Models;
using ShopOnline.BLL.Mappers;
using ShopOnline.DAL.Entities;

namespace ShopOnline.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void Register(User user)
        {
            if (_repository.GetByEmail(user.Email) != null)
                throw new ArgumentException("L'email est déjà utilisé.");

            string hash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hash;

            _repository.Add(user.ToEntity());
        }

        public User Login(string email, string password)
        {
            var entity = _repository.GetByEmail(email) ?? throw new ArgumentException("Email introuvable.");

            if (!BCrypt.Net.BCrypt.Verify(password, entity.Password))
                throw new ArgumentException("Mot de passe incorrect.");

            return entity.ToBll();
        }
    }
}