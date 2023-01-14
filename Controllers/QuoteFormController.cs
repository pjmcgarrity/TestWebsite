using Microsoft.AspNetCore.Mvc;
using System;
using TestWebsite.Models.Quote;

namespace TestWebsite.Controllers
{
    public class QuoteFormController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Quote Form";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult CreateQuote(QuoteViewModel model)
        {
            if (model.Quote.TotalSize < 50)
            {
                return Json(new { successful = false, error = "The total size is too small for a quote." });
            }

            if (model.Quote.TotalRebuildCost < 100)
            {
                return Json(new { successful = false, error = "Total rebuild cost is too low." });
            }

            return Json(new { successful = true, reference = Guid.NewGuid() });
        }
    }
}
