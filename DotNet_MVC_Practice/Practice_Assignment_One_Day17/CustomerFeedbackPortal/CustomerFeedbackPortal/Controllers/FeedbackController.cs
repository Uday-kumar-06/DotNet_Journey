using CustomerFeedbackPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerFeedbackPortal.Controllers
{
    public class FeedbackController : Controller
    {
        private static List<Feedback> feedbackList = new List<Feedback>();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbackList.Add(feedback);
                return View("Success", feedback);
            }

            return View("Index");
        }

        public IActionResult ViewFeedback()
        {
            return View(feedbackList);
        }
    }
}
