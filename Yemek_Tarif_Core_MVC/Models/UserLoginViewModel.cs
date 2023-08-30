using System.ComponentModel.DataAnnotations;

namespace Yemek_Tarif_Core_MVC.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Giriniz...")]
        public string Username{ get; set; }
        [Required(ErrorMessage ="Lütfen Şifrenizi Giriniz...")]
        public string Password{ get; set; }
    }
}
