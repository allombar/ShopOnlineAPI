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
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public int Create(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Le nom du produit est requis.");

            if (product.PriceExclTax <= 0)
                throw new ArgumentException("Le prix doit être strictement positif.");

            if (product.StockQuantity < 0)
                throw new ArgumentException("La quantité en stock ne peut pas être négative.");

            return _repository.Create(product.ToEntity());
        }
    }
}
