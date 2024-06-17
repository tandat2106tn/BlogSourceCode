﻿using Bloggie.Web.Models.Domain;
using CourseManagement.ViewModels;

namespace Bloggie.Web.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetAsync(Guid id);

        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);
        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost?>UpdateAsync(BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(Guid id);

        Task<PaginatedList<BlogPost>> GetAllAsync(string sortOrder, string currentFilter, string searchString, int? pageNumber, int pageSize);
    }
}
