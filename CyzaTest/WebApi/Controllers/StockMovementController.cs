using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.DataAccess.Services;
using WebApi.Models;
using Microsoft.AspNet.Identity;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/StockMovement")]
    public class StockMovementController : BaseAPIController
    {
        readonly StockMovementService service = new StockMovementService();

        [Route("Inbound")]
        [HttpPost]
        public async Task<IHttpActionResult> PostInbound(StockMovementBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockMovement = new StockMovement
            {
                Id = 0,
                ProductId = model.ProductId,
                SupplierId = model.SupplierId,
                Quantity = model.Quantity,
                UserId = User.Identity.GetUserId()
            };

            var changes = await service.Restock(stockMovement);
            if (changes > 0) return Ok();
            return InternalServerError();
        }

        [Route("Outbound")]
        [HttpPost]
        public async Task<IHttpActionResult> PostOutbound(StockMovementBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockMovement = new StockMovement
            {
                Id = 0,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                UserId =  User.Identity.GetUserId()
            };

            var changes = await service.Outbound(stockMovement);
            if (changes > 0) return Ok();
            return InternalServerError();
        }
    }
}
