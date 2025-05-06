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

        public int Create(ProductEntity product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductEntity> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ProductEntity? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
