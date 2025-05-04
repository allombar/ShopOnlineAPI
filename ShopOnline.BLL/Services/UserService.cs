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
            try
            {
                if (_repository.GetByEmail(user.Email) != null)
                    throw new ArgumentException("Cet email est déjà utilisé.");

                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                _repository.Add(user.ToEntity());
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erreur lors de l'inscription : {ex.Message}", ex);
            }
        }

        public User Login(string email, string password)
        {
            try
            {
                string hash = _repository.GetPassword(email);

                if (!BCrypt.Net.BCrypt.Verify(password, hash))
                    throw new ArgumentException("Mot de passe incorrect.");

                UserEntity entity = _repository.GetByEmail(email);

                return entity.ToModel();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Email incorrect.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur lors de la connexion.", ex);
            }
        }
    }
}