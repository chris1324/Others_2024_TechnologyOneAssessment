using Microsoft.AspNetCore.Mvc;
using TechOneAssessment.Web.Exceptions;
using TechOneAssessment.Web.Utilities;

namespace TechOneAssessment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDollarsWordConverter _dollarsWordConverter;

        public HomeController(ILogger<HomeController> logger, IDollarsWordConverter dollarsWordConverter)
        {
            _logger = logger;
            _dollarsWordConverter = dollarsWordConverter;
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
                var result = _dollarsWordConverter.Convert(input);
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