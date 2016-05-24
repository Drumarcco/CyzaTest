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
    }
}
