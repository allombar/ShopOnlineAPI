using ShopOnline.BLL.interfaces;
using ShopOnline.BLL.Mappers;
using ShopOnline.BLL.Models;
using ShopOnline.DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll().Select(p => p.ToBll());
        }

        public Product GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null) throw new ArgumentException("Produit introuvable");
            return entity.ToBll();
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return _repository.GetByCategoryId(categoryId).Select(p => p.ToBll());
        }

        public void Create(Product product)
        {
            if (!_categoryRepository.GetAll().Any(c => c.Id == product.CategoryId))
                throw new ArgumentException("Catégorie invalide");

            _repository.Add(product.ToEntity());
        }

        public void Update(int id, Product product)
        {
            _repository.Update(id, product.ToEntity());
        }

        public void Delete(int id)
        {
            var product = _repository.GetById(id);
            if (product is null)
                throw new InvalidOperationException("Produit introuvable.");

            _repository.Delete(product);
        }
    }
}
