using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Models;
using System.Data.Entity;

namespace WebApi.DataAccess.Repositories
{
    public class StockMovementRepository : Repository<StockMovement>
    {
        public StockMovementRepository(CyzaTestEntities context) : base(context)
        {
        }

        public async Task Restock(StockMovement stockMovement)
        {
            stockMovement.Type = StockMovementType.Inbound;
            Context.StockMovements.Add(stockMovement);

            var supplierProduct = await Context.SupplierProducts
                .Include(sp => sp.Product.Stock)
                .SingleOrDefaultAsync(sp => sp.SupplierId == stockMovement.SupplierId
                    && sp.ProductId == stockMovement.ProductId);

            supplierProduct.Product.Stock.Quantity +=
            stockMovement.Quantity;
        }
    }
}