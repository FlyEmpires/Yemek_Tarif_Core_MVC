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
    public class EFMessageRepository:GenericRepository<WriterMessage>,IMessageDal
    {
        public List<WriterMessage> GetMessageListWithWriter(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.Messages.Include(x => x.SenderWriter).Where(x => x.ReceiverID == id).ToList();
            }
        }

        public List<WriterMessage> GetSendboxListWithWriter(int id)
        {
            using (var ctx = new Context())
            {
                return ctx.Messages.Include(x => x.ReceiverWriter).Where(x => x.SenderID == id).ToList();
            }
        }
    }
}
