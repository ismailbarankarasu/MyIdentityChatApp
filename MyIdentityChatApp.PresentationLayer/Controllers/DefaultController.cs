using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ICategoryService _categoryService;

        public DefaultController(UserManager<ApplicationUser> userManager, IMessageService messageService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _messageService = messageService;
            _categoryService = categoryService;
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
        public IActionResult MessageDetail(int id)
        {
            var value = _messageService.TGetMessageDetail(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            message.SentAt = DateTime.Now;
            _messageService.TInsert(message);
            return View();
        }
        
    }
}
