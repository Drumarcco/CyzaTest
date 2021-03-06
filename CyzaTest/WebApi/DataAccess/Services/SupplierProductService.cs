﻿using System;
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

        public async Task<SupplierProduct> GetById(params int[] id)
        {
            var supplierId = id[0];
            var productId = id[1];

            using (var db = new CyzaTestEntities())
            {
                return await db.SupplierProducts
                    .Include(sp => sp.Product)
                    .Include(sp => sp.Supplier)
                    .SingleOrDefaultAsync(sp => sp.SupplierId == supplierId
                    && sp.ProductId == productId);
            }
        }

        public async Task<List<SupplierProduct>> GetBySupplierId(int supplierId)
        {
            using (var db = new CyzaTestEntities())
            {
                return await db.SupplierProducts
                    .Include(sp => sp.Supplier)
                    .Include(sp => sp.Product)
                    .Where(sp => sp.SupplierId == supplierId).ToListAsync();
            }
        }

        public async Task<List<Product>> FindProductsNotAssigned(int supplierId)
        {
            using (var db = new CyzaTestEntities())
            {
                return await db.Products
                    .Where(p => p.SupplierProducts.All(sp => sp.SupplierId != supplierId)).ToListAsync();
            }
        }
    }
}