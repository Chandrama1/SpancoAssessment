using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Models;
using Services;
using Services.Interfaces;

namespace SpancoAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService _IService;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _IService = new Service(configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SavePatientDetails(FormFields formFields)
        {
            var isSuccess =  _IService.SavePatientDetails(formFields);
            string view = isSuccess ? "Index" : "Success";
            return RedirectToAction(view);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
