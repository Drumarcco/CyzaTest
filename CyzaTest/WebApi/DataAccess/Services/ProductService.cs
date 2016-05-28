using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.DataAccess.Repositories;
using WebApi.Models;

namespace WebApi.DataAccess.Services
{
    public class ProductService : IService<Product>
    {
        public async Task<int> Save(Product product)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new ProductRepository(db);
                repository.Insert(product);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Update(Product product)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new ProductRepository(db);
                repository.Update(product);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(Product product)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new ProductRepository(db);
                repository.Delete(product);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAll()
        {
            using (var db = new CyzaTestEntities())
            {
                return await db.Products.Include(p => p.Stock).ToListAsync();
            }
        }

        public async Task<Product> GetById(int id)
        {
            using (var db = new CyzaTestEntities())
            {
                return await db.Products.Include(p => p.Stock)
                    .SingleOrDefaultAsync(p => p.Id == id);
            }
        }
    }
}