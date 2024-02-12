using ProductsDemoApi.Context;
using ProductsDemoApi.Models;
using System.Data.Entity;

namespace ProductsDemoApi.Repositories
{
    public class ProductsRepository : IDataRepository<Product>
    {
        private readonly ProductContext _context;
        public ProductsRepository(ProductContext productContext) { 
            _context = productContext;
        }

        public void Delete(int id)
        {
            var found = GetById(id);
            if (found != null)
            {
                _context.Products.Remove(found);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Product entity)
        {
            var found = GetById(entity.Id);
            if (found != null)
            {
                _context.Products.Add(entity);
            }
            else
            {
                _context.Products.Update(entity);
            }
            _context.SaveChanges();
        }
    }
}
