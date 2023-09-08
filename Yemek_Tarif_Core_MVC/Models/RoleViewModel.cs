using System.ComponentModel.DataAnnotations;

namespace Yemek_Tarif_Core_MVC.Models
{
    public class RoleViewModel
    {
        public int Id{ get; set; }
        [Required(ErrorMessage ="Lütfen Rol Adı Giriniz")]
        public string Name{ get; set; } 
    }
}
