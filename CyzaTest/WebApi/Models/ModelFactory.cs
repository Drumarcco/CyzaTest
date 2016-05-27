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
            return supplierProducts.Select(Create);
        }

        public object Create(List<Product> products)
        {
            return products.Select(Create);
        }

        public SupplierProductReturnModel Create(SupplierProduct supplierProduct)
        {
            return new SupplierProductReturnModel
            {
                ProductId = supplierProduct.ProductId,
                SupplierId = supplierProduct.SupplierId,
                Price = supplierProduct.Price,
                ProductName = supplierProduct.Product.Name,
                SupplierName = supplierProduct.Supplier.Name
            };
        }

        public ProductReturnModel Create(Product product)
        {
            return new ProductReturnModel
            {
                Id = product.Id,
                Name = product.Name
            };
        }

        public class SupplierProductReturnModel
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
            public int SupplierId { get; set; }
            public string SupplierName { get; set; }
        }

        public class ProductReturnModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}