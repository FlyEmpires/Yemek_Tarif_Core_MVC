using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<WriterMessage> GetList()
        {
            return _messageDal.GetListAll();
        }
        public List<WriterMessage> GetMessageListWithWriter(int id)
        {
            return _messageDal.GetMessageListWithWriter(id);
        }
        public List<WriterMessage> GetInboxListByWriter(int p)
        {
            return _messageDal.GetListAll(x => x.ReceiverID == p);
        }

        public void TAdd(WriterMessage t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            throw new NotImplementedException();
        }

        public WriterMessage TGetByID(int id)
        {
           return _messageDal.GetByID(id);
        }
      
        public void TUpdate(WriterMessage t)
        {
            throw new NotImplementedException();
        }

        public List<WriterMessage> GetSendBoxListByWriter(int p)
        {
            return _messageDal.GetSendboxListWithWriter(p);
        }
    }
}
