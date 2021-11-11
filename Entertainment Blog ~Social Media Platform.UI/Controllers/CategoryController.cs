using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.DTO.DTOs.CategoryDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Entertainment_Blog__Social_Media_Platform.UI.Controllers
{
    //Belirtilen postları istenilen categoryie eklemeyi ekle!
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public async Task<IActionResult> Lists(CategoryViewListsDTO category)
        {
            var list = await categoryService.GetCategoriesAsync();
            category.CategoryLists = list;
            return View(category);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CategoryViewListsDTO category)
        {
            if (ModelState.IsValid)
            {
                await categoryService.AddCategoryAsync(category.CategoryAdd);
                category.AddedName = category.CategoryAdd.Name; // eğer aynı adda ise yine ekledindi diye çıkıyor onu düzelt!
            }
            return RedirectToAction("Lists", "Category",category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CategoryViewListsDTO category)
        {
            var deleted = await categoryService.GetCategoryByIdAsync(category.Id);
            await categoryService.DeleteCategoryAsync(category.Id);
            category.DeletedName = deleted.Name;
            return RedirectToAction("Lists", "Category",category);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category= categoryService.GetCategoryByIdWithPost(id);
            if (category == null) 
            { 
                return NotFound(); 
            }
            return View(category);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditDTO categoryEdit)
        {
            if (ModelState.IsValid)
            {
                await categoryService.EditCategoryAsync(categoryEdit);
                return RedirectToAction("Lists", "Category");
            }
            return View();
        }
    }
}
