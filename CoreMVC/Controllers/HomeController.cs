using System.Diagnostics;
using CoreMVC.Models;
using CoreMVC.Models.AppSettingConfigModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<SendEmailCredentials> _options;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(ILogger<HomeController> logger, IOptions<SendEmailCredentials> options, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            _options = options;
        }

        public IActionResult Index()
        {
            var envData = new EmailConfig
            {
                Email = _options.Value.Email,
                UserName = _options.Value.UserName,
                EnvName = _webHostEnvironment.EnvironmentName


            };
            return View(envData);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
