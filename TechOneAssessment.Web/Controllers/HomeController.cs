using Microsoft.AspNetCore.Mvc;
using TechOneAssessment.Web.Exceptions;
using TechOneAssessment.Web.Utilities;

namespace TechOneAssessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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
                var result = DollarsWordConverterV1.Convert(input);
                return Content(result);
            }
            catch (InputException ex)
            {
                _logger.LogError(ex, "Input Error when convert dollars from numeric to words", new { input });
                return Content(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Internal Server Error when convert dollars from numeric to words", new { input });
                return Content("Internal Server Error");
            }
        }
    }
}