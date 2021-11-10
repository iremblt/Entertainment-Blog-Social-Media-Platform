using Entertainment_Blog.Bussiness.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Entertainment_Blog__Social_Media_Platform.UI.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        private IPostService _postService;
        public MenuViewComponent(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryService.GetCategoriesIncludePosts());
        }
    }
}
