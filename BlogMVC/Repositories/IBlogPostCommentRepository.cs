using BlogMVC.Models.Domain;

namespace BlogMVC.Repositories
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddBlogPostCommentAsync(BlogPostComment blogPostComment);

        Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
    }
}
