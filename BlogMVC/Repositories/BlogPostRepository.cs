using BlogMVC.Data;
using BlogMVC.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDbContext _dbContext;

        public BlogPostRepository(BlogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await _dbContext.BlogPosts.AddAsync(blogPost);
            await _dbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlogPost =  await _dbContext.BlogPosts.FindAsync(id);
            if(existingBlogPost != null)
            {
                _dbContext.BlogPosts.Remove(existingBlogPost);
                await _dbContext.SaveChangesAsync();
                return existingBlogPost;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
           return await  _dbContext.BlogPosts.Include(x=>x.Tags).ToListAsync();

        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
          return   await _dbContext.BlogPosts.Include(x=>x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await _dbContext.BlogPosts.Include(x=>x.Tags).
                FirstOrDefaultAsync(x=>x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsynce(BlogPost blogPost)
        {
           var existingBlogPost =   await _dbContext.BlogPosts.Include(x=>x.Tags).FirstOrDefaultAsync(x => x.Id == blogPost.Id);
            if (existingBlogPost != null)
            {
                existingBlogPost.Id = blogPost.Id;
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.FeatureImageUrl = blogPost.FeatureImageUrl;
                existingBlogPost.UrlHandle  = blogPost.UrlHandle;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visible = blogPost.Visible;
                existingBlogPost.Tags = blogPost.Tags;
                await _dbContext.SaveChangesAsync();
                return existingBlogPost;

            }
            return null;
        }
    }
}
