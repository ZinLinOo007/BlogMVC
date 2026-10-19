using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;

namespace BlogMVC.Mappings
{
    public class TagMapper
    {
        public static Tag ToTag(AddTagRequest addTagRequest)
        {
            return new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };
        }

        public static EditTagRequest ToEditTagRequest (Tag tag)
        {
            return new EditTagRequest
            {
                Id = tag.Id,
                Name = tag.Name,
                DisplayName = tag.DisplayName
            };
        }

        public static Tag ToTag(EditTagRequest editTagRequest)
        {
            return new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };
        }
    }
}
