using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.DataAccess.Repositories;
using WebApi.Models;

namespace WebApi.DataAccess.Services
{
    public class StockMovementService 
    {
        public async Task<int> Restock(StockMovement stockMovement)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new StockMovementRepository(db);
                await repository.Restock(stockMovement);
                return await db.SaveChangesAsync();
            }
        }

        public async Task<int> Outbound(StockMovement stockMovement)
        {
            using (var db = new CyzaTestEntities())
            {
                var repository = new StockMovementRepository(db);
                await repository.Outbound(stockMovement);
                return await db.SaveChangesAsync();
            }
        } 
    }
}