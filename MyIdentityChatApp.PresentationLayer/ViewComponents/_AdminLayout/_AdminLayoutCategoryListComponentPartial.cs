using Microsoft.AspNetCore.Mvc;
using MyIdentityChatApp.BusinessLayer.Abstract;
using MyIdentityChatApp.DataAccessLayer.Abstract;

namespace MyIdentityChatApp.PresentationLayer.ViewComponents._AdminLayout
{
    public class _AdminLayoutCategoryListComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _AdminLayoutCategoryListComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _categoryService.TGetAll();
            return View(value);
        }
    }
}
