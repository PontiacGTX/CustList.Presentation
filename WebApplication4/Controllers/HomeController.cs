using CustList.Entities.Entities;
using CustList.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEntityService<Customer> _customerServices;
        private readonly IEntityService<CustomerPhone> _customerPhoneService;

        public HomeController(ILogger<HomeController> logger,IEntityService<Customer> customerServices,IEntityService<CustomerPhone> customerPhoneService)
        {
            _logger = logger;
            _customerServices = customerServices;
            _customerPhoneService = customerPhoneService;
        }

        public async Task<IActionResult> Index()
        {

            return View((await _customerServices.GetAll()).Data);
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