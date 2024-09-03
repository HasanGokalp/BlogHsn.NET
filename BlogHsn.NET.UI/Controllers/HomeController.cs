using BlogHsn.NET.API.Entities;
using BlogHsn.NET.UI.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogHsn.NET.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public HomeController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7242/api/Posts");
            var posts = await response.Content.ReadFromJsonAsync<List<Post>>();

            foreach (var post in posts)
            {
                var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:View-Update-queue"));
                await endpoint.Send<Post>(post);
            }
            return View(posts);
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
