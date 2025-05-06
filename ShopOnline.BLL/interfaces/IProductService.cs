using ShopOnline.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.BLL.interfaces
{
    public interface IProductService
    {
        int Create(Product product);
    }
}
