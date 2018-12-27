using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using RentalSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductDetails : IBase<ProductModel>
    {
        public OverwatchRentalSystemEntities dbContext => OverwatchRentalSystemEntities.Instance;


        //GET All the products in the DB 
        public IEnumerable<ProductModel> GetAll()
        {
            IEnumerable<Product> productList = new List<Product>();
            IEnumerable<ProductModel> list = new List<ProductModel>();

            try
            {
                productList = dbContext.Products.ToList();
                list = productList.Select(p => Mapper.Map<ProductModel>(p));


            }
            catch (Exception e)
            {
                throw e;
            }
            return list;

        }

        // Returns Boolean Value if Product has been Inserted
        public bool Insert(ProductModel entity)
        {
            Product product = null;
            bool status = false;
            try
            {
                product = Mapper.Map<Product>(entity);
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {

                throw e;
            }
            return status;
        }

        public ProductModel GetProductById(int productId)
        {
            Product product = null;
            try
            {
                product = dbContext.Products.SingleOrDefault(id => id.Id == productId);
            }
            catch (Exception e)
            {

                throw e;
            }

            return Mapper.Map<ProductModel>(product);
        }

        // GET the Products of All the Vendors
        public IEnumerable<ProductModel> GetAllProductsOfVendor(int vendorId)
        {
            IEnumerable<Product> result = new List<Product>();
            List<ProductModel> prodList = new List<ProductModel>();
            try
            {
                ProductModel pm = null;
                result = dbContext.Products.Where(p => p.VendorId == vendorId).ToList();
                foreach (Product item in result)
                {

                    pm = new ProductModel()
                    {
                        Id = item.Id,
                        CategoryId=item.CategoryId,
                        VendorId = item.VendorId,
                        ProductDescription = item.ProductDescription,
                        ProductUnitPrice = item.ProductUnitPrice,
                        ProductAvailability = item.ProductAvailability,
                        ProductImage1 = item.ProductImage1,
                        ProductImage2 = item.ProductImage2,
                        ProductImage3 = item.ProductImage3,
                        ProductName = item.ProductName,
                        RentEndDate = item.RentEndDate,
                        RentStartDate = item.RentStartDate
                    };

                    prodList.Add(Mapper.Map(item,pm));
                }

                prodList.AsEnumerable();

                //var result = dbContext.spGetAllProducts(vendorId);

                //if (result.Count() > 0)
                //{
                //    model= result.AsEnumerable<ProductModel>();
                //}
            }
            catch (Exception e)
            {
                throw e;
            }
            return prodList;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            IEnumerable<CategoryModel> list = null;
            try
            { 
            list=
                dbContext.Categories.Select(c=>new CategoryModel {
                Id=c.Id,
                Name=c.Name
            });
            }
            catch(Exception e)
            {
                throw e;
            }
            return list;
        }

        public ProductModel Update(ProductModel Entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
