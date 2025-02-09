using MyIdentityChatApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIdentityChatApp.DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        public List<Message> GetMessageBySenderName(int id);
        public List<Message> GetMessageByReceiverName(int id);
        public Message GetMessageDetail(int id);
        Task SendMessageAsync(Message message);
    }
}
