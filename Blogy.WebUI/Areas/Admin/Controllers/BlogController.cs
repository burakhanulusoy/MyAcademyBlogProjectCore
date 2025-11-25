using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BlogController(IBlogService _blogService,ICategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetBlogsWithCategoriesAsync();
            return View(blogs);
        }

        private async Task GetCategoriesName()
        {

            var categories=await _categoryService.GetAllCategoryAsync();

            ViewBag.Categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.CategoryName,
                                      Value = category.Id.ToString()
                                  });


        }


        public async Task<IActionResult> CreateBlog()
        {
            await GetCategoriesName();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
             
            if(!ModelState.IsValid)
            {
                await GetCategoriesName();
                return View(createBlogDto);
            }


            await  _blogService.CreateAsync(createBlogDto);
            return RedirectToAction("Index");


        }


        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateBlog(int id)
        {   
            await GetCategoriesName();
            var blog=await _blogService.GetByIdAsync(id);
            return View(blog);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
           if(!ModelState.IsValid)
           {
                await GetCategoriesName();
                return View(updateBlogDto);
           }

           await _blogService.UpdateAsync(updateBlogDto);
           return RedirectToAction(nameof(Index));



        }

    }
}
