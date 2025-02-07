using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyIdentityChatApp.BusinessLayer.Abstract;
using MyIdentityChatApp.DataAccessLayer.Abstract;
using MyIdentityChatApp.EntityLayer.Concrete;
using System.Threading.Tasks;

namespace MyIdentityChatApp.PresentationLayer.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMessageService _messageService;

        public DefaultController(UserManager<ApplicationUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Login"); 
            }

            var messages = _messageService.TGetMessageBySenderName(user.Id); 
            return View(messages);
        }
        public async Task<IActionResult>Outbox()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Login"); 
            }
            var messages = _messageService.TGetMessageByReceiverName(user.Id);
            
            return View(messages);
        }
    }
}
