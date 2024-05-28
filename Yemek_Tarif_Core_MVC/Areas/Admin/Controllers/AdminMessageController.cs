using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Yemek_Tarif_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        MessageManager mm = new(new EFMessageRepository());
        UserManager um = new(new EFUserRepository());

        public IActionResult Inbox()
        {
            var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = mm.GetMessageListWithWriter(int.Parse(writerID));
            ViewBag.messageCount = values.Count;
            return View(values);
        }
        public IActionResult Sendbox()
        {
            var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = mm.GetSendBoxListByWriter(int.Parse(writerID));
            ViewBag.messageCount = values.Count;

            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(WriterMessage wm, string userName)
        {
            try
            {
                var receiverUser = um.GetSessionByWriter(userName);
                if (receiverUser == null)
                {
                    ViewBag.hata = "Kullanıcı Bulunamadı!";
                }
                else
                {
                    var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var values = mm.GetMessageListWithWriter(int.Parse(writerID));
                    wm.SenderID = int.Parse(writerID);
                    wm.ReceiverID = receiverUser.Id;
                    wm.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    wm.MessageStatus = true;
                    mm.TAdd(wm);
                    return RedirectToAction("Sendbox");
                }
            }
            catch (Exception s)
            {
                var hata = s.Message.ToString();
            }
            return View();
        }
        public PartialViewResult PartialMessageMenu()
        {
            return PartialView();
        }
        public IActionResult MessageDetail(int id)
        {
            var message = mm.TGetByID(id);
            return PartialView("MessageDetail", message);
        }
    }
}
