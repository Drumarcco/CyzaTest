using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace WebApi.Models
{
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        private ApplicationUserManager _appUserManager;

        public ModelFactory(HttpRequestMessage request, ApplicationUserManager appUserManager)
        {
            _urlHelper = new UrlHelper(request);
            _appUserManager = appUserManager;
        }

        public object Create(List<SupplierProduct> supplierProducts)
        {
            return supplierProducts.Select(sp => new
            {
                sp.ProductId,
                sp.Product.Name,
                sp.Price,   
            });
        }

        public object Create(List<Product> products)
        {
            return products.Select(p => new
            {
                p.Id,
                p.Name
            });
        }
    }
}