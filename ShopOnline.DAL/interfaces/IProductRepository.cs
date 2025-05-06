using ShopOnline.DAL.Entities;

namespace ShopOnline.DAL.interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductEntity> GetAll();
        ProductEntity? GetById(int id);
        IEnumerable<ProductEntity> GetByCategory(int categoryId);
        int Create(ProductEntity product);
        bool Update(ProductEntity product);
        bool Delete(int id);
    }
}
