using ShopOnline.DAL.Entities;

namespace ShopOnline.DAL.interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductEntity> GetAll();
        ProductEntity? GetById(int id);
        IEnumerable<ProductEntity> GetByCategoryId(int categoryId);
        void Add(ProductEntity product);
        void Update(int id, ProductEntity product);
        void Delete(ProductEntity product);
    }
}
