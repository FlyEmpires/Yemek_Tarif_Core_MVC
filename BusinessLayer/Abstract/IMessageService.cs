using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<WriterMessage>
    {
        List<WriterMessage> GetInboxListByWriter(int p);
        List<WriterMessage> GetSendBoxListByWriter(int p);
    }
}
