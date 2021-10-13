using Entertainment_Blog.Bussiness.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Entertainment_Blog__Social_Media_Platform.UI.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public MenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryService.GetCategoriesIncludePosts());
        }
    }
}
