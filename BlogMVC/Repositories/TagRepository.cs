using BlogMVC.Data;
using BlogMVC.Models.Domain;
using BlogMVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext _dbContext;

        public TagRepository(BlogDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<Tag> AddAsync(Tag tag)
        {
            await _dbContext.Tags.AddAsync(tag);
            await _dbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
           var existingTag =  await _dbContext.Tags.FindAsync(id);
            if (existingTag != null) { 
                _dbContext.Tags.Remove(existingTag);
                await _dbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
           return await _dbContext.Tags.ToListAsync();
            
        }

        public  Task<Tag?> GetAsync(Guid id)
        {
            return _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
           
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
          var existingTag =   await _dbContext.Tags.FindAsync(tag.Id);
            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;
                await _dbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }
    }
}
