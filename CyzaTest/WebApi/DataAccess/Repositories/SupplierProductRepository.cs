using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.DataAccess.Repositories
{
    public class SupplierProductRepository : Repository<SupplierProduct>
    {
        public SupplierProductRepository(CyzaTestEntities context) : base(context)
        {
        }
    }
}