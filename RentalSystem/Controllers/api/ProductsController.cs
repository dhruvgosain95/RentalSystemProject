using BusinessLayer;
using RentalSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentalSystem.Controllers.api
{
    public class ProductsController : ApiController
    {
        ProductDetails productDetails = new ProductDetails();

        // GET: api/Products/Get
        public IEnumerable<ProductModel> Get()
        {
            
            var products = productDetails.GetAll();
            
            return products;
            
        }

        // GET: api/Products/GetProductById
        public ProductModel GetProductById(int id)
        {
            var product = productDetails.GetProductById(id);

            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        // GET: api/Products/GetAllProductsOfVendor
        public IEnumerable<ProductModel> GetAllProductsOfVendor(int vendorId)
        {
            var result = productDetails.GetAllProductsOfVendor(vendorId);

            return result;
        }

        // GET : api/Products/Insert
        public bool Insert(ProductModel entity)
        {
            var result = productDetails.Insert(entity);
            return result;
        }
        
    }
}
