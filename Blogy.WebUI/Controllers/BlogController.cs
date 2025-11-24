using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers
{
    public class BlogController(IBlogService _blogService,ICategoryService _categoryService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetBlogsByCategory(int id)
        {
            var category=await _categoryService.GetByIdCategoryAsync(id);
            ViewBag.CategoryName=category.Name;
            ViewBag.CategoryId=category.Id;
            return View();
        }



        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog=await _blogService.GetByIdAsync(id);
            return View(blog);

        }









    }
}
