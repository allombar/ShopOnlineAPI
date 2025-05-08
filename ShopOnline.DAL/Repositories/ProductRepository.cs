using ShopOnline.DAL.Entities;
using ShopOnline.DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopOnlineDbContext _context;
        public ProductRepository(ShopOnlineDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _context.Product.ToList();
        }

        public ProductEntity? GetById(int id)
        {
            return _context.Product.Find(id);
        }

        public IEnumerable<ProductEntity> GetByCategoryId(int categoryId)
        {
            return _context.Product
                .Where(p => p.CategoryId == categoryId)
                .ToList();
        }

        public void Add(ProductEntity product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, ProductEntity product)
        {
            var existing = _context.Product.FirstOrDefault(p => p.Id == id);
            if (existing is null)
                throw new ArgumentException("Produit introuvable");

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.PriceExclTax = product.PriceExclTax;
            existing.StockQuantity = product.StockQuantity;
            existing.CategoryId = product.CategoryId;

            _context.SaveChanges();
        }

        public void Delete(ProductEntity product)
        {
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
    }
}
