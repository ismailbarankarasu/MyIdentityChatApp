using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyIdentityChatApp.DataAccessLayer.Abstract;
using MyIdentityChatApp.DataAccessLayer.Context;
using MyIdentityChatApp.DataAccessLayer.Repositories;
using MyIdentityChatApp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIdentityChatApp.DataAccessLayer.EntityFramework
{

    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        private readonly ChatAppContext context;

        public EfMessageDal(ChatAppContext _context) : base(_context)
        {
            context = _context;
        }

        public List<Message> GetMessageByReceiverName(int id)
        {
            return context.Messages.Where(x => x.SenderId == id)
                    .Include(x => x.Receiver)
                    .ToList();
        }

        //Bana gelen mailler
        public List<Message> GetMessageBySenderName(int id)
        {
            return context.Messages.Where(x => x.ReceiverId == id)
                .Include(x => x.Sender)
                .ToList();
        }

        public Message GetMessageDetail(int id)
        {
            var value= context.Messages
                .Include(x => x.Category)
                .Include(j => j.Sender)
                .Include(y => y.Receiver)
                .Where(x => x.MessageId == id)
                .FirstOrDefault();
            return value;
        }

        public Task SendMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
