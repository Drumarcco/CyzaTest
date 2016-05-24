using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.DataAccess.Services;
using WebApi.Models;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Product")]
    public class SupplierProductController : ApiController
    {
        readonly SupplierProductService service = new SupplierProductService();

        public async Task<IHttpActionResult> Get()
        {
            var supplierProducts = await service.GetAll();
            if (supplierProducts.Count == 0) return NotFound();
            return Ok(supplierProducts);
        }

        public async Task<IHttpActionResult> Get(int supplierId, int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierProduct = await service.GetById(supplierId, productId);
            if (supplierProduct == null) return NotFound();
            return Ok(supplierProduct);
        }


        public async Task<IHttpActionResult> Post(SupplierProductBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierProduct = new SupplierProduct
            {
                SupplierId = model.SupplierId,
                ProductId = model.ProductId,
                Price = model.Price
            };

            var changes = await service.Save(supplierProduct);
            if (changes == 0) return InternalServerError();
            return Ok();
        }


        public async Task<IHttpActionResult> Put(SupplierProductBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierProduct = new SupplierProduct
            {
                SupplierId = model.SupplierId,
                ProductId = model.ProductId,
                Price = model.Price
            };

            await service.Update(supplierProduct);
            return Ok();
        }

        public async Task<IHttpActionResult> Delete(int productId, int supplierId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierProduct = new SupplierProduct
            {
                ProductId = productId,
                SupplierId = supplierId
            };

            var changes = await service.Delete(supplierProduct);
            if (changes >= 1) return Ok();
            return NotFound();
        }
    }
}
