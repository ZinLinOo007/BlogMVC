using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;

namespace BlogMVC.Mappings
{
    public class BlogPostMapper
    {
        public static BlogPost ToBlogPost(AddBlogPostRequest blogPostRequest)
        {
            return new BlogPost
            {
                Heading = blogPostRequest.Heading,
                PageTitle = blogPostRequest.PageTitle,
                Content = blogPostRequest.Content,
                ShortDescription = blogPostRequest.ShortDescription,
                FeatureImageUrl = blogPostRequest.FeatureImageUrl,
                UrlHandle = blogPostRequest.UrlHandle,
                PublishedDate = blogPostRequest.PublishedDate,
                Author = blogPostRequest.Author,
                Visible = blogPostRequest.Visible,
            };
        }


        public static EditBlogPostRequest ToEditBlogPostRequest(BlogPost blogPost, IEnumerable<Tag> tags)
        {
            return new EditBlogPostRequest
            {
                Id = blogPost.Id,
                Heading = blogPost.Heading,
                PageTitle = blogPost.PageTitle,
                Content = blogPost.Content,
                ShortDescription = blogPost.ShortDescription,
                FeatureImageUrl = blogPost.FeatureImageUrl,
                UrlHandle = blogPost.UrlHandle,
                PublishedDate = blogPost.PublishedDate,
                Author = blogPost.Author,
                Visible = blogPost.Visible,
                Tags = tags.Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                }),
                SelectedTags = blogPost.Tags.Select(t => t.Id.ToString()).ToArray()
            };
        }

        public static BlogPost ToBlogPost(EditBlogPostRequest blogPostRequest)
        {
            return new BlogPost
            {
                Id = blogPostRequest.Id,
                Heading = blogPostRequest.Heading,
                PageTitle = blogPostRequest.PageTitle,
                Content = blogPostRequest.Content,
                ShortDescription = blogPostRequest.ShortDescription,
                FeatureImageUrl = blogPostRequest.FeatureImageUrl,
                UrlHandle = blogPostRequest.UrlHandle,
                PublishedDate = blogPostRequest.PublishedDate,
                Author = blogPostRequest.Author,
                Visible = blogPostRequest.Visible,
            };
        }



    }
}
