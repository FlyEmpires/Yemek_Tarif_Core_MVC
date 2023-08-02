using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessageRepository:GenericRepository<Message>,IMessageDal
    {
        public List<Message> GetMessageListWithWriter()
        {
            using (var ctx = new Context())
            {
                return ctx.Messages.Include(x => x.SenderWriter).Where(x=>x.ReceiverID==1).ToList();
            }
        }
    }
}
