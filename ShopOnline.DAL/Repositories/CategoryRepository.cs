using ShopOnline.DAL.Entities;
using ShopOnline.DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopOnlineDbContext _context;

        public CategoryRepository(ShopOnlineDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryEntity> GetAll()
        {
            return _context.Category.ToList();
        }

        public CategoryEntity? GetById(int id)
        {
            CategoryEntity category = _context.Category.Find(id);
            if (category is null) throw new ArgumentException("Catégorie introuvable");
            return category;
        }

        public void Add(CategoryEntity category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, CategoryEntity category)
        {
            CategoryEntity update = _context.Category.FirstOrDefault(c => c.Id == id);
            if (category is null) throw new ArgumentException("Catégorie introuvable");

            update.Name = category.Name;

            _context.SaveChanges();
        }

        public void Delete(CategoryEntity category)
        {
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
    }
}