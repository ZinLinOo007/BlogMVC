using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;
using BlogMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace BlogMVC.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostService _blogPostService;
        private readonly IBlogPostLikeService _blogPostLikeService;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBlogPostCommentService _blogPostCommentService;

        public BlogsController(IBlogPostService blogPostService,
            IBlogPostLikeService blogPostLikeService,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IBlogPostCommentService blogPostCommentService)
        {
            this._blogPostService = blogPostService;
            this._blogPostLikeService = blogPostLikeService;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._blogPostCommentService = blogPostCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var liked = false;
            var blogPost = await _blogPostService.GetByUrlHandleAsync(urlHandle);
            var blogDetailsViewModel = new BlogDetailsViewModel();
            if (blogPost != null)
            {
              int totalLikes =   await _blogPostLikeService.GetTotalLikes(blogPost.Id);
                if (_signInManager.IsSignedIn(User))
                {
                    var likesForBlog = await _blogPostLikeService.GetLikesForBlogPost(blogPost.Id);
                    var userId = _userManager.GetUserId(User);
                    if(userId != null)
                    {
                        var likeFromUser = likesForBlog.FirstOrDefault(x=>x.UserId == Guid.Parse(userId));
                        liked = likeFromUser != null;
                    }
                }

                var blogCommentDomainModel = await _blogPostCommentService.GetCommentsByBlogIdAsync(blogPost.Id);

                var blogCommentForView = new List<BlogComment>();
                foreach(var blogComment in blogCommentDomainModel)
                {
                    blogCommentForView.Add(new BlogComment
                    {
                        Description = blogComment.Description,
                        DateAdded = blogComment.DateAdded,
                        Username =  (await _userManager.FindByIdAsync(blogComment.UserId.ToString())).UserName
                    });
                }

                blogDetailsViewModel = new BlogDetailsViewModel
                {
                    Id = blogPost.Id,
                    Heading = blogPost.Heading,
                    PageTitle = blogPost.PageTitle,
                    Content = blogPost.Content,
                    ShortDescription = blogPost.ShortDescription,
                    FeatureImageUrl = blogPost.FeatureImageUrl,
                    UrlHandle = blogPost.UrlHandle,
                    PublishedDate = blogPost.PublishedDate,
                    Author = blogPost.Author,
                    Visible = blogPost.Visible,
                    Tags = blogPost.Tags,
                    TotalLikes = totalLikes,
                    Liked = liked,
                    Comments = blogCommentForView
                };
            }
            return View(blogDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BlogDetailsViewModel blogDetailsViewModel)
        {
            if(_signInManager.IsSignedIn(User))
            {
                var model = new BlogPostComment
                {
                    Description = blogDetailsViewModel.CommentDescription,
                    BlogPostId = blogDetailsViewModel.Id,
                    UserId = Guid.Parse(_userManager.GetUserId(User)),
                    DateAdded = DateTime.Now,
                };

               await  _blogPostCommentService.AddBlogPostCommentAsync(model);
               return RedirectToAction("Index","Blogs",new {urlHandle = blogDetailsViewModel.UrlHandle});
            }
            return View();
        }
    }
}
