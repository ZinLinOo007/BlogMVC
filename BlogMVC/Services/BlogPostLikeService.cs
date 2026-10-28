
using BlogMVC.Models.Domain;
using BlogMVC.Repositories;

namespace BlogMVC.Services
{
    public class BlogPostLikeService : IBlogPostLikeService
    {
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;

        public BlogPostLikeService(IBlogPostLikeRepository blogPostLikeRepository)
        {
            this._blogPostLikeRepository = blogPostLikeRepository;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            return  await _blogPostLikeRepository.AddLikeForBlog(blogPostLike);
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlogPost(Guid blogPostId)
        {
            return await _blogPostLikeRepository.GetLikesForBlogPost(blogPostId);
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
          return await _blogPostLikeRepository.GetTotalLikes(blogPostId);
        }
    }
}
