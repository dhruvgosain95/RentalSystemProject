using BusinessLayer;
using RentalSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalSystem.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            FeedbackDetails feedbackDetailsInstace = new FeedbackDetails();
            feedbackDetailsInstace.Insert(feedbackModel);
            HttpContext.Session["FeedbackStatus"] = "success";
            return RedirectToAction("ShowAllCustomerProducts", "Product");
        }

        // Generates Form for Taking a Feedback
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult DisplayFeedback()
        {
            FeedbackDetails details = new FeedbackDetails();
            IEnumerable<FeedbackModel> model = details.GetAll();

            return View(model);
        }
    }
}
   