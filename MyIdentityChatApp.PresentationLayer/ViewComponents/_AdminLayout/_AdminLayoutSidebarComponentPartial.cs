using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyIdentityChatApp.EntityLayer.Concrete;
using MyIdentityChatApp.PresentationLayer.Models;

namespace MyIdentityChatApp.PresentationLayer.ViewComponents._AdminLayout
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public _AdminLayoutSidebarComponentPartial(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserViewModel model = new UserViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.ImageUrl = values.ImageUrl;
            return View(model);
        }
    }
}
