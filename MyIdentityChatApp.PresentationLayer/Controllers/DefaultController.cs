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
        public async Task<IActionResult> SendMessage()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var users = _userManager.Users
                .Where(u => u.Id != user.Id) 
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName 
                })
                .ToList();

            ViewBag.Receivers = users;

            var categories = _categoryService.TGetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name 
                })
                .ToList();

            ViewBag.Categories = categories;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            message.SenderId = user.Id;
            message.SentAt = DateTime.Now;
            _messageService.TInsert(message);

            TempData["MessageSent"] = true;

            return RedirectToAction("SendMessage");
        }



    }
}
