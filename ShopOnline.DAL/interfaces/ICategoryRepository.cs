using ShopOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DAL.interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryEntity> GetAll();
        CategoryEntity? GetById(int id);
        void Add(CategoryEntity category);
        void Update(int id, CategoryEntity category);
        void Delete(CategoryEntity category);
    }
}
