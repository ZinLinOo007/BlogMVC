using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;

namespace BlogMVC.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllAsync();

        Task<Tag?> GetAsync(Guid id);

        Task<EditTagRequest?> GetEditRequestAsync(Guid id);

        Task<Tag> AddAsync(AddTagRequest request);

        Task<Tag?> UpdateAsync(EditTagRequest editTagRequest);

        Task<Tag?> DeleteAsync(Guid id);
    }
}
