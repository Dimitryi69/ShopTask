using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public class Repository : IRepository
    {
        public ShopContext _context { get; }

        public Repository(ShopContext context)
        {
            this._context = context;
        }
        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void CreateShop(Shop shop)
        {
            _context.Shops.Add(shop);
        }

        public void DeleteProduct(int id)
        {
            Product product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public void DeleteShop(int id)
        {
            Shop shop = _context.Shops.Find(id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
                _context.SaveChanges();
            }
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        public Shop GetShop(int id)
        {
            return _context.Shops.Find(id);
        }

        public IEnumerable<Shop> GetShops()
        {
            return _context.Shops;
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void UpdateShop(Shop product)
        {
            _context.Shops.Update(product);
            _context.SaveChanges();
        }
    }
}
