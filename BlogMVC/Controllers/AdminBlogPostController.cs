using BlogMVC.Mappings;
using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;
using BlogMVC.Repositories;
using BlogMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogMVC.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminBlogPostController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IBlogPostService _blogPostService;

     
        public AdminBlogPostController(ITagService tagService, IBlogPostService blogPostService)
        {
            this._tagService = tagService;
            this._blogPostService = blogPostService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var tags =  await _tagService.GetAllAsync();
            var model = new AddBlogPostRequest
            {
                Tags = tags.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                })
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest blogPostRequest)
        {
            
            await _blogPostService.AddAsync(blogPostRequest);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var blogPost =  await  _blogPostService.GetAllAsync();
            return View(blogPost);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var blogPost =  await _blogPostService.GetAsync(id);
            var tags = await _tagService.GetAllAsync();
            if(blogPost != null)
            {
                 
                var model = BlogPostMapper.ToEditBlogPostRequest(blogPost, tags);
                return View(model);
            }
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit (EditBlogPostRequest blogPostRequest)
        {
             

            var updatedBlogPost = await _blogPostService.UpdateAsync(blogPostRequest);
            if(updatedBlogPost != null)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new  { id = blogPostRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete (EditBlogPostRequest blogPostRequest)
        {
           var deleteBlogPost =   await _blogPostService.DeleteAsync(blogPostRequest.Id);
            if(deleteBlogPost != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = blogPostRequest.Id });
        }
    }
}
