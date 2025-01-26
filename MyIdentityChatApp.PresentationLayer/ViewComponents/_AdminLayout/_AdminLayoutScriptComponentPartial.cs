using Microsoft.AspNetCore.Mvc;

namespace MyIdentityChatApp.PresentationLayer.ViewComponents._AdminLayout
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
