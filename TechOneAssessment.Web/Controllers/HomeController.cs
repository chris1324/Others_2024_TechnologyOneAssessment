using Microsoft.AspNetCore.Mvc;
using TechOneAssessment.Web.Utilities;

namespace TechOneAssessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConvertToWords(decimal input)
        {
            try
            {
                var result = CurrencyWordConverter.Convert(input);
                return Content(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting dollars from numeric to words", new { input });
                return Content("Internal Server Error");
            }
        }
    }
}