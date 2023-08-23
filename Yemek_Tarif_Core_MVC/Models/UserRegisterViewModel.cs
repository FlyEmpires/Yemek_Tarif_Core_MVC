using System.ComponentModel.DataAnnotations;

namespace Yemek_Tarif_Core_MVC.Models
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz...")]
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz...")]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor...")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail Adresiniz")]
        [Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz...")]
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı Adınız")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınız")]
        public string UserName { get; set; }
    }
}
