using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public interface IRepository
    {
        ShopContext _context { get; }
        IEnumerable<Shop> GetShops();
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        Shop GetShop(int id);
        void CreateShop(Shop shop);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void UpdateShop(Shop product);
        void DeleteShop(int id);
        void DeleteProduct(int id);
    }
}
