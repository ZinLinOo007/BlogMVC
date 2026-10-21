using BlogMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public BlogsController(IBlogPostService blogPostService)
        {
            this._blogPostService = blogPostService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var blogPost = await _blogPostService.GetByUrlHandleAsync(urlHandle);
            return View(blogPost);
        }
    }
}
