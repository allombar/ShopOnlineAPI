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
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        IEnumerable<Product> GetByCategoryId(int categoryId);
        void Create(Product product);
        void Update(int id, Product product);
        void Delete(int id);
    }
}
