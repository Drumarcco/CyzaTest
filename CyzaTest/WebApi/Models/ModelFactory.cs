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

        public object Create(List<StockMovement> supplierProducts)
        {
            return supplierProducts.Select(Create);
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
                Name = product.Name,
                Stock = product.Stock.Quantity
            };
        }

        public StockMovementReturnModel Create(StockMovement stockMovement)
        {
            return new StockMovementReturnModel
            {
                Id = stockMovement.Id,
                Type = stockMovement.Type,
                SupplierId = stockMovement.SupplierId,
                ProductId = stockMovement.ProductId,
                Quantity = stockMovement.Quantity,
                UserId = stockMovement.UserId
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
            public int Stock { get; set; }
        }

        public class StockMovementReturnModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int? SupplierId { get; set; }
            public string UserId { get; set; }
            public string ProductName { get; set; }
            public string SupplierName { get; set; }
            public int Quantity { get; set; }
            public StockMovementType Type { get; set; }
        }
    }
}