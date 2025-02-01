using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyIdentityChatApp.DataAccessLayer.Abstract;
using MyIdentityChatApp.DataAccessLayer.EntityFramework;
using MyIdentityChatApp.EntityLayer.Concrete;
using MyIdentityChatApp.PresentationLayer.Models;

namespace MyIdentityChatApp.PresentationLayer.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMessageDal _messageDal;
        public DefaultController(UserManager<ApplicationUser> userManager, IMessageDal messageDal)
        {
            _userManager = userManager;
            _messageDal = messageDal;
        }
        public async Task<IActionResult> Index(int id)
        {
            var values = _messageDal.GetMessageByReceiverId(id);
            return View(values);
        }
    }
}
