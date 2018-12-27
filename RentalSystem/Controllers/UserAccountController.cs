using BusinessLayer;
using RentalSystem.Utilities;
using RentalSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RentalSystem.Controllers
{
    public class UserAccountController : Controller
    {
        private static UserDetails UserDetailsInstance = null;

        public UserAccountController()
        {

        }

        public static UserDetails UDInstance
        {

            get
            {
                if (UserDetailsInstance == null)
                {
                    UserDetailsInstance = new UserDetails();
                }
                return UserDetailsInstance;
            }
        }
        // GET: Register
        [System.Web.Http.HttpPost]
        public ActionResult RegisterCustomer(string customer_email, string pass, string confpass, string userType)
        {
            UserLoginModel uLoginModel = new UserLoginModel();
            uLoginModel.UserEmail = customer_email;
            uLoginModel.UserPassword = pass;
            uLoginModel.RoleId = Convert.ToInt32(userType);
            bool registrationStatus = HomeController.UDInstance.Insert(uLoginModel);
            if (registrationStatus == true)
            { 
                ViewBag.registrationStatus = true;
                Log.Info("Registeration Successful");
            }
            else
            {
                ViewBag.registrationStatus = false;
                Log.Info("Registeration Successful");
            }
                

            return View("~/Views/Home/index.cshtml");
        }
        // Login Authentication
        public ActionResult LoginUser(string email, string password)
        {
            int roleId = 999;
            UserLoginModel uLoginModel = new UserLoginModel();
            uLoginModel.UserEmail = email;
            uLoginModel.UserPassword = password;
            roleId = UDInstance.Login(uLoginModel);
            bool loginStatus = false;

            if ( roleId == 2)
            {

                loginStatus = true;

                Log.Info("Customer Product-page started...");

                return RedirectToAction("ShowAllCustomerProducts","Product");
            }
            else if(roleId == 1)
            {
                loginStatus = true;

                Log.Info("Vendor Product-page started...");

                return RedirectToAction("ShowAllVendorProducts", "Product");
            }

            else if (roleId == 3)
            {
                loginStatus = true;
                Session["feedback"]= "feedback";

                Log.Info("Admin Login-Page Started");

                return RedirectToAction("ShowAllCustomerProducts", "Product");
            }
            else
            {
                Log.Info("Login Failed Redirecting to Index Page");

                ViewBag.loginStatus = loginStatus;
                return View("~/Views/Home/index.cshtml");
            }
           

        }
        // LogsOut the Users and Removes the current Session
        public ActionResult Logout()
        {
            Log.Info("User has been Logged Out");
            HttpContext.Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

    }
}