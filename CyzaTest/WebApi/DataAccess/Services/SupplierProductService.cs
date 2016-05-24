using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Models;
using SupplierProductRepository = WebApi.DataAccess.Repositories.SupplierProductRepository;

namespace WebApi.DataAccess.Services
{
    public class SupplierProductService : IService<SupplierProduct>
    {
        public async Task<int> Save(SupplierProduct supplierProduct)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new SupplierProductRepository(db);
                repository.Insert(supplierProduct);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Update(SupplierProduct supplierProduct)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new SupplierProductRepository(db);
                repository.Update(supplierProduct);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(SupplierProduct supplierProduct)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new SupplierProductRepository(db);
                repository.Delete(supplierProduct);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<List<SupplierProduct>> GetAll()
        {
            using (var db = new CyzaTestEntities())
            {
                return await db.SupplierProducts.ToListAsync();
            }
        }

        public async Task<SupplierProduct> GetById(params object[] id)
        {
            using (var db = new CyzaTestEntities())
            {
                return await db.SupplierProducts.FindAsync(id);
            }
        }
    }
}