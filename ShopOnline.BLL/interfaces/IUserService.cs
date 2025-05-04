using ShopOnline.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.BLL.interfaces
{
    public interface IUserService
    {
        void Register(User user);
        User Login(string email, string password);
    }
}
