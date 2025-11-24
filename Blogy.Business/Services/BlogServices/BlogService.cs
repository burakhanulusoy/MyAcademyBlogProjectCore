using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.Entity.Entities;
using System.Linq.Expressions;

namespace Blogy.Business.Services.BlogServices
{
    public class BlogService : IBlogService
    {

        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateBlogDto createDto)
        {
           var blog=_mapper.Map<Blog>(createDto);
            await _blogRepository.CreateAsync(blog);


        }

        public async Task DeleteAsync(int id)
        {
           
            await _blogRepository.DeleteAsync(id);

        }

        public async Task<List<ResultBlogDto>> GetAllAsync()
        {

            var blogs = await _blogRepository.GetAllAsync();
            return _mapper.Map<List<ResultBlogDto>>(blogs);

        }

        public async Task<List<ResultBlogDto>> GetAllAsync(Expression<Func<Blog, bool>> filter)
        {
            var blogs = await _blogRepository.GetAllAsync(filter);
            return _mapper.Map<List<ResultBlogDto>>(blogs);
        }

       

        public async Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync()
        {
            var blogs=await _blogRepository.GetBlogsWithCategoriesAsync();
            return _mapper.Map<List<ResultBlogDto>>(blogs);



        }

        public async Task<List<ResultBlogDto>> GetBlogsWithCategoryIdAsync(int id)
        {
            var blogs=await _blogRepository.GetAllAsync(x=>x.CategoryId==id);
            return _mapper.Map<List<ResultBlogDto>>(blogs); 


        }

        public async Task<UpdateBlogDto> GetByIdAsync(int id)
        {
            var blog = await _blogRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateBlogDto>(blog);

        }

        public async Task<List<ResultBlogDto>> GetLast3BlogsAsync()
        {
            
            var blogs=await _blogRepository.GetLast3BlogsAsync();
            return _mapper.Map<List<ResultBlogDto>>(blogs);

             
        }

        public async Task UpdateAsync(UpdateBlogDto updateDto)
        {
           var blog=_mapper.Map<Blog>(updateDto);
           await _blogRepository.UpdateAsync(blog);


        }
    }
}
