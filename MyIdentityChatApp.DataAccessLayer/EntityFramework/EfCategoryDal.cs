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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(ChatAppContext context) : base(context)
        {
        }
        
    }
}
