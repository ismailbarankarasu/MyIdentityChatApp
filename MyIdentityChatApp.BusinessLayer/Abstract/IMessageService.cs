using Microsoft.AspNetCore.Identity;
using MyIdentityChatApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIdentityChatApp.BusinessLayer.Abstract
{
    public interface IMessageService: IGenericService<Message>
    {
        public List<Message> TGetMessageBySenderName(int id);
        public List<Message> TGetMessageByReceiverName(int id);
        public Message TGetMessageDetail(int id);
    }
}
