using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyIdentityChatApp.EntityLayer.Concrete;
using MyIdentityChatApp.PresentationLayer.Models;

namespace MyIdentityChatApp.PresentationLayer.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DefaultController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
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
