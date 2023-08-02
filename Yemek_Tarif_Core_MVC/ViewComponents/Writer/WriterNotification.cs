﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {

        NotificationManager nm = new(new EFNotificationRepository());
        public IViewComponentResult Invoke()
        {
            var values = nm.GetList();
            return View(values);
        }
    }
}
