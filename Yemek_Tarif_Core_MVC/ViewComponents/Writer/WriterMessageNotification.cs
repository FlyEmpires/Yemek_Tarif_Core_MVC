using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        MessageManager mm = new(new EFMessageRepository());
        UserManager um = new(new EFUserRepository());
        public IViewComponentResult Invoke()
        {
          
            var userName = User.Identity.Name;
            var id = um.GetSessionByWriter(userName).Id;
            //var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var v = mm.GetMessageListWithWriter(id);
            //var values = mm.GetInboxListByWriter(p);
            return View(v);
        }
    }
}
