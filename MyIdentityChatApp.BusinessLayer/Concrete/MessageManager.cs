using MyIdentityChatApp.BusinessLayer.Abstract;
using MyIdentityChatApp.DataAccessLayer.Abstract;
using MyIdentityChatApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIdentityChatApp.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public List<Message> TGetAll()
        {
            return _messageDal.GetAll();
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetMessageByReceiverName(int id)
        {
            return _messageDal.GetMessageByReceiverName(id);
        }

        public List<Message> TGetMessageBySenderName(int id)
        {
            return _messageDal.GetMessageBySenderName(id);
        }

        public Message TGetMessageDetail(int id)
        {
            return _messageDal.GetMessageDetail(id);
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
