using BlogMVC.Mappings;
using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;
using BlogMVC.Repositories;

namespace BlogMVC.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly ITagRepository _tagRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository ,ITagRepository tagRepository )
        {
            this._blogPostRepository = blogPostRepository;
            this._tagRepository = tagRepository;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
           return await _blogPostRepository.AddAsync(blogPost);
        }

        public async Task<BlogPost> AddAsync(AddBlogPostRequest blogPostRequest)
        {
            var blogPost = BlogPostMapper.ToBlogPost(blogPostRequest);
            var selectedTag = new List<Tag>();
            foreach (var selectedTagID in blogPostRequest.SelectedTags)
            {
                var BlogPostID = Guid.Parse(selectedTagID);
                var ExistingTag = await _tagRepository.GetAsync(BlogPostID);
                if (ExistingTag != null)
                {
                    selectedTag.Add(ExistingTag);
                }
            }
            blogPost.Tags = selectedTag;

            return await _blogPostRepository.AddAsync(blogPost);
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            return await _blogPostRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _blogPostRepository.GetAllAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await _blogPostRepository.GetAsync(id);
        }

        public async Task<BlogPost?> UpdateAsync(EditBlogPostRequest blogPostRequest)
        {

            var model = BlogPostMapper.ToBlogPost(blogPostRequest);
            var selectedTags = new List<Tag>();
            foreach (var selectedTag in blogPostRequest.SelectedTags)
            {
                if (Guid.TryParse(selectedTag, out var tag))
                {
                    var foundTag = await _tagRepository.GetAsync(tag);
                    if (foundTag != null)
                    {
                        selectedTags.Add(foundTag);
                    }
                }
            }

            model.Tags = selectedTags;
            return await _blogPostRepository.UpdateAsynce(model);
        }
    }
}
