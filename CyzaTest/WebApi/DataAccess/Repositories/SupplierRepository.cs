using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.DataAccess.Repositories
{
    public class SupplierRepository : Repository<Supplier>
    {
        public SupplierRepository(CyzaTestEntities context) : base(context)
        {
        }
    }
}