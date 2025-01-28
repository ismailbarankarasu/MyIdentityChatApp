using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public EfMessageDal(IdentityDbContext _context) : base(_context)
        {
        }
        //Bana gelen mailler
        public List<Message> GetMessageByReceiverId(int id)
        {
            var values = context.Messages.Where(x => x.ReceiverId == id).ToList();
            return values;
        }
    }
}
