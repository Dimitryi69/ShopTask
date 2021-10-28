using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Processing request {0}", Request.Path);
            return View();
        }
        [HttpGet("Home/Details/{id}")]
        public IActionResult Details(int id)
        {
            ViewBag.shopId = id.ToString();
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> Add([FromForm]Product product)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}/api/product";
            var request = new HttpRequestMessage(HttpMethod.Post,
            baseUrl);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            request.Content = JsonContent.Create(product);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Home", new { id = product.ShopId });
            }
            return RedirectToAction("Index", "Home");
        }

        async public Task<IActionResult> Edit(int id)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}/api/product/{id}";
            var request = new HttpRequestMessage(HttpMethod.Get,
            baseUrl);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return View(JsonConvert.DeserializeObject<Product>(responseBody));
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        async public Task<IActionResult> Edit(Product product)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}/api/product/{product.Id}";
            var request = new HttpRequestMessage(HttpMethod.Put,
            baseUrl);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            request.Content = JsonContent.Create(product);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Home", new { id = product.ShopId });
            }
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
