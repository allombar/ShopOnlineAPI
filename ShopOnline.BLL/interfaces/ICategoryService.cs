using ShopOnline.BLL.Models;
using ShopOnline.DAL.Entities;

namespace ShopOnline.BLL.interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryEntity> GetAll();
        Category? GetById(int id);
        void Create(Category entity);
        void Update(int id, Category entity);
        void Delete(int id);
    }
}
