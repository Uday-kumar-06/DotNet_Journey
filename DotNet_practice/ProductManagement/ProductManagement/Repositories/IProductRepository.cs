using ProductManagement.Models;

namespace ProductManagement.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int id);

        void Add(Product product);

        void Update(Product product);

        void Delete(int id);

        void Save();
    }
}
