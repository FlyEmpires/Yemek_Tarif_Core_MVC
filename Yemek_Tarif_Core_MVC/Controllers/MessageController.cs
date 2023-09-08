using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Security.Claims;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    public class MessageController : Controller
    {
        UserManager um = new(new EFUserRepository());
        MessageManager mm = new(new EFMessageRepository());
        public IActionResult Inbox()
        {
            var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = mm.GetMessageListWithWriter(int.Parse(writerID));
            return View(values);
        }

        public IActionResult MessageDetail(int id)
        {
            var message = mm.TGetByID(id);
            return PartialView("MessageDetail", message);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(WriterMessage wm, string userName)
        {
            try
            {    
                var senderUser = um.GetSessionByWriter(userName);
                var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (senderUser == null)
                {
                    ViewBag.hata = "Kullanıcı Bulunamadı!";
                }
                else
                {
                    wm.SenderID = int.Parse(writerID);
                    wm.ReceiverID = senderUser.Id;
                wm.MessageStatus = true;
                wm.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    wm.MessageDate=  Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    wm.MessageStatus = true;
                mm.TAdd(wm);
                }
                
                return RedirectToAction("Sendbox");

            }
            catch (Exception s)
            {

                var hata= s.Message.ToString();
                return View();
            }

           
            
        }
        public IActionResult SendBox()
        {
            var writerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var values = mm.GetSendBoxListByWriter(int.Parse(writerID));
            return View(values);
        }
    }
}
