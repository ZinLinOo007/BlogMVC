using BlogMVC.Models.Domain;

namespace BlogMVC.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId);

        Task<IEnumerable<BlogPostLike>> GetLikesForBlogPost(Guid blogPostId);

        Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike);
    }
}
