using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyIdentityChatApp.PresentationLayer.Models
{
    public class MessageViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ReceiverId { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> Users { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
