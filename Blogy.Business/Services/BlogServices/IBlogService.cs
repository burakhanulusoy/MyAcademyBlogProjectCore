using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.GenericServices;
using Blogy.Entity.Entities;

namespace Blogy.Business.Services.BlogServices
{
    public interface IBlogService:IGenericService<Blog,ResultBlogDto,UpdateBlogDto,CreateBlogDto>
    {

        Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync();

        Task<List<ResultBlogDto>> GetBlogsWithCategoryIdAsync(int id);

        Task<List<ResultBlogDto>> GetLast3BlogsAsync();




    }
}
