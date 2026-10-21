using BlogMVC.Models.Domain;

namespace BlogMVC.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost?> GetAsync(Guid id);

        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost?> UpdateAsynce(BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(Guid id);

        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);
    }
}
