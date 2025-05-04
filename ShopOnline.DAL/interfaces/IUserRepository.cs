using ShopOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DAL.interfaces
{
    public interface IUserRepository
    {
        void Add(UserEntity user);
        UserEntity GetByEmail(string email);
        string GetPassword(string email);
    }
}
