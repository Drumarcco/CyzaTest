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

            var stock = await Context.Stocks.SingleOrDefaultAsync(s => s.ProductId == stockMovement.ProductId);
            stock.Quantity += stockMovement.Quantity;
        }

        public async Task Outbound(StockMovement stockMovement)
        {
            stockMovement.Type = StockMovementType.Outbound;
            Context.StockMovements.Add(stockMovement);


            var stock = await Context.Stocks.SingleOrDefaultAsync(s => s.ProductId == stockMovement.ProductId);
            stock.Quantity -= stockMovement.Quantity;
        }
    }
}