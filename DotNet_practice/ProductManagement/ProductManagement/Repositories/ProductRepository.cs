using ProductManagement.data;
using ProductManagement.Models;

namespace ProductManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts() { 
            return _context.Products.ToList();
        }

        public Product GetProductById(int id) { 
            return _context.Products.Find(id);
        }

        public void Add(Product product) { 
            _context.Products.Add(product);
        }

        public void Update(Product product) { 
            _context.Products.Update(product);
        }

        public void Delete(int id) { 
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
        }

        public void Save() { 
            _context.SaveChanges();
        }
    }
}
