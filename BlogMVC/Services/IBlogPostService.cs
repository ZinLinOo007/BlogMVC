using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;

namespace BlogMVC.Services
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost?> GetAsync(Guid id);

        Task<BlogPost> AddAsync(AddBlogPostRequest  blogPostRequest);

        Task<BlogPost?> UpdateAsync(EditBlogPostRequest blogPostRequest);

        Task<BlogPost?> DeleteAsync(Guid id);
    }
}
