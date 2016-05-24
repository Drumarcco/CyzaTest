using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.DataAccess.Repositories;
using WebApi.Models;

namespace WebApi.DataAccess.Services
{
    public class SupplierService : IService<Supplier>
    {
        public async Task<int> Save(Supplier supplier)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new SupplierRepository(db);
                repository.Insert(supplier);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Update(Supplier supplier)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new SupplierRepository(db);
                repository.Update(supplier);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(Supplier supplier)
        {   
            using (var db = new CyzaTestEntities())
            {
                var repository = new SupplierRepository(db);
                repository.Delete(supplier);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<List<Supplier>> GetAll()
        {
            using (var db = new CyzaTestEntities())
            {
                return await db.Suppliers.ToListAsync();
            }
        }

        public async Task<Supplier> GetById(params object[] id)
        {
            using (var db = new CyzaTestEntities())
            {
                return await db.Suppliers.FindAsync(id);
            }
        }
    }
}