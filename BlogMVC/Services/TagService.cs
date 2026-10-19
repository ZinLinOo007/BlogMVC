using Azure.Core;
using BlogMVC.Mappings;
using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;
using BlogMVC.Repositories;

namespace BlogMVC.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this._tagRepository = tagRepository;
        }
       

        public async Task<Tag> AddAsync(AddTagRequest request)
        {
            var tag = TagMapper.ToTag(request);
            return await _tagRepository.AddAsync(tag);

        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            return await _tagRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _tagRepository.GetAllAsync();
        }

      
        public async Task<EditTagRequest?> GetEditRequestAsync(Guid id)
        {
            var tag = await _tagRepository.GetAsync(id);

            if (tag == null)
            {
                return null;
            }

            return TagMapper.ToEditTagRequest(tag);
        }

        public async Task<Tag?> UpdateAsync(EditTagRequest editTagRequest)
        {
            var tag = TagMapper.ToTag(editTagRequest);
            return  await _tagRepository.UpdateAsync(tag);

        }

        public async Task<Tag?> GetAsync(Guid id)
        {
             return await _tagRepository.GetAsync(id);
        }
    }
}
