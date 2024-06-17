using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggieDbContext bloggieDbContext;

        public TagRepository(BloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
           await bloggieDbContext.AddAsync(tag);
           await bloggieDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTask= await bloggieDbContext.Tags.FindAsync(id);
            if (existingTask != null)
            {
                bloggieDbContext.Tags.Remove(existingTask);
                await bloggieDbContext.SaveChangesAsync();
                return existingTask;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await bloggieDbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            var tag = await bloggieDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
            return tag;
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await bloggieDbContext.Tags.FindAsync(tag.Id);
            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName=tag.DisplayName;
                await bloggieDbContext.SaveChangesAsync();

                return existingTag;
            }
            return null;
       
        }
    }
}
