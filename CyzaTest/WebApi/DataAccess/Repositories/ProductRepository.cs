﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(CyzaTestEntities context) : base(context)
        {
        }
    }
}