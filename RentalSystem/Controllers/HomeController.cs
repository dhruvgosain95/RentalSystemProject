using BusinessLayer;
using RentalSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RentalSystem.Controllers
    {
        public class HomeController : Controller
        {
            private static UserDetails UserDetailsInstance = null;

            public HomeController()
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


        public ActionResult Index()
        {
            return View();
        }
           

        }
    }

