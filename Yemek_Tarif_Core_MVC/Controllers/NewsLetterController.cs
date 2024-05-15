using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Yemek_Tarif_Core_MVC.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new(new EFNewsLetterRepository());
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter p)
        {
            if (!nm.IfExistMail(p.Mail)) // eğer mail sistemde kayıtlı değilse işleme devam et
            {
                p.MailStatus = true;
                nm.AddNewsLetter(p);
                ViewBag.sonuc = 1;
            }

            else
            {
              
                return PartialView("Error","");
            }

            return PartialView();
        }
    }
}
