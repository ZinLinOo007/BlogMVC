using BlogMVC.Models.ViewModels;
using BlogMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagService _tagService;

        public AdminTagsController(ITagService tagService)
        {
            this._tagService = tagService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTagRequest request) { 
            if(!ModelState.IsValid)
                return View(request);
           
            await _tagService.AddAsync(request);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var tags =  await _tagService.GetAllAsync();
           return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await _tagService.GetEditRequestAsync(id);
            if(tag != null)
            {
                return View(tag);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
             
            var updatedTage = await _tagService.UpdateAsync(editTagRequest);
            if(updatedTage != null)
            {
                return RedirectToAction("List");
            }
            

            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete (EditTagRequest editTagRequest)
        {
            var deletedTag =  await _tagService.DeleteAsync(editTagRequest.Id);
            if (deletedTag != null) {
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }



    }
}
