using BlogMVC.Data;
using BlogMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogPostCommentRepository(BlogDbContext blogDbContext)
        {
            this._blogDbContext = blogDbContext;
        }
        public async Task<BlogPostComment> AddBlogPostCommentAsync(BlogPostComment blogPostComment)
        {
           await _blogDbContext.BlogPostComment.AddAsync(blogPostComment);
           await _blogDbContext.SaveChangesAsync();
           return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
           return  await _blogDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
