using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Business.Services.CategoryServices;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController(ICategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);

        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {

            if (!ModelState.IsValid)
            {
                return View(createCategoryDto);
            }

            try
            {
                await _categoryService.CreateCategoryAsync(createCategoryDto);
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(createCategoryDto);
            }



        }


        public async Task<IActionResult> DeleteCategory(int id)
        {
            await  _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetByIdCategoryAsync(id);
            return View(category);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if(!ModelState.IsValid)
            {
              return View(updateCategoryDto);
            }
            try
            {
                await _categoryService.UpdateCategoryAsync(updateCategoryDto);
                return RedirectToAction(nameof(Index));

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Name", ex.Message);
                return View(updateCategoryDto);
            }


          

        }


    }
}
