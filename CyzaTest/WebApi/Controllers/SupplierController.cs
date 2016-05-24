using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.DataAccess.Services;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Supplier")]
    public class SupplierController : BaseAPIController
    {
        readonly SupplierService service = new SupplierService();

        public async Task<IHttpActionResult> Get()
        {
            var suppliers = await service.GetAll();
            if (suppliers.Count == 0) return NotFound();
            return Ok(suppliers);
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = await service.GetById(id);
            if (supplier == null) return NotFound();
            return Ok(supplier);
        }

        [Route("{id}/Products")]
        public async Task<IHttpActionResult> GetProducts(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierProductService = new SupplierProductService();
            var supplierProducts = await supplierProductService.GetBySupplierId(id);
            if (supplierProducts.Count == 0) return NotFound();
            return Ok(ModelFactory.Create(supplierProducts));
        }

        [Route("{id}/UnassignedProducts")]
        public async Task<IHttpActionResult> GetUnassignedProducts(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierProductService = new SupplierProductService();
            var products = await supplierProductService.FindProductsNotAssigned(id);
            return Ok(ModelFactory.Create(products));
        }

        public async Task<IHttpActionResult> Post(PostSupplier model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = new Supplier
            {
                Name = model.Name
            };

            var changes = await service.Save(supplier);
            if (changes == 0) return InternalServerError();
            return Ok();
        }

        [Route("Product")]
        [HttpPost]
        public async Task<IHttpActionResult> PostProduct(SupplierProductBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var supplierProduct = new SupplierProduct
            {
                ProductId = model.ProductId,
                SupplierId = model.SupplierId,
                Price = model.Price
            };

            var supplierProductService = new SupplierProductService();
            var changes = await supplierProductService.Save(supplierProduct);
            if (changes == 0) return InternalServerError();
            return Ok();
        }

        public async Task<IHttpActionResult> Put(PutSupplier model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = new Supplier
            {
                Id = model.Id,
                Name = model.Name
            };

            await service.Update(supplier);
            return Ok();
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = new Supplier { Id = id };
            var changes = await service.Delete(supplier);
            if (changes >= 1) return Ok();
            return NotFound();
        }

        [Route("{supplierId}/Product/{productId}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(int supplierId, int productId)
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

            var supplierProductService = new SupplierProductService();
            var changes = await supplierProductService.Delete(supplierProduct);
            if (changes >= 1) return Ok();
            return NotFound();
        }
    }
}
