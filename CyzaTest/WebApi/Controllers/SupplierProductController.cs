using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.DataAccess.Services;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Supplier")]
    public class SupplierProductController : BaseAPIController
    {
        readonly SupplierProductService service = new SupplierProductService();

        [Route("{supplierId}/Products")]
        [ResponseType(typeof (List<ModelFactory.ProductReturnModel>))]
        public async Task<IHttpActionResult> GetProducts(int supplierId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await service.GetBySupplierId(supplierId);
            return Ok(ModelFactory.Create(products));
        }

        [Route("{supplierId}/UnassignedProducts")]
        [ResponseType(typeof (List<ModelFactory.ProductReturnModel>))]
        public async Task<IHttpActionResult> GetUnassignedProducts(int supplierId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await service.FindProductsNotAssigned(supplierId);
            return Ok(ModelFactory.Create(products));
        }

        [Route("Product")]
        public async Task<IHttpActionResult> Post(SupplierProductBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierProduct = new SupplierProduct
            {
                ProductId = model.ProductId,
                SupplierId = model.SupplierId,
                Price = model.Price
            };

            var changes = await service.Save(supplierProduct);
            if (changes == 0) return InternalServerError();
            return Ok();
        }

        [Route("Product")]
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

        [Route("{supplierId}/Product/{productId}")]
        [HttpGet]
        [ResponseType(typeof (ModelFactory.ProductReturnModel))]
        public async Task<IHttpActionResult> Get(int supplierId, int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await service.GetById(supplierId, productId);
            if (product == null) return NotFound();
            return Ok(ModelFactory.Create(product));
        }

        [Route("{supplierId}/Product/{productId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int supplierId, int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierProduct = new SupplierProduct
            {
                SupplierId = supplierId,
                ProductId = productId
            };

            var changes = await service.Delete(supplierProduct);
            if (changes >= 1) return Ok();
            return NotFound();
        }

    }
}
