using AutoMapper;
using BusinessLayer;
using DataAccessLayer;
using RentalSystem.Utilities;
using RentalSystemModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace RentalSystem.Controllers
{
    public class ProductController : Controller
    {

        private static ProductDetails ProductDetailsInstance = null;

        public ProductController()
        {

        }

        // Product Details Instance
        public static ProductDetails PDInstance
        {

            get
            {
                if (ProductDetailsInstance == null)
                {
                    ProductDetailsInstance = new ProductDetails();
                }
                return ProductDetailsInstance;
            }
        }

        // GET:Display Customer Products

        public ActionResult ShowAllCustomerProducts()
        {

            IEnumerable<ProductModel> prodList = new List<ProductModel>();
            try
            {
                prodList = PDInstance.GetAll();
            }
            catch (Exception e)
            {
                Log.Error("Exception has occured", e);
            }
            return View(prodList);
        }

        // GET : Display Vendor Products
        public ActionResult ShowAllVendorProducts()
        {
            IEnumerable<ProductModel> prodList = new List<ProductModel>();
            try
            {
                int vendorId = Convert.ToInt32(HttpContext.Session["UserId"]);
                prodList = PDInstance.GetAllProductsOfVendor(vendorId);
            }
            catch(Exception e)
            {
                Log.Error("Exception has occured", e);
            }
            return View(prodList);

        }

        public ActionResult CreateNewProduct()
        {
            return View();
        }

        public ActionResult InsertProduct(ProductModel product)
        {

            ProductModel productModel = null;
            productModel = Mapper.Map<ProductModel>(product);
            productModel.VendorId = Convert.ToInt32(HttpContext.Session["UserId"]);
            productModel.CategoryId = 1;
            productModel.ProductImage1 = "~/Content/Images/default-car.jpg";
            productModel.ProductImage2 = "~/Content/Images/default-car.jpg";
            productModel.ProductImage3 = "~/Content/Images/default-car.jpg";
            bool status = PDInstance.Insert(productModel);
            if(Convert.ToInt32(HttpContext.Session["RoleId"]) == 2)
            { 
            return RedirectToAction("ShowAllCustomerProducts");
            }
            else if(Convert.ToInt32(HttpContext.Session["RoleId"]) == 1)
            {
                return RedirectToAction("ShowAllVendorProducts"); 
            }
            else
            {
                return RedirectToAction("AdminControl");
            }
        }

        public ActionResult AdminControl()
        {
            return View();
        }

        public ActionResult ProductDetails(int id)
        {
            ProductModel productModel = new ProductModel();
            try
            {
                productModel = PDInstance.GetProductById(id);
            }
            catch (Exception e)
            {

                Log.Error("Exception has occured", e);
            }

            return View(productModel);
        }
       


    }
}
