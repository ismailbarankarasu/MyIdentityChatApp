﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIdentityChatApp.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;

        public int SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public int ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
