using System.Diagnostics;
using BlogMVC.Models;
using BlogMVC.Models.ViewModels;
using BlogMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostService _blogPostService;
        private readonly ITagService _tagService;

        public HomeController(ILogger<HomeController> logger 
            , IBlogPostService blogPostService
            , ITagService tagService)
        {
            _logger = logger;
            this._blogPostService = blogPostService;
            this._tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var blogPosts =   await _blogPostService.GetAllAsync();
            var tags = await _tagService.GetAllAsync();

            var model = new HomeViewModel
            {
                BlogPosts = blogPosts,
                Tags = tags
            };
            return View(model);
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
