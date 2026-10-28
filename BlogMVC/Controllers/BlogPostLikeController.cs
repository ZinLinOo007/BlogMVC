using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;
using BlogMVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostLikeController : ControllerBase
    {
        private readonly IBlogPostLikeService _blogPostLikeService;

        public BlogPostLikeController(IBlogPostLikeService blogPostLikeService)
        {
            this._blogPostLikeService = blogPostLikeService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
        {
            var model = new BlogPostLike
            {
                BlogPostId = addLikeRequest.BlogPostId,
                UserId = addLikeRequest.UserId
            };

            await _blogPostLikeService.AddLikeForBlog(model);
            return Ok();
        }
        [HttpGet]
        [Route("{blogPostId:Guid}/totalLikes")]
        public async Task<IActionResult> GetTotalLikes([FromRoute]Guid blogPostId)
        {
            var totalLikes = await _blogPostLikeService.GetTotalLikes(blogPostId);
            return Ok(totalLikes);
        }
    }
}
