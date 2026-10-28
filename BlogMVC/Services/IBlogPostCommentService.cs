using BlogMVC.Models.Domain;

namespace BlogMVC.Services
{
    public interface IBlogPostCommentService
    {
        Task<BlogPostComment> AddBlogPostCommentAsync(BlogPostComment blogPostComment);

        Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
    }
}
