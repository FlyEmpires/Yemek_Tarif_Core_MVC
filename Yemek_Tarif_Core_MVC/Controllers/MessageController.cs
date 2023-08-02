using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new(new EFMessageRepository());
        public IActionResult Inbox()
        {
            var values = mm.GetMessageListWithWriter();
            return View(values);
        }

        public IActionResult MessageDetail(int id)
        {
            var message = mm.TGetByID(id);
            return PartialView("MessageDetail", message);
        }
    }
}
