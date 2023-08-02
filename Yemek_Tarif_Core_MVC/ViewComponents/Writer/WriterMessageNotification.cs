using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageManager mm = new(new EFMessageRepository());
        public IViewComponentResult Invoke()
        {
            int p;
            p = 1;
            var v = mm.GetMessageListWithWriter();
            var values = mm.GetInboxListByWriter(p);
            return View(v);
        }
    }
}
