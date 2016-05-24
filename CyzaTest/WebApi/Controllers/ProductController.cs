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
    [RoutePrefix("api/Product")]
    public class ProductController : BaseAPIController
    {
        readonly ProductService service = new ProductService();
        // GET: api/Product
        public async Task<IHttpActionResult> Get()
        {
            var products = await service.GetAll();
            if (products.Count == 0) return NotFound();
            return Ok(products);
        }

        // GET: api/Product/5
        public async Task<IHttpActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await service.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST: api/Product
        public async Task<IHttpActionResult> Post(PostProduct model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                Name = model.Name
            };

            var changes = await service.Save(product);
            if (changes == 0) return InternalServerError();
            return Ok();
        }

        // PUT: api/Product/5
        public async Task<IHttpActionResult> Put(PutProduct model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                Id = model.Id,
                Name = model.Name
            };

            await service.Update(product);
            return Ok();
        }

        // DELETE: api/Product/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product { Id = id };
            var changes = await service.Delete(product);
            if (changes >= 1) return Ok();
            return NotFound();
        }
    }
}
