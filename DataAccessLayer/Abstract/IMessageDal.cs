using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IMessageDal:IGenericDal<WriterMessage>
    {
        List<WriterMessage> GetMessageListWithWriter(int id);
        List<WriterMessage> GetSendboxListWithWriter(int id);
    }
}
