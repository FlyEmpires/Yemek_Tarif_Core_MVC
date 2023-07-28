using Microsoft.AspNetCore.Mvc;

namespace Yemek_Tarif_Core_MVC.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
