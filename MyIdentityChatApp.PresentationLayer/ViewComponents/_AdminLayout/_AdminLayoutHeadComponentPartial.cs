using Microsoft.AspNetCore.Mvc;

namespace MyIdentityChatApp.PresentationLayer.ViewComponents._AdminLayout
{
    public class _AdminLayoutHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
