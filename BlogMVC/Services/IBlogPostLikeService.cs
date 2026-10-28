using BlogMVC.Models.Domain;

namespace BlogMVC.Services
{
    public interface IBlogPostLikeService
    {
        Task<int> GetTotalLikes(Guid blogPostId);

        Task<IEnumerable<BlogPostLike>> GetLikesForBlogPost(Guid blogPostId);

        Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike);
    }
}
