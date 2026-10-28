using BlogMVC.Models.Domain;
using BlogMVC.Repositories;

namespace BlogMVC.Services
{
    public class BlogPostCommentService : IBlogPostCommentService
    {
        private readonly IBlogPostCommentRepository _blogPostCommentRepository;

        public BlogPostCommentService(IBlogPostCommentRepository blogPostCommentRepository)
        {
            this._blogPostCommentRepository = blogPostCommentRepository;
        }
        public async Task<BlogPostComment> AddBlogPostCommentAsync(BlogPostComment blogPostComment)
        {
             return await _blogPostCommentRepository.AddBlogPostCommentAsync(blogPostComment);
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await _blogPostCommentRepository.GetCommentsByBlogIdAsync(blogPostId);
        }
    }
}
